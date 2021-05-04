using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEditor.Experimental;
using UnityEngine;

public class ReloadConfigAssetProcessor : AssetPostprocessor
{
    private static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
    {
        if (!Application.isPlaying)
            return;
        foreach (var node in importedAssets)
        {
            if (node.StartsWith("Assets/Res/Config/Client"))
            {
                Debug.Log("重新加载配置表");
                var method = typeof (GameEntry).GetMethod("RegisterGameConfigure", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
                method.Invoke(null, null);
                Debug.Log("重新加载配置表完成");
            }
        }
    }
}
