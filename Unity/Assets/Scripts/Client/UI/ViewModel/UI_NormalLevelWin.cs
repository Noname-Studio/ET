using Client.Effect;
using Cysharp.Threading.Tasks;
using FairyGUI;
using KitchenUI;
using Panthea.NativePlugins.Ads;
using Panthea.NativePlugins.Analytics;
using UnityEngine.Experimental.Rendering.Client.Logic.Helpler;

namespace Client.UI.ViewModel
{
    public class UI_NormalLevelWin : UIBase<View_win>
    {
        private int mGainNumber = 0;
        protected override void OnInit(IUIParams p)
        {
            base.OnInit(p);
            View.Confirm.onClick.Set(Confirm_OnClick);
            View.Watchvideo.onClick.Set(WatchVideo_OnClick);
            View.NormalReward.title = (KitchenRoot.Inst.Record.CoinNumber).ToString();
            if (AdsKit.Inst.IsReady(AdsFlag.RewardVideoPlacementId))
            {
                View.HasAd.selectedPage = "TRUE";
            }
            mGainNumber = KitchenRoot.Inst.Record.CoinNumber;
            ResourcesHelper.GainGameCoin(KitchenRoot.Inst.Record.CoinNumber);
        }

        private async void WatchVideo_OnClick(EventContext context)
        {
            var adsCallback = await AdsKit.Inst.PlayRewardVideoAsync();
            if (adsCallback.result)
            {
                View.NormalReward.title = (KitchenRoot.Inst.Record.CoinNumber * 2).ToString();
                View.Watchvideo.visible = false;
                AnalyticsKit.Inst.AdComplete(true, adsCallback.ToString(), "double coin");
                View.HasAd.selectedPage = "FALSE";
                ResourcesHelper.GainGameCoin(KitchenRoot.Inst.Record.CoinNumber);
                mGainNumber *= 2;
            }
            else
            {
                AnalyticsKit.Inst.AdComplete(false, adsCallback.ToString(), "double coin");
            }
        }

        private async void Confirm_OnClick(EventContext context)
        {
            //TODO 这里应该播放增加金币的效果
            var effect = EffectFactory.Create(new ResourcesBarValueChanged(mGainNumber, ResourcesBarValueChanged.ResourceType.Gem));
            while (effect.IsPlaying)
            {
                await UniTask.NextFrame();
            }
            CloseMySelf();
            KRManager.Inst.BackPrevMode();
        }
    }
}