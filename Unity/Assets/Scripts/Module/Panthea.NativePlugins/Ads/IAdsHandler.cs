using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Panthea.NativePlugins.Ads
{
    public interface IAdsHandler
    {
        void PlayRewardVideo();
        Task<bool> PlayRewardVideoAsync();
        void PlayVideo();
        Task<bool> PlayVideoAsync();
        bool IsReady(string flag);
        bool IsSupported();
        bool IsInitialized();
    }
}