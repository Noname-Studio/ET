

using System.IO;
using System.Net;
using Google.Apis.Auth.OAuth2;

namespace ET
{
    public class AppStart_Init: AEvent<EventType.AppStart>
    {
        protected override async ETTask Run(EventType.AppStart args)
        {
            Game.Scene.AddComponent<ConfigComponent>();
            
            ConfigComponent.GetAllConfigBytes = LoadConfigHelper.LoadAllConfigBytes;
            await ConfigComponent.Instance.LoadAsync();

            StartProcessConfig processConfig = StartProcessConfigCategory.Instance.Get(Game.Options.Process);
            
            Game.Scene.AddComponent<TimerComponent>();
            var zoneConfig = StartZoneConfigCategory.Instance.Get(1);
            Game.Scene.AddComponent<DBComponent, string, string>(zoneConfig.DBConnection, zoneConfig.DBName);
            Game.Scene.AddComponent<OpcodeTypeComponent>();
            Game.Scene.AddComponent<MessageDispatcherComponent>();
            Game.Scene.AddComponent<CoroutineLockComponent>();
            // 发送普通actor消息
            Game.Scene.AddComponent<ActorMessageSenderComponent>();
            // 发送location actor消息
            Game.Scene.AddComponent<ActorLocationSenderComponent>();
            // 访问location server的组件
            Game.Scene.AddComponent<LocationProxyComponent>();
            Game.Scene.AddComponent<ActorMessageDispatcherComponent>();
            // 数值订阅组件
            Game.Scene.AddComponent<NumericWatcherComponent>();

            Game.Scene.AddComponent<NetThreadComponent>();
            Game.Scene.AddComponent<NetInnerComponent, IPEndPoint>(processConfig.InnerIPPort);
            
            var processScenes = StartSceneConfigCategory.Instance.GetByProcess(Game.Options.Process);
            foreach (StartSceneConfig startConfig in processScenes)
            {
                await SceneFactory.Create(Game.Scene, startConfig.SceneId, startConfig.Zone, startConfig.Name, startConfig.Type, startConfig);
            }

            if (GuildComponent.Instance != null)
            {
                TimerComponent.Instance.NewRepeatedTimer(/*1800000*/5000, GuildComponent.Instance.Update);
            }

            await GuildComponent.Instance.RegisterAllGuildToChat();
        }
    }
}