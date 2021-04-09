using System;

namespace ET
{
    [MessageHandler]
    public class C2G_SafeShutdownHandler : AMRpcHandler<C2G_SafeShutdown,G2C_SafeShutdown>
    {
        protected override async ETTask Run(Session session, C2G_SafeShutdown request, G2C_SafeShutdown response, Action reply)
        {
            var kcp = session.DomainScene().GetComponent<NetKcpComponent>();
            kcp.Dispose();
            reply();
            await ETTask.CompletedTask;
        }
    }
}