using System;
using Cysharp.Threading.Tasks;
using Kitchen;
using Panthea.Asset;
using UnityEngine;

public class NormalKitchenMode : IKitchenMode
{
    private LevelProperty LevelProperty { get; }
    private KitchenRoot KRoot { get; set; }
    public NormalKitchenMode(LevelProperty property)
    {
        LevelProperty = property;
    }
    
    public async UniTask Enter()
    {
        try
        {
            //加载后厨全局配置表
            var config = await AssetsKit.Inst.Load<KitchenConfigProperty>("Config/Kitchen/KitchenConfig");
            KRoot = new KitchenRoot(LevelProperty, config);
        }
        catch(Exception e)
        {
            Debug.LogError("切换到厨房场景发生错误，检查一下错误内容\n" + e);
        }
    }

    public UniTask Exit()
    {
        try
        {
            KRoot.Dispose();
        }
        catch(Exception e)
        {
            Debug.LogError("从厨房场景退出时发生错误,检查一下错误内容\n" + e);
        }
        return UniTask.CompletedTask;
    }
}
