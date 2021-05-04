namespace ET
{
    public class Manager2G_SafeShutdownHandler : AMActorHandler<Scene,Manager2G_SafeShutdown>
    {
        protected override async ETTask Run(Scene entity, Manager2G_SafeShutdown message)
        {
            Game.FrameFinishCallback.Add(() =>
            {
                TimerComponent.Instance.Dispose();
                entity.Dispose();
                Log.Error("安全关闭");
            });
            await ETTask.CompletedTask;
        }
    }
}