using System;

namespace ET
{
    [MessageHandler]
    public class C2G_SafeShutdownHandler : AMHandler<C2G_SafeShutdown>
    {
        protected override async ETVoid Run(Session session, C2G_SafeShutdown request)
        {
            var scene = session.DomainScene();
            Game.FrameFinishCallback.Add(() =>
            {
                scene.Dispose();
                TimerComponent.Instance.Dispose();
                Log.Error("安全关闭");
            });
            await ETTask.CompletedTask;
        }
    }
}