using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Panthea.NativePlugins.Ads
{
    public interface IAdsHandler
    {
        void PlayRewardVideo();
        Task<(bool result,IAdsHandler handler)> PlayRewardVideoAsync();
        void PlayVideo();
        Task<(bool result,IAdsHandler handler)> PlayVideoAsync();
        bool IsReady(AdsFlag flag);
        bool IsSupported();
        bool IsInitialized();
    }
}