using System;
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
                R2C_Login r2CLogin;
                using (Session session = zoneScene.GetComponent<NetKcpComponent>().Create(NetworkHelper.ToIPEndPoint(address)))
                {
                    if (Social.Active is PlayGamesPlatform google)
                    {
                        Log.Error(google.GetIdToken());
                        r2CLogin = (R2C_Login) await session.Call(new C2R_Login()
                        {
                            AccessToken = google.GetIdToken(), LoginType = (int) LoginType.Google
                        });
                    }
#if UNITY_IOS
                    else if(Social.Active is GameCenterPlatform gameCenter)
                        r2CLogin = (R2C_Login) await session.Call(new C2R_Login() { AccessToken = "",LoginType = (int)LoginType.GameCenter});
#endif
                    else
                    {
                        r2CLogin = (R2C_Login) await session.Call(new C2R_Login()
                        {
                            AccessToken = SystemInfo.deviceUniqueIdentifier, LoginType = (int) LoginType.None
                        });
                    }
                }

                // 创建一个gate Session,并且保存到SessionComponent中
                Session gateSession = zoneScene.GetComponent<NetKcpComponent>().Create(NetworkHelper.ToIPEndPoint(r2CLogin.Address));
                gateSession.AddComponent<PingComponent>();
                zoneScene.AddComponent<SessionComponent>().Session = gateSession;

                G2C_LoginGate g2CLoginGate = (G2C_LoginGate) await gateSession.Call(
                    new C2G_LoginGate() { Key = r2CLogin.Key, GateId = r2CLogin.GateId });
                Log.Info("登陆gate成功!");
                MessageDispatcherComponent.Instance.Handle(gateSession, OuterOpcode.G2C_LoginGate, g2CLoginGate);
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