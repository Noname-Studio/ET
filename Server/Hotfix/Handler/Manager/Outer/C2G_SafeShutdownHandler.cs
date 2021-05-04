using System;

namespace ET
{
    [MessageHandler]
    public class C2G_SafeShutdownHandler : AMHandler<C2G_SafeShutdown>
    {
        protected override async ETVoid Run(Session session, C2G_SafeShutdown request)
        {
            if (session.DomainScene().SceneType != SceneType.Manager)
                return;
            var processScenes = StartSceneConfigCategory.Instance.GetAll();
            foreach (var startConfig in processScenes.Values)
            {
                if (startConfig.Type == SceneType.Gate)
                {
                    ActorMessageSenderComponent.Instance.Send(
                        StartSceneConfigCategory.Instance.GetBySceneName(startConfig.Zone, startConfig.Name).SceneId, new Manager2G_SafeShutdown());
                }
            }
            await ETTask.CompletedTask;
        }
    }
}