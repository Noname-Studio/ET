using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using FairyGUI;
using GameBegins;
using Kitchen.Action;
using Panthea.Asset;
using RestaurantPreview.Config;

namespace Client.UI.ViewModel
{
    public partial class UI_EnterLevelPanel: UIBase<View_GameBegins>
    {
        private IAssetsLocator AssetsLocator { get; }
        private KRManager KrManager { get; }
        private Data_GameRecord GameRecord { get; set; }
        private LevelProperty LevelProperty { get; set; }
        private List<string> UsedProp { get; } = new List<string>();

        public UI_EnterLevelPanel()
        {
            AssetsLocator = AssetsKit.Inst;
            KrManager = KRManager.Inst;
        }

        protected override async void OnInit(IUIParams p)
        {
            base.OnInit(p);
            InitEditor();
            GameRecord = DBManager.Inst.Query<Data_GameRecord>();
            LevelProperty = await AssetsLocator.Load<LevelProperty>(GameConfig.LevelConfigPath + GameRecord.Level);
            InitPanel(LevelProperty);
            InitUI();
        }

        protected override void OnEnable(IUIParams p, bool refresh)
        {
            base.OnEnable(p, refresh);
            TimerKit.Inst.UnityTimer.Pause();
        }

        protected override void OnDisable(bool refresh)
        {
            base.OnDisable(refresh);
            TimerKit.Inst.UnityTimer.Resume();
        }

        private void InitUI()
        {
            View.Play.onClick.Add(Play_OnClick);
            View.Shop.onClick.Add(Shop_OnClick);
        }

        private void Shop_OnClick()
        {
            Manager.Create<UI_QuickShop>();
        }

        private void Play_OnClick()
        {
            if (LevelProperty != null)
            {
                if (KrManager.IsKitchen)
                {
                    QueueEventsKit.Inst.AddToBottom(new ResumeKitchenLogic());
                }
                else
                {
                    KrManager.SwitchToKitchen<NormalKitchenMode>(LevelProperty, UsedProp).Forget();
                }
            }

            base.CloseMySelf();
        }

        private void InitPanel(LevelProperty level)
        {
            LevelProperty = level;
            View.Level.text = string.Format(LocalizationProperty.Read("Level X"), level.LevelId);
            View.Restaurant.text = LocalizationProperty.Read(level.RestaurantId.Key);
            InitTarget(level);
            InitProp(level);
        }

        private void InitTarget(LevelProperty level)
        {
            if (level.Type.HasFlag(LevelType.FixedTime))
            {
                var target = (GLabel) View.MainTarget.AddItemFromPool();
                target.icon = "ui://Common/沙漏拷贝";
                target.text = TimeUtils.ConvertNumberToTimeString(level.Requirements.FixedTime, @"mm\:ss");
            }

            if (level.Type.HasFlag(LevelType.Coin))
            {
                var target = (GLabel) View.MainTarget.AddItemFromPool();
                target.icon = "ui://Common/coin_icon";
                target.text = "X " + level.Requirements.RequiredCoin;
            }

            if (level.Type.HasFlag(LevelType.LikeCount))
            {
                var target = (GLabel) View.MainTarget.AddItemFromPool();
                target.icon = "ui://Common/icon_great";
                target.text = "X " + level.Requirements.LikeCount;
            }

            if (level.Type.HasFlag(LevelType.NumberOfCompletedOrders))
            {
                var target = (GLabel) View.MainTarget.AddItemFromPool();
                target.icon = "ui://Common/icon_any_dish";
                target.text = "X " + level.Requirements.NumberOfCompletedOrders;
            }

            if (level.Type.HasFlag(LevelType.NumberOfCustomerService))
            {
                var target = (GLabel) View.MainTarget.AddItemFromPool();
                target.icon = "ui://Common/icon_any_cus";
                target.text = "X " + level.Requirements.NumberOfCompletedOrders;
            }

            bool subVisable = false;
            if (!level.Requirements.AllowBurn)
            {
                var target = View.SubTarget.AddItemFromPool();
                subVisable = true;
                target.icon = "ui://Common/no_burn";
            }

            if (!level.Requirements.AllowLostCustomer)
            {
                var target = View.SubTarget.AddItemFromPool();
                subVisable = true;
                target.icon = "ui://Common/icon_no_lost";
            }

            if (!level.Requirements.AllowUseTrash)
            {
                var target = View.SubTarget.AddItemFromPool();
                subVisable = true;
                target.icon = "ui://Common/no_trash";
            }

            View.item1_bg.visible = subVisable;
        }

        private void InitProp(LevelProperty level)
        {
            var propMgr = DBManager.Inst.Query<Data_Prop>();
            foreach (var node in PropProperty.ReadDict().Values)
            {
                if (node.Type == PropProperty.TypeEnum.Level)
                {
                    var button = (View_Button12) View.Prop.AddItemFromPool();
                    button.data = node;
                    if (node.Unlock <= level.Id)
                    {
                        button.IsLock.selectedPage = "FALSE";
                        button.icon = node.Icon;
                        var num = propMgr.GetNumByKey(node.Id);
                        if (num > 0)
                        {
                            button.choice.title = propMgr.GetNumByKey(node.Id).ToString();
                            button.choice.Plus.visible = false;
                            button.onClick.Remove(UseProp_OnClick);
                        }
                        else
                        {
                            button.choice.title = "";
                            button.choice.Plus.visible = true;
                            button.onClick.Add(BuyProp_OnClick);
                        }
                    }
                    else
                    {
                        button.IsLock.selectedPage = "TRUE";
                    }
                }
            }
        }

        private void UseProp_OnClick(EventContext evt)
        {
            var component = (GComponent) evt.sender;
            var property = (PropProperty) component.data;
            UsedProp.Add(property.Id);
        }

        private void BuyProp_OnClick(EventContext evt)
        {
            var component = (GComponent) evt.sender;
            var property = (PropProperty) component.data;
            var tips = UIKit.Inst.Create<UI_Tips>();
            var propMgr = DBManager.Inst.Query<Data_Prop>();
            tips.SetContent($"使用{property.Price.Gem}钻石购买道具");
            tips.AddButton(LocalizationProperty.Read("Confirm"), uiTips =>
            {
                propMgr.IncrementNumByKey(property.Id);
                DBManager.Inst.Update(propMgr);
            });
            tips.AddButton(LocalizationProperty.Read("Cancel"));
        }

        public override void CloseMySelf()
        {
            if (KrManager.IsKitchen)
                KrManager.BackPrevMode();
            else
                base.CloseMySelf();
        }
    }
}