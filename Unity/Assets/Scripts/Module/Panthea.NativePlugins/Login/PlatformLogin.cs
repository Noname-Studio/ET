using System.Threading.Tasks;
#if UNITY_ANDROID
using GooglePlayGames;
using GooglePlayGames.BasicApi;
#endif
using Panthea.NativePlugins.Analytics;
using UnityEngine;
using UnityEngine.Analytics;
#if UNITY_IOS
using UnityEngine.SocialPlatforms.GameCenter;
#endif
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
            Social.localUser.Authenticate((success,msg) =>
            {
                if (success)
                {
                    Log.Print("登录平台成功" + PlayGamesPlatform.Instance.GetUserId());
#if UNITY_ANDROID
                    AnalyticsKit.Inst.UserSignup(AuthorizationNetwork.Google);
                    PlayGamesPlatform.Instance.GetServerAuthCode();
                    
#elif UNITY_IOS
                    AnalyticsKit.Inst.UserSignup(AuthorizationNetwork.GameCenter);
#endif
                    tcs.SetResult(true);
                }
                else
                {
                    Log.Print("登录失败,原因:" + msg);
                    tcs.SetResult(false);
                }
            });
            await tcs.Task;
            if (!tcs.Task.Result)
            {
                if (i <= 3)
                {
                    await Login(++i);
                }
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