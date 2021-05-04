namespace ET
{
    public class Manager2G_ReloadHandler : AMActorHandler<Scene,Manager2G_Reload>
    {
        protected override async ETTask Run(Scene entity, Manager2G_Reload message)
        {
            Game.EventSystem.Add(DllHelper.GetHotfixAssembly());
            Log.Debug("完成热更新");
            await ETTask.CompletedTask;
        }
    }
}