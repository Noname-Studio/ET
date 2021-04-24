using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using GooglePlayGames;
using UnityEngine;
#if UNITY_IOS
using UnityEngine.SocialPlatforms.GameCenter;
#endif
namespace ET
{
    public enum LoginType
    {
        None = 0,
        Google = 1,
        GameCenter = 2,
    }
    //我们先通过Relam获取Gate服务器(即网关服务器)通过网关服务器.我们做登录验证.判断玩家的登录是否合法.然后我们在进入Map即逻辑服务器.
    public static class LoginHelper
    {
        public static async UniTask Login(Scene zoneScene, string address)
        {
            try
            {
                // 创建一个ETModel层的Session
                UniTaskCompletionSource<bool> tcs = new UniTaskCompletionSource<bool>();
                R2C_Login r2CLogin = null;
#if UNITY_ANDROID && !UNITY_EDITOR
                if (Social.Active is PlayGamesPlatform)
                {
                    var loginWithGoogleAccountRequest = new LoginWithGoogleAccountRequest()
                    {
                        TitleId = PlayFabSettings.TitleId,
                        ServerAuthCode = PlayGamesPlatform.Instance.GetServerAuthCode(),
                        CreateAccount = true
                    };
                    PlayFabClientAPI.LoginWithGoogleAccount(loginWithGoogleAccountRequest, result =>
                    {
                        Log.Error("Login Success");
                        var multiplayerServerRequest = new RequestMultiplayerServerRequest
                        {
                            SessionId = PlayFabGameBridge.GenerateSessionId(),
                            BuildId = PlayFabGameBridge.BuildId,
                            PreferredRegions = PlayFabGameBridge.Region
                        };
                        PlayFabMultiplayerAPI.RequestMultiplayerServer(multiplayerServerRequest, response =>
                        {
                            r2CLogin = new R2C_Login();
                            r2CLogin.Address = response.IPV4Address + ":" + response.Ports.Find(t1 => t1.Name == "Gate1").Num;
                            tcs.TrySetResult(true);
                        }, error =>
                        {
                            Log.Error(error.GenerateErrorReport());
                            tcs.TrySetResult(false);
                        });
                    }, result =>
                    {
                        Log.Error(result.GenerateErrorReport());
                        tcs.TrySetResult(false);
                    });
                }
                var result = await tcs.Task;
                if (!result)
                    return;
#elif UNITY_IOS && !UNITY_EDITOR
                if(Social.Active is GameCenterPlatform gameCenter)
                    r2CLogin = (R2C_Login) await session.Call(new C2R_Login() { AccessToken = "",LoginType = (int)LoginType.GameCenter});
#else

                /*var request = new LoginWithCustomIDRequest { CustomId = SystemInfo.deviceUniqueIdentifier, CreateAccount = true};
                PlayFabClientAPI.LoginWithCustomID(request, result =>
                {
                    Log.Error("Login Success");
                    var request = new RequestMultiplayerServerRequest
                    {
                        SessionId = PlayFabGameBridge.SessionId,
                        BuildId = PlayFabGameBridge.BuildId,
                        PreferredRegions = PlayFabGameBridge.Region
                    };
                    PlayFabMultiplayerAPI.RequestMultiplayerServer(request, response =>
                    {
                        r2CLogin = new R2C_Login();
                        r2CLogin.Address = response.IPV4Address + ":" + response.Ports.Find(t1 => t1.Name == "Gate1").Num;
                        Log.Error(response.ToJson());
                        tcs.TrySetResult(true);
                    }, error =>
                    {
                        Log.Error(error.GenerateErrorReport());
                        tcs.TrySetResult(false);
                    });
                }, result =>
                {
                    Log.Error(result.GenerateErrorReport());
                    tcs.TrySetResult(false);
                });
                var result = await tcs.Task;
                if (!result)
                    return;*/
                using (Session session = zoneScene.GetComponent<NetKcpComponent>().Create(NetworkHelper.ToIPEndPoint(address)))
                {
                    if (!Application.isEditor)
                        return;
                    r2CLogin = (R2C_Login) await session.Call(new C2R_Login()
                    {
                        AccessToken = SystemInfo.deviceUniqueIdentifier + Application.dataPath, LoginType = (int) LoginType.None
                    });
                }
#endif
                if (r2CLogin == null)
                    return;
                global::Log.Print("尝试登录Realm:" + r2CLogin.Address);

                using (Session session = zoneScene.GetComponent<NetKcpComponent>().Create(NetworkHelper.ToIPEndPoint(address)))
                {
                    if (!Application.isEditor)
                        return;
                    r2CLogin = (R2C_Login) await session.Call(new C2R_Login()
                    {
                        AccessToken = SystemInfo.deviceUniqueIdentifier + Application.dataPath, LoginType = (int) LoginType.None
                    });
                }
                global::Log.Print("尝试登录Gate:" + r2CLogin.Address);
                // 创建一个gate Session,并且保存到SessionComponent中
                Session gateSession = zoneScene.GetComponent<NetKcpComponent>().Create(NetworkHelper.ToIPEndPoint(r2CLogin.Address));
                gateSession.AddComponent<PingComponent>();
                var sessionCom = zoneScene.GetComponent<SessionComponent>();
                if (sessionCom == null)
                {
                    sessionCom = zoneScene.AddComponent<SessionComponent>();
                }
                sessionCom.Session = gateSession;
                G2C_LoginGate g2CLoginGate = (G2C_LoginGate) await gateSession.Call(
                    new C2G_LoginGate() { Key = r2CLogin.Key, GateId = r2CLogin.GateId });
                Log.Info("登陆gate成功!");
                G2C_EnterMap g2CEnterMap = await zoneScene.GetComponent<SessionComponent>().Session.Call(new C2G_EnterMap()) as G2C_EnterMap;

                //await Game.EventSystem.Publish(new EventType.LoginFinish() {ZoneScene = zoneScene});
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
    }
}