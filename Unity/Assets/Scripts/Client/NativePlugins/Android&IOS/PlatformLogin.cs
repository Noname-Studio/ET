using System.Threading.Tasks;
using UnityEngine;
//using UnityEngine.Analytics;

public class PlatformLogin
{
    public async Task Init(int i = 0)
    {
        TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
        Social.localUser.Authenticate(success =>
        {
            if (success)
            {
                Log.Print("登录平台成功");
                #if UNITY_ANDROID
                //AnalyticsEvent.UserSignup(AuthorizationNetwork.Google);
                #elif UNITY_IOS
                //AnalyticsEvent.UserSignup(AuthorizationNetwork.GameCenter);
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
                await Init(++i);
            else
            {
                Log.Error("登录平台失败");
            }
        }
    }
}
