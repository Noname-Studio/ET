using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Panthea.Asset;
using UnityEngine;

public class PlayerCreationFactory
{
    public static async UniTask<UnityObject> CreateKitchenPlayer()
    {
        var obj = await AssetsKit.Inst.Instantiate("Model/Roles/Lisa/Lisa");
        obj.GetComponent<AnimatorControl>();
        return obj;
    }
}