using System;
using Agones;

namespace ET.ThirdParty
{
    public class AgonesComponent : Entity
    {
        public AgonesSDK SDK { get; set; }
        public long HealthId { get; set; }
        public async void HealthCheck()
        {
            Log.Info("发送心跳包");
            try
            {
                var status = await SDK.HealthAsync();
                Log.Error(status.Detail + "\n" + status.StatusCode + "\n" + status.DebugException + "\n" + status.ToString());
            }
            catch(Exception e)
            {
                Log.Error("报错：" + e);
            }
        }
    }
}