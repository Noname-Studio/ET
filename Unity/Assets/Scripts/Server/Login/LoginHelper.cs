using System;
using Cysharp.Threading.Tasks;
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
                using (Session session = zoneScene.GetComponent<NetKcpComponent>().Create(NetworkHelper.ToIPEndPoint(address)))
                {
                    if (!Application.isEditor)
                        return;
                    r2CLogin = (R2C_Login) await session.Call(new C2R_Login()
                    {
                        AccessToken = SystemInfo.deviceUniqueIdentifier + Application.dataPath, LoginType = (int) LoginType.None
                    });
                }
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
                Session gateSession = zoneScene.GetComponent<NetKcpComponent>().Create(NetworkHelper.ToIPEndPoint("82.156.218.129:7001"));
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