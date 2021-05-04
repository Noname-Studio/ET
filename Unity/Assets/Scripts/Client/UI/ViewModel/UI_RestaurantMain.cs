using Client.Effect;
using Client.Manager;
using FairyGUI;
using Main;
using Panthea.NativePlugins.Ads;
using Panthea.NativePlugins.Analytics;
using Panthea.NativePlugins.IAP;
using RestaurantPreview.Config;
using UnityEngine.Experimental.Rendering.Client.Logic.Helpler;

namespace Client.UI.ViewModel
{
    public class UI_RestaurantMain: UIBase<View_Main>
    {
        protected override void OnInit(IUIParams p)
        {
            base.OnInit(p);
            InitUI();
        }

        protected override void OnEnable(IUIParams p, bool refresh)
        {
            base.OnEnable(p, refresh);
            MessageKit.Inst.Add(EventKey.AdsReady,Event_AdsReady );
        }

        protected override void OnDisable(bool refresh)
        {
            base.OnDisable(refresh);
            MessageKit.Inst.Remove(EventKey.AdsReady, Event_AdsReady);
        }

        private void Event_AdsReady()
        {
            var item = View.RightList.GetChild("AD");
            if (item == null)
            {
                item = View.RightList.GetFromPool(View_AD_Button.URL);
                View.RightList.AddChildAt(item, 0);
                item.name = "AD";
            }
        }

        private void InitUI()
        {
            View.Play.onClick.Set(PlayGame_OnClick);
            View.Club.onClick.Set(Club_OnClick);
            View.Settings.onClick.Set(Settings_OnClick);
            View.Shop.onClick.Set(Shop_OnClick);
            View.LeftList.onClickItem.Set(LeftList_OnClickItem);
            View.RightList.onClickItem.Set(RightList_ItemOnClick);
            View.More.com.list.onClickItem.Add(MoreList_ItemOnClick);
            InitRightList();
        }

        /// <summary>
        /// 右边列表属于动态列表.每次显示界面的时候都应该初始化这个函数.加入对应的按钮(AD,礼包,活动...)
        /// </summary>
        private void InitRightList()
        {
            if (AdsKit.Inst.IsReady(AdsFlag.RewardVideoPlacementId))
            {
                Event_AdsReady();
            }

            if (PlayerManager.Inst.CurrentLevel < RestaurantKey.Breakfast.Index * GameConfig.RestaurantOffset + 50 && IAPKit.Inst.InitializationComplete)
            {
                if (!IAPKit.Inst.HasPurchased("starter_pack1"))
                {
                    var item = View.RightList.AddItemFromPool(View_NewPack_Button.URL);
                    item.name = "starter_pack";
                    item.data = IAPProperty.Read("starter_pack1");
                }
            }
            else
            {
                if (!IAPKit.Inst.HasPurchased("starter_pack2"))
                {
                    var item = View.RightList.AddItemFromPool(View_NewPack_Button.URL);
                    item.name = "starter_pack";
                    item.data = IAPProperty.Read("starter_pack2");
                }
            }
        }

        private void Pack_OnClick(IAPProperty property)
        {
            UIKit.Inst.Create<UI_StarterPack>(new UI_StarterPack.ParamsData(property));
        }

        private void Bank_OnClick()
        {
            UIKit.Inst.Create<UI_Bank>();
        }
        
        private void Shop_OnClick()
        {
            UIKit.Inst.Create<UI_LegacyShop>(new UI_LegacyShop.ParamsData(PlayerManager.Inst.PlayingRestaurant));
        }

        private void Settings_OnClick()
        {
            UIKit.Inst.Create<UI_Settings>();
        }

        private async void Club_OnClick()
        {
            if (!NetworkManager.Inst.IsConnect)
            {
                await NetworkManager.Inst.Connect();
                if (!NetworkManager.Inst.IsConnect)
                {
                    var tips = UIKit.Inst.Create<UI_Tips>();
                    tips.SetContent(LocalizationProperty.Read("NetworkNotReachable"));
                    tips.AddButton(LocalizationProperty.Read("Confirm"));
                    return;
                }
            }
            if (!GuildManager.Inst.IsJoined())
            {
                UIKit.Inst.Create<UI_NotJoinGuild>();
            }
            else
            {
                UIKit.Inst.Create<UI_JoinedGuild>();
            }
        }

        private void PlayGame_OnClick()
        {
            if (EnterLevelHelper.CheckCondition())
            {
                UIKit.Inst.Create<UI_EnterLevelPanel>();
            }
        }

        private async void AdsButton_onClick()
        {
            var adsCallback = await AdsKit.Inst.PlayRewardVideoAsync();
            if (adsCallback.result)
            {
                var num = GlobalConfigProperty.Read("WatchVideoGetGemNum").Int;
                ResourcesHelper.GainGem(num);
                AnalyticsKit.Inst.AdComplete(true, adsCallback.handler.ToString(), "Free Gem");
                EffectFactory.Create(new ResourcesBarValueChanged(num, ResourcesBarValueChanged.ResourceType.Gem));
            }
            else
            {
                AnalyticsKit.Inst.AdComplete(false, adsCallback.handler.ToString(), "Free Gem");
            }
        }

        private void Achievement_onClick()
        {
            UIKit.Inst.Create<UI_Achievement>();
        }

        private void Mail_onClick()
        {
            UIKit.Inst.Create<UI_Mail>();
        }
        
        private void LeftList_OnClickItem(EventContext context)
        {
            var name = ((GObject)context.data).name;
            if(name == "Bank")
                Bank_OnClick();
        }

        private void RightList_ItemOnClick(EventContext context)
        {
            var clicker = (GObject) context.data;
            if (clicker.name == "AD")
                AdsButton_onClick();
            else if (clicker.name == "starter_pack")
                Pack_OnClick((IAPProperty) clicker.data);
        }
        
        private void MoreList_ItemOnClick(EventContext context)
        {
            var clicker = (GObject) context.data;
            if (clicker.name == "achievement")
                Achievement_onClick();
            else if(clicker.name == "message")
                Mail_onClick();
        }
    }
}