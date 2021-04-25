

using System;
using System.IO;
using System.Net;
using Agones;
using ET.ThirdParty;
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
            if (Game.Options.Develop != 1)
            {
                var agones = new AgonesSDK();
                Log.Info("Connecting to the SDK Server...");
                bool ok = false;
                try
                {
                    ok = await agones.ConnectAsync();
                    if (ok == false)
                        throw new Exception("Ok == false");
                }
                catch(Exception e)
                {
                    Log.Error(e);
                    Log.Info("初始化服务器失败");
                    Environment.Exit(0);
                    return;
                }
                Log.Info("...Connected to SDK Server");
                var status = await agones.ReadyAsync();
                Log.Info(status.Detail);
                Game.Scene.AddComponent<AgonesComponent, AgonesSDK>(agones);
            }
        }
    }
}