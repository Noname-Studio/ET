using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Panthea.Asset;

public class StoryLoadData: ISceneLoadData
{
    public RestaurantKey Rest;

    public StoryLoadData(RestaurantKey rest)
    {
        Rest = rest;
    }
}

public class StoryLoading: ISceneLoading
{
    public StoryLoadData Data;
    private IAssetsLocator mLocator;

    public StoryLoading(IAssetsLocator locator)
    {
        mLocator = locator;
    }

    public void InjectParamters(ISceneLoadData data)
    {
        if (data == null)
        {
            throw new Exception("SceneLoadData不能为空");
        }

        if (!(data is StoryLoadData))
        {
            throw new Exception("data 不是 StoryLoadData类型");
        }

        Data = (StoryLoadData) data;
    }

    public List<string> PreparedResources()
    {
        throw new NotImplementedException();
    }

    public List<string> ReleaseResources()
    {
        throw new NotImplementedException();
    }

    private async UniTask LoadAssetBundle(string path, List<AssetBundleRequest> assetBundles)
    {
        //加载场景AB
        assetBundles.Add(await mLocator.LoadAssetBundle(path));
    }

    public UniTask Run()
    {
        return UniTask.CompletedTask;
    }

    public UniTask Release()
    {
        throw new NotImplementedException();
    }

    public async UniTask GenerateScene()
    {
        var oldSceneBundleCollect = mLocator.GetFilterAssetBundle(new[] { $"Model/Story/{Data.Rest}_0" });
        List<AssetBundleRequest> assetBundles = new List<AssetBundleRequest>();
        List<UniTask> tasksQueue = new List<UniTask>();
        foreach (var node in oldSceneBundleCollect)
        {
            var task = LoadAssetBundle(node, assetBundles);
            tasksQueue.Add(task);
        }

        await UniTask.WhenAll(tasksQueue);

        var dbFurniture = DBManager.Inst.GetFurnitureByKey(Data.Rest);
        foreach (var node in assetBundles)
        {
        }
    }
}