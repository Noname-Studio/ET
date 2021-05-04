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
        private HashSet<string> UsedProp { get; } = new HashSet<string>();

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
            var level = LevelProperty.Read(PlayerManager.Inst.CurrentLevel);
            if (level == null)
            {
                //level找不到.我们开始随机一些关卡.
                //Todo
            }
            LevelProperty = level;
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
            Manager.Create<UI_QuickShop>(new UI_QuickShop.ParamsData(LevelProperty));
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
            View.Restaurant.text = LocalizationProperty.Read(level.Restaurant.Key);
            InitTarget(level);
            InitProp(level);
        }

        private void InitTarget(LevelProperty level)
        {
            if (level.LevelType.HasFlag(LevelProperty.LevelTypeFlags.固定时间))
            {
                var target = (GLabel) View.MainTarget.AddItemFromPool();
                target.icon = "ui://Common/沙漏拷贝";
                target.text = TimeUtils.ConvertNumberToTimeString(level.Requirements.FixedTime, @"mm\:ss");
            }

            if (level.LevelType.HasFlag(LevelProperty.LevelTypeFlags.收集金币))
            {
                var target = (GLabel) View.MainTarget.AddItemFromPool();
                target.icon = "ui://Common/coin_icon";
                target.text = "X " + level.Requirements.RequiredCoin;
            }

            if (level.LevelType.HasFlag(LevelProperty.LevelTypeFlags.点赞数量))
            {
                var target = (GLabel) View.MainTarget.AddItemFromPool();
                target.icon = "ui://Common/icon_great";
                target.text = "X " + level.Requirements.LikeCount;
            }

            if (level.LevelType.HasFlag(LevelProperty.LevelTypeFlags.服务订单))
            {
                var target = (GLabel) View.MainTarget.AddItemFromPool();
                target.icon = "ui://Common/icon_any_dish";
                target.text = "X " + level.Requirements.NumberOfCompletedOrders;
            }

            if (level.LevelType.HasFlag(LevelProperty.LevelTypeFlags.服务顾客))
            {
                var target = (GLabel) View.MainTarget.AddItemFromPool();
                target.icon = "ui://Common/icon_any_cus";
                target.text = "X " + level.Requirements.NumberOfCustomerService;
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
            View.Prop.onClickItem.Add(PropItem_OnClick);
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
                        var num = propMgr.Get(node.Id).Count;
                        if (num > 0)
                        {
                            button.choice.title = propMgr.Get(node.Id).Count.ToString();
                            button.choice.Plus.visible = false;
                        }
                        else
                        {
                            button.choice.title = "";
                            button.choice.Plus.visible = true;
                        }
                    }
                    else
                    {
                        button.IsLock.selectedPage = "TRUE";
                    }
                }
            }
        }

        private void PropItem_OnClick(EventContext context)
        {
            var component = (GButton) context.data;
            var property = (PropProperty) component.data;
            var propMgr = DBManager.Inst.Query<Data_Prop>();
            var num = propMgr.Get(property.Id).Count;
            if (num > 0)
                UseProp_OnClick(property,component.selected);
            else
                BuyProp_OnClick(property);
        }

        private void UseProp_OnClick(PropProperty prop,bool selected)
        {
            if (selected)
                UsedProp.Add(prop.Id);
            else
                UsedProp.Remove(prop.Id);
        }

        private void BuyProp_OnClick(PropProperty prop)
        {
            var tips = UIKit.Inst.Create<UI_Tips>();
            var propMgr = DBManager.Inst.Query<Data_Prop>();
            tips.SetContent($"使用{prop.Price.Gem}钻石购买道具");
            tips.AddButton(LocalizationProperty.Read("Confirm"), uiTips =>
            {
                propMgr.Get(prop.Id).Count++;
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