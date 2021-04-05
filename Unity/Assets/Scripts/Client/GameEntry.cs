using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Manager;
using Client.UI.ViewModel;
using Config.ConfigCore;
using Cysharp.Threading.Tasks;
using ET;
using FairyGUI;
using Panthea.Asset;
using Panthea.NativePlugins;
using RestaurantPreview.Config;
#if UNITY_ANDROID || UNITY_IOS
using NotificationSamples;
using Panthea.NativePlugins.Ads;
using Panthea.NativePlugins.Notify;
#endif
using UnityEngine;
using UnityEngine.LowLevel;
using UnityEngine.Rendering.Universal;
using Object = UnityEngine.Object;
using Stage = FairyGUI.Stage;

public class GameEntry: MonoBehaviour
{
    public static GameEntry inst;

    private void Start()
    {
        inst = this;
        //Todo 先放在这里
        {
            if (Application.isEditor)
            {
                Application.runInBackground = true;
            }

            Application.targetFrameRate = 60;
            GRoot.inst.SetContentScaleFactor(UIGlobalConfig.UIDesignX, UIGlobalConfig.UIDesignY, UIContentScaler.ScreenMatchMode.MatchWidthOrHeight);
            Screen.sleepTimeout = SleepTimeout.NeverSleep; // 常亮
            DontDestroyOnLoad(StageCamera.main.gameObject);
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(Camera.main.gameObject);
        }
        DoProcess().Forget();
    }

    private async UniTaskVoid DoProcess()
    {
        RegisterUniTaskModule();
        RegisterUpdateModule();
        RegisterAssetBundleModule();
        RegisterAds();
        RegisterNotify();
        await RegisterGameConfigure();
        await RegisterUIModule();
        RegisterNetworkModule();
        await RegisterDatabaseSaveSystem();
        //开始游戏
        await UniTask.SwitchToMainThread();

        UIKit.Inst.Create<UI_FirstGameLoading>();
    }

    /// <summary>
    /// 初始化UniTask
    /// </summary>
    private void RegisterUniTaskModule()
    {
        var loop = PlayerLoop.GetCurrentPlayerLoop();
        PlayerLoopHelper.Initialize(ref loop);
    }

    /// <summary>
    /// 注册Update模块
    /// </summary>
    private void RegisterUpdateModule()
    {
        var go = new GameObject("Unity Behaviour");
        var component = go.AddComponent<UnityBehaviour>();
        UnityLifeCycleKit.Inst = component;
    }

    /// <summary>
    /// 注册UI模块
    /// </summary>
    private async UniTask RegisterUIModule()
    {
        var manager = new UIManager();
        await manager.Init();
        UIKit.Inst = manager;
        var camera = Stage.inst.GetRenderCamera().GetUniversalAdditionalCameraData();
        camera.renderType = CameraRenderType.Overlay;
    }
    
    
    /// <summary>
    /// 注册资源加载模块
    /// </summary>
    private void RegisterAssetBundleModule()
    {
        if (GameConfig.MobileRuntime)
        {
            //注册文件跟踪,正式版本中可能包体内和包体外都会存在AB.我们需要跟踪确认使用哪个路径下的AB
            var fileTrack = new ABFileTrack();
            //注册AssetBundle加载缓存池.加载过的物体会在池中缓存起来.不需要缓存的话取消这个注册就好
            var pool = new AssetBundlePool(fileTrack);
            //注册AssetBundle的引用计数器.当引用计数清零时自动卸载AB
            var counter = new AssetBundleCounter(pool);
            //注册运行时加载AB的支持模块
            var runtime = new AssetBundleRuntime(fileTrack, pool, counter);
            //注册需要使用的下载工具
            var downloader = new UnityWebDownloader();
            //注册确切使用的下载服务器
            var downloadPlatform = new S3Download("public/game_res/assetbundle/TestNewSystem/",
                AssetsConfig.AssetBundlePersistentDataPath + "/", downloader);
            //使AssetsManager支持下载功能(只是注册S3Download只是注册了服务,但是并没有开启下载功能)
            var abDownloader = new AssetBundleDownloader(fileTrack, downloadPlatform);

            fileTrack.ConfigureDownloadPlatform(downloadPlatform);
            //创建AssetManager,AssetManager可以理解为底层接口的一层包装
            var assetsManager = new AssetsManager(fileTrack, runtime, abDownloader);
            AssetsKit.Inst = assetsManager;
        }
        else
        {
#if UNITY_EDITOR
            //如果编辑器下面可以使用EDITOR_AssetManager.这个使用AssetDatabase加载资源.在编辑器下可以不需要打包,从而快速测试.
            var assetsManager = new EDITOR_AssetsManager();
            AssetsKit.Inst = assetsManager;
#endif
        }
    }

    /// <summary>
    /// 注册网络加载模块
    /// </summary>
    private async Task RegisterNetworkModule()
    {
#if !UNITY_EDITOR
            await PlatformLogin.Login(); //连接GooglePlay & GameCenter
            if(Social.Active.localUser.authenticated)
#endif
        await NetworkManager.Inst.Connect(); //连接服务器
    }

    /// <summary>
    /// 注册游戏数据表
    /// </summary>
    /// <returns></returns>
    private async UniTask RegisterGameConfigure()
    {
        var tasks = new List<UniTask>
        {
            //ConfigAssetManager<ItemProperty>.Load(assetsManager, "DB/Item"),
            ConfigAssetManager<LocalizationProperty>.Load("Config/Restaurant/Localization"),
            ConfigAssetManager<GuildIconProperty>.Load("Config/Restaurant/GuildIcon"),
            ConfigAssetManager<GlobalConfigProperty>.Load("Config/Restaurant/GlobalConfig"),
            ConfigAssetManager<PropProperty>.Load("Config/Restaurant/Prop"),
            ConfigAssetManager<StandaloneKitchenConfigProperty>.Load("Config/Kitchen/StandaloneKitchenConfig")

        };
        await UniTask.WhenAll(tasks);
    }

    /// <summary>
    /// 注册Ads模块
    /// </summary>
    private void RegisterAds()
    {
#if UNITY_IOS || UNITY_ANDROID
        AdsKit.Initialize(new UnityAds());
#endif
    }

    /// <summary>
    /// 注册消息推送模块
    /// </summary>
    private void RegisterNotify()
    {
#if UNITY_ANDROID || UNITY_IOS
        const string ChannelId = "RestaurantTest";
        var manager = gameObject.AddComponent<GameNotificationsManager>();
        manager.Mode = GameNotificationsManager.OperatingMode.QueueClearAndReschedule;
        var channel = new GameNotificationChannel(ChannelId, "Default Game Channel", "Generic notifications");
        manager.Initialize(channel);
        var nativeNotify = new NativeNotify(manager);
        NotificationKit.Initialize(nativeNotify);
#endif
    }

    /// <summary>
    /// 注册存档系统
    /// </summary>
    private async UniTask RegisterDatabaseSaveSystem()
    {
        var manager = DBManager.Inst;
    }
}