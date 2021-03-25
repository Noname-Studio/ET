#if UNITY_ANDROID || UNITY_IOS
using System.Threading.Tasks;
using UnityEngine.Advertisements;
namespace Panthea.NativePlugins.Ads
{
    public class UnityAds : IUnityAdsListener,IAdsHandler
    {
#if UNITY_IOS
        private string gameId { get; } = "4060426";
#elif UNITY_ANDROID
        private string gameId { get; } = "4060427";
#endif
        private string RewardVideoPlacementId { get; } = "rewardedVideo";
        private string VideoPlacementId { get; } = "video";

        private MessageKit mEventManager { get; }
        private TaskCompletionSource<bool> Tcs { get; set; }
        public UnityAds()
        {
            mEventManager = MessageKit.Inst;
            Advertisement.AddListener(this);
            Advertisement.Initialize(gameId);
        }
    
        public void OnUnityAdsReady (string placementId) {
            if(RewardVideoPlacementId == placementId)
                mEventManager.Send(EventKey.AdsReady);
            Log.Print(placementId + " 已准备就绪");
        }

        public void OnUnityAdsDidFinish (string placementId, ShowResult showResult) {
            if (showResult == ShowResult.Finished)
            {
                Tcs?.TrySetResult(true);
                mEventManager.Send(EventKey.AdsRewarded);
            } 
            else if (showResult == ShowResult.Skipped)
            {
                Tcs?.TrySetResult(false);
                mEventManager.Send(EventKey.AdsSkipped);
            } 
            else if (showResult == ShowResult.Failed)
            {
                Tcs?.TrySetResult(false);
                mEventManager.Send(EventKey.AdsFailed);
            }
        }

        public void OnUnityAdsDidError (string message)
        {
            Log.Error(message);
        }

        public void OnUnityAdsDidStart (string placementId) {
        }

        public void PlayRewardVideo()
        {
            if (!AdsKit.Inst.IsInitialized())
            {
                Log.Error("Ads 还未初始化");
                return;
            }
            else if (!AdsKit.Inst.IsReady(this.RewardVideoPlacementId))
            {
                Log.Error("广告还未准备好");
                return;
            }
            else if (!AdsKit.Inst.IsSupported())
            {
                Log.Error("Ads 不支持");
                return;
            }
            Advertisement.Show(RewardVideoPlacementId);
        }

        public async Task<bool> PlayRewardVideoAsync()
        {
            Tcs = new TaskCompletionSource<bool>();
            PlayRewardVideo();
            var result = await this.Tcs.Task;
            return result;
        }

        public void PlayVideo()
        {
            if (!AdsKit.Inst.IsInitialized())
            {
                Log.Error("Ads 还未初始化");
                return;
            }
            else if (!AdsKit.Inst.IsReady(this.VideoPlacementId))
            {
                Log.Error("广告还未准备好");
                return;
            }
            else if (!AdsKit.Inst.IsSupported())
            {
                Log.Error("Ads 不支持");
                return;
            }
            Advertisement.Show(VideoPlacementId);
        }

        public async Task<bool> PlayVideoAsync()
        {
            Tcs = new TaskCompletionSource<bool>();
            PlayVideo();
            var result = await this.Tcs.Task;
            return result;
        }

        public bool IsReady(string flag)
        {
            return Advertisement.IsReady(flag);
        }

        public bool IsSupported()
        {
            return Advertisement.isSupported;
        }

        public bool IsInitialized()
        {
            return Advertisement.isInitialized;
        }
    }
#endif
}
