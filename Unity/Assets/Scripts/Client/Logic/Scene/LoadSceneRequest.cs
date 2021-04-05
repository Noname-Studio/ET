using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Panthea.Asset;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneRequest
{
    public async UniTask<bool> Load(SceneKey scene, ISceneLoading preScene, IProgress<float> progress = null, ISceneLoadData data = null)
    {
        try
        {
            var activeScene = SceneManager.GetActiveScene();
            var newScene = (ISceneLoading) Activator.CreateInstance(scene.LoadType, data);

            //注入参数
            newScene.InjectParamters(data);

            //加载这个场景需要的资源
            var needLoadRes = PreparedResources(newScene);

            var loadedAssetBundle = AssetsKit.Inst.GetLoadedAssetBundle();

            //如果这个场景需要加载的资源,上一个场景加载过了.我们这里就不卸载了
            foreach (var node in needLoadRes)
            {
                loadedAssetBundle.Remove(node);
            }

            //卸载上一个场景
            await Release(preScene);

            //释放上一个场景加载的资源
            ReleaseRes(new List<string>(loadedAssetBundle.Keys));

            await LoadRes(needLoadRes);

            //清理完了所有内容之后我们触发一次GC.
            GC.Collect();

            //加载场景
            await LoadScene(scene);

            await SceneManager.UnloadSceneAsync(activeScene);
            UIKit.Inst.UnLoadAllUI();

            SceneManager.SetActiveScene(SceneManager.GetSceneByName(scene.Key));
            await LoadedHandler(newScene);
            //清理一下内存
#if UNITY_EDITOR && !REALGAME
            GC.Collect();
#else
            Resources.UnloadUnusedAssets();
#endif
            Log.Error("加载场景内容结束");
            if (progress != null)
            {
                progress.Report(1);
            }

            return true;
        }
        catch (Exception e)
        {
            Log.Error($"切换场景发生严重错误\n{e}");
            return false;
        }
    }

    /// <summary>
    ///     加载场景后处理
    /// </summary>
    /// <param name="core"></param>
    /// <param name="scheduled"></param>
    /// <returns></returns>
    private static async UniTask LoadedHandler(ISceneLoading core)
    {
        if (core != null)
        {
            await core.Run();
        }
    }

    /// <summary>
    ///     加载资源
    /// </summary>
    /// <param name="core"></param>
    /// <param name="scheduled"></param>
    /// <returns></returns>
    private static List<string> PreparedResources(ISceneLoading core)
    {
        return core?.PreparedResources();
    }

    /// <summary>
    ///     释放资源
    /// </summary>
    /// <param name="scheduledNotifier"></param>
    /// <returns></returns>
    private static async UniTask Release(ISceneLoading preScene)
    {
        if (preScene != null)
        {
            await preScene.Release();
        }
    }

    private static async UniTask LoadRes(List<string> abPaths)
    {
        List<UniTask> uniTasks = new List<UniTask>();
        foreach (var node in abPaths)
        {
            uniTasks.Add(AssetsKit.Inst.LoadAssetBundle(node));
        }

        UniTask.WhenAll(uniTasks);
    }

    private static void ReleaseRes(List<string> abPaths)
    {
        foreach (var node in abPaths)
        {
            AssetsKit.Inst.ReleaseAssetBundle(node);
        }
    }

    /// <summary>
    ///     加载场景
    /// </summary>
    /// <param name="scene"></param>
    /// <param name="scheduled"></param>
    /// <returns></returns>
    private async UniTask LoadScene(SceneKey scene)
    {
        await SceneManager.LoadSceneAsync(scene.Index, LoadSceneMode.Additive);
    }
}