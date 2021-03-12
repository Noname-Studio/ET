using System;
using Panthea.Asset;
using UnityEngine;

namespace ET
{
    public class AppStart_Init: AEvent<EventType.AppStart>
    {
        protected override async ETTask Run(EventType.AppStart args)
        {
            try
            {
                Game.Scene.AddComponent<TimerComponent>();
                Game.Scene.AddComponent<CoroutineLockComponent>();

                // 下载ab包
                //await BundleHelper.DownloadBundle("1111");

                // 加载配置
                await AssetsKit.Inst.LoadAll("Config/Server" + AssetsConfig.Suffix);
                Game.Scene.AddComponent<ConfigComponent>();
                ConfigComponent.GetAllConfigBytes = LoadConfigHelper.LoadAllConfigBytes;
                await ConfigComponent.Instance.LoadAsync();
                AssetsKit.Inst.ReleaseAssetBundleFromABKey("Config/Server" + AssetsConfig.Suffix);

                Game.Scene.AddComponent<OpcodeTypeComponent>();
                Game.Scene.AddComponent<MessageDispatcherComponent>();
                //Game.Scene.AddComponent<UIEventComponent>();
                Game.Scene.AddComponent<NetThreadComponent>();

                Scene zoneScene = await SceneFactory.CreateZoneScene(1, 1, "Game");

                //await Game.EventSystem.Publish(new EventType.AppStartInitFinish() { ZoneScene = zoneScene });
            }
            catch(Exception e)
            {
                Debug.Log(e);
            }

        }
    }
}
