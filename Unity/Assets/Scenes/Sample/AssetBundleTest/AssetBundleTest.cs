using Panthea.Asset;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 
/// </summary>
public class AssetBundleTest: MonoBehaviour
{
    public Button LoadAsset;
    public Button UnloadAsset;
    public Button FetchDownloadList;
    public Button UpdateAssetBundle;

    private Texture tex;

    private AssetsManager assetsManager;
    /*async void Start()
    {
        //声明一个依赖注入框架
        var container = new DiContainer(StaticContext.Container);
        //绑定下载的保存路径
        container.BindInstance(AssetsConfig.AssetBundlePersistentDataPath + "/").WithId("SavePath");
        //绑定下载工具
        container.Bind<IDownloadHandler>().To<UnityWebDownloader>().AsSingle();
        //创建AssetManager,如果编辑器下面可以使用EDITOR_AssetManager.这个使用AssetDatabase加载资源.在编辑器下可以不需要打包,从而快速测试.
        assetsManager = container.Instantiate<AssetsManager>();
        //绑定接口
        container.Bind<IAssetsLocator>().FromInstance(assetsManager).AsSingle();
        //注册下载服务器
        assetsManager.Register<S3Download>("public/game_res/assetbundle/TestNewSystem/");

        
        UpdateAssetBundle.onClick.AddListener(UpdateAssetBundleCallback);
        FetchDownloadList.onClick.AddListener(FetchDownloadListCallback);
        UnloadAsset.onClick.AddListener(UnloadAssetCallback);
        LoadAsset.onClick.AddListener(LoadAssetCallback);
    }

    private async void LoadAssetCallback()
    {
        Stopwatch sw = Stopwatch.StartNew();
        tex = await assetsManager.Load<Texture>("image/food/breakfast/tex_asparagus_omelette");
        Debug.LogError("完成加载,返回" + tex + "    花费时间:" + sw.Elapsed);
    }

    private void UnloadAssetCallback()
    {
        assetsManager.ReleaseInstance(tex);
        Debug.Log("卸载资源");
    }

    private async void FetchDownloadListCallback()
    {
        var downloadList = await assetsManager.FetchDownloadList();
        Debug.Log("获取到服务器下载列表");
        foreach (var node in downloadList)
        {
            Debug.Log("需要下载:" + node.Path);
        }
    }

    private async void UpdateAssetBundleCallback()
    {
        var downloadList = await assetsManager.FetchDownloadList();
        Debug.Log("正在下载资源");
        assetsManager.Download(downloadList);
    }

#if UNITY_EDITOR
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    static void EDITOR_Reset()
    {
        StaticContext.Container.UnbindAll();
    }
#endif*/
}