using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Kitchen;
using Panthea.Asset;
using RestaurantPreview.Config;
using UnityEngine;

public class NormalKitchenMode: IKitchenMode
{
    private LevelProperty LevelProperty { get; }
    private KitchenRoot KRoot { get; set; }
    private HashSet<string> UsedProp { get; }
    public NormalKitchenMode(LevelProperty property, HashSet<string> usedProp)
    {
        LevelProperty = property;
        UsedProp = usedProp;
    }

    public async UniTask Enter()
    {
        try
        {
            KRoot = new KitchenRoot(LevelProperty,UsedProp);
        }
        catch (Exception e)
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
        catch (Exception e)
        {
            Debug.LogError("从厨房场景退出时发生错误,检查一下错误内容\n" + e);
        }
        UIKit.Inst.UnLoadAllUI();
        return UniTask.CompletedTask;
    }
}