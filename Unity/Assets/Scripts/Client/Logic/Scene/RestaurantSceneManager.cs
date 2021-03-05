using System;
using Cysharp.Threading.Tasks;

public class RestaurantSceneManager
{
    public ISceneLoading PreScene;

    private static RestaurantSceneManager mInst;
    public static RestaurantSceneManager Inst => mInst ?? (mInst = new RestaurantSceneManager());
    private RestaurantSceneManager(){}

    public async UniTask<bool> Load(SceneKey key,ISceneLoadData data=null,IProgress<float> progress = null)
    {
        var request = new LoadSceneRequest();
        var result = await request.Load(key,PreScene,progress,data);
        return result;
    }
}
