using FairyGUI;
using KitchenUI;
using Panthea.NativePlugins.Ads;
using Panthea.NativePlugins.Analytics;

namespace Client.UI.ViewModel
{
    public class UI_NormalLevelWin : UIBase<View_win>
    {
        protected override void OnInit(IUIParams p)
        {
            base.OnInit(p);
            View.Confirm.onClick.Set(Confirm_OnClick);
            View.Watchvideo.onClick.Set(WatchVideo_OnClick);
            View.NormalReward.title = (KitchenRoot.Inst.Record.CoinNumber).ToString();
        }

        private async void WatchVideo_OnClick(EventContext context)
        {
            var adsCallback = await AdsKit.Inst.PlayRewardVideoAsync();
            if (adsCallback.result)
            {
                View.NormalReward.title = (KitchenRoot.Inst.Record.CoinNumber * 2).ToString();
                View.Watchvideo.visible = false;
                AnalyticsKit.Inst.AdComplete(true, adsCallback.ToString(), "double coin");
            }
            else
            {
                AnalyticsKit.Inst.AdComplete(false, adsCallback.ToString(), "double coin");
            }
        }

        private void Confirm_OnClick(EventContext context)
        {
            CloseMySelf();
            KRManager.Inst.BackPrevMode();
        }
    }
}