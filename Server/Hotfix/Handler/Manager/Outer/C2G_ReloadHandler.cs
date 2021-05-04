using System;

namespace ET
{
    [ActorMessageHandler]
    public class C2G_ReloadHandler : AMHandler<C2G_Reload>
    {
        protected override async ETVoid Run(Session session, C2G_Reload request)
        {
            if (session.DomainScene().SceneType != SceneType.Manager)
                return;
            var processScenes = StartSceneConfigCategory.Instance.GetAll();
            foreach (var startConfig in processScenes.Values)
            {
                if (startConfig.Type == SceneType.Gate)
                {
                    ActorMessageSenderComponent.Instance.Send(
                        StartSceneConfigCategory.Instance.GetBySceneName(startConfig.Zone, startConfig.Name).SceneId, new Manager2G_Reload());
                }
            }
            await ETTask.CompletedTask;
        }
    }
}