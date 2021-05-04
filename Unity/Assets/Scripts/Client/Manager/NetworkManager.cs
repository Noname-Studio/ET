using System;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using ET;
using Manager;
using UnityEngine;

namespace Client.Manager
{
    public class NetworkManager : Singleton<NetworkManager>
    {
        public bool IsConnect
        {
            get
            {
                if (Application.internetReachability == NetworkReachability.NotReachable)
                    return false;
                if (Session == null)
                    return false;
                if (Session.IsDisposed)
                    return false;
                return true;
            }
        }
        private bool Connecting { get; set; }
        private Session Session { get; set; }

        private NetworkManager(){}
        
        private string GateIP
        {
            get
            {
                return "82.156.218.129:7000";
                //return "192.168.0.105:7000";
            }
        }
        public void Init()
        {
            TryConnect().Forget();
        }

        private async UniTaskVoid TryConnect()
        {
            int tryCount = 0;
            while (tryCount < 3)
            {
                await UniTask.Delay(tryCount * 5);
                if (Application.internetReachability == NetworkReachability.NotReachable)
                {
                    continue;
                }
                await Connect();
                tryCount++;
            }
        }

        public async UniTask<bool> Connect()
        {
            if (IsConnect)
                return true;
            if (Connecting)
            {
                while (Connecting)
                {
                    await UniTask.NextFrame();
                }
                return IsConnect;
            }
            MessageKit.Inst.Send(EventKey.StartConnectToServer);
            Connecting = true;
            try
            {
                bool isSuccess = await ET.Init.StartNet();
                if (isSuccess)
                {
                    var scene = Game.Scene.Get(1).DomainScene();
                    await LoginHelper.Login(scene, GateIP);
                    Session = scene.GetComponent<SessionComponent>().Session;
                    Connecting = false;
                    MessageKit.Inst.Send(EventKey.ConnectionSucceeded);
                    return true;
                }
            }
            catch (Exception e)
            {
                Log.Error(e);
                MessageKit.Inst.Send(EventKey.ConnectionFailure);
            }
            finally
            {
                Connecting = false;
            }
            return false;
        }

        public async UniTask<IResponse> Call(IRequest request)
        {
            return await Internal_Call(request);
        }

        private async Task<IResponse> Internal_Call(IRequest request)
        {
            try
            {
                if (!IsConnect)
                {
                    Log.Print("未连接到服务器,正在尝试连接服务器");
                    bool success = await Connect();
                    if (!success)
                    {
                        Log.Print("尝试连接失败");
                        return null;
                    }
                }
                return await Session.Call(request);
            }
            catch (Exception e)
            {
                Log.Error(e);
                return null;
            }
        }

        public void Send(IRequest request)
        {
            InternalSend(request).Forget();
        }

        private async UniTaskVoid InternalSend(IRequest request)
        {
            if (!IsConnect)
            {
                Log.Print("未连接到服务器,正在尝试连接服务器");
                bool success = await Connect();
                if (!success)
                {
                    Log.Print("尝试连接失败");
                    return;
                }
            }

            Session.Send(request);
        }
    }
}