#if UNITY_ANDROID || UNITY_IOS
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class GoogleAndAppleAds : IUnityAdsListener,IAdsHandler
{
#if UNITY_IOS
    private string gameId = "1486551";
#elif UNITY_ANDROID
    private string gameId = "1486550";
#endif
    private string RewardVideoPlacementId = "rewardedVideo";
    private MessageKit mEventManager;
    public GoogleAndAppleAds()
    {
        mEventManager = MessageKit.Inst;
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId);
    }
    
    public void OnUnityAdsReady (string placementId) {
        if(RewardVideoPlacementId == placementId)
            mEventManager.Send(EventKey.AdsReady);
    }

    public void OnUnityAdsDidFinish (string placementId, ShowResult showResult) {
        if (showResult == ShowResult.Finished)
        {
            mEventManager.Send(EventKey.AdsRewarded);
        } 
        else if (showResult == ShowResult.Skipped)
        {
            mEventManager.Send(EventKey.AdsSkipped);
        } 
        else if (showResult == ShowResult.Failed)
        {
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
        Advertisement.Show(RewardVideoPlacementId);
    }
}
#endif