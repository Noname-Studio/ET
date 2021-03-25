using System.Threading.Tasks;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using Panthea.NativePlugins.Analytics;
using UnityEngine;
using UnityEngine.Analytics;

namespace Panthea.NativePlugins
{
    public class PlatformLogin
    {
        public static async Task<bool> Login()
        {
            return await Login(0);
        }
        
        private static async Task<bool> Login(int i)
        {
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
#if UNITY_ANDROID
            PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
                    .EnableSavedGames()
                    .RequestEmail()
                    .RequestServerAuthCode(false)
                    .RequestIdToken()
                    .Build();

            PlayGamesPlatform.InitializeInstance(config);
#if DEVELOPMENT_BUILD
        PlayGamesPlatform.DebugLogEnabled = true;
#endif
            PlayGamesPlatform.Activate();
#endif
            Social.localUser.Authenticate(success =>
            {
                if (success)
                {
                    Log.Print("登录平台成功");
                    #if UNITY_ANDROID
                    AnalyticsKit.Inst.UserSignup(AuthorizationNetwork.Google);
                    #elif UNITY_IOS
                    AnalyticsKit.Inst.UserSignup(AuthorizationNetwork.GameCenter);
                    #endif
                    tcs.SetResult(true);
                }
                else
                {
                    tcs.SetResult(false);
                }
            });
            await tcs.Task;
            if (!tcs.Task.Result )
            {
                if(i <= 3)
                    await Login(++i);
                else
                {
                    Log.Error("登录平台失败");
                    return false;
                }
            }
            return true;
        }
    }
}

