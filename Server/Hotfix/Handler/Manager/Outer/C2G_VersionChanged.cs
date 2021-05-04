namespace ET
{
    [MessageHandler]
    public class C2G_VersionChanged : AMHandler<C2G_ChangeVersion>
    {
        protected override async ETVoid Run(Session session, C2G_ChangeVersion message)
        {
            if (session.DomainScene().SceneType != SceneType.Manager)
                return;
            var processScenes = StartSceneConfigCategory.Instance.GetAll();
            foreach (var startConfig in processScenes.Values)
            {
                if (startConfig.Type == SceneType.Gate)
                {
                    ActorMessageSenderComponent.Instance.Send(
                        StartSceneConfigCategory.Instance.GetBySceneName(startConfig.Zone, startConfig.Name).SceneId, new Manager2G_VersionChanged());
                }
            }
            await ETTask.CompletedTask;
        }
    }
}