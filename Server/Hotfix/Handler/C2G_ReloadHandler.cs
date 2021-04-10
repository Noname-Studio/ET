using System;

namespace ET
{
    public class C2G_ReloadHandler : AMRpcHandler<C2G_Reload,G2C_Reload>
    {
        protected override async ETTask Run(Session session, C2G_Reload request, G2C_Reload response, Action reply)
        {
            Game.EventSystem.Add(DllHelper.GetHotfixAssembly());
            reply();
            Log.Debug("完成热更新");
            await ETTask.CompletedTask;
        }
    }
}