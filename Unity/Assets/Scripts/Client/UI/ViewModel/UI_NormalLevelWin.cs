using FairyGUI;
using KitchenUI;
using Panthea.NativePlugins.Ads;

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
            var result = await AdsKit.Inst.PlayRewardVideoAsync();
            if (result)
            {
                View.NormalReward.title = (KitchenRoot.Inst.Record.CoinNumber * 2).ToString();
                View.Watchvideo.visible = false;
            }
        }

        private void Confirm_OnClick(EventContext context)
        {
            CloseMySelf();
            KRManager.Inst.BackPrevMode();
        }
    }
}