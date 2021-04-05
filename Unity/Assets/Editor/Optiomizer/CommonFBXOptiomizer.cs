using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class CommonFBXOptiomizer
{
    [MenuItem("Assets/减少包体大小/压缩FBX")]
    public static void Init()
    {
        var objects = Selection.GetFiltered<GameObject>(SelectionMode.Assets);
        AssetDatabase.StartAssetEditing();
        foreach (var node in objects)
        {
            var path = AssetDatabase.GetAssetPath(node);
            var modelImpoter = (ModelImporter) AssetImporter.GetAtPath(path);
            if (modelImpoter == null)
            {
                continue;
            }

            if (modelImpoter.animationCompression != ModelImporterAnimationCompression.Optimal)
            {
                modelImpoter.animationCompression = ModelImporterAnimationCompression.Optimal;
                modelImpoter.SaveAndReimport();
            }
        }

        AssetDatabase.StopAssetEditing();
        AssetDatabase.StartAssetEditing();
        foreach (var node in objects)
        {
            var path = AssetDatabase.GetAssetPath(node);
            ExtractAnimationClip(path);
        }

        AssetDatabase.StopAssetEditing();
    }

    public static List<AnimationClip> ExtractAnimationClip(string path, string to = "", bool compress = true)
    {
        var list = new List<AnimationClip>();
        var assets = AssetDatabase.LoadAllAssetsAtPath(path);
        foreach (var anim in assets)
        {
            if (anim is AnimationClip)
            {
                AnimationClip destClip;
                bool needCreate = false;
                AnimationClip sourceClip = (AnimationClip) anim;
                if (sourceClip != null && !sourceClip.name.Contains("__preview__"))
                {
                    var dir = Path.GetDirectoryName(path);
                    try
                    {
                        string destPath = null;
                        if (string.IsNullOrEmpty(to))
                        {
                            destPath = dir + "/" + sourceClip.name.ToLower() + ".anim";
                        }
                        else
                        {
                            destPath = to + sourceClip.name.ToLower() + ".anim";
                        }

                        DirectoryInfo dirInfo = new DirectoryInfo(destPath).Parent;
                        if (dirInfo != null && !dirInfo.Exists)
                        {
                            dirInfo.Create();
                        }

                        destClip = AssetDatabase.LoadAssetAtPath<AnimationClip>(destPath);
                        if (destClip == null)
                        {
                            needCreate = true;
                            destClip = new AnimationClip();
                        }

                        if (needCreate)
                        {
                            AssetDatabase.CreateAsset(destClip, destPath);
                        }
                        else
                        {
                            EditorUtility.CopySerialized(sourceClip, destClip);
                        }

                        if (compress)
                        {
                            CompressAnimation(destClip);
                        }
                    }
                    catch (Exception e)
                    {
                        Debug.LogError(e);
                        continue;
                    }

                    list.Add(destClip);
                }
            }
        }

        return list;
    }

    public static void CompressAnimation(AnimationClip theAnimation)
    {
        //浮点数精度压缩到f3
        AnimationClipCurveData[] curves = null;
        curves = AnimationUtility.GetAllCurves(theAnimation);
        Keyframe key;
        Keyframe[] keyFrames;
        for (int ii = 0; ii < curves.Length; ++ii)
        {
            AnimationClipCurveData curveDate = curves[ii];
            if (curveDate.curve == null || curveDate.curve.keys == null)
            {
                continue;
            }

            keyFrames = curveDate.curve.keys;
            for (int i = 0; i < keyFrames.Length; i++)
            {
                key = keyFrames[i];
                key.value = float.Parse(key.value.ToString("f3"));
                key.inTangent = float.Parse(key.inTangent.ToString("f3"));
                key.outTangent = float.Parse(key.outTangent.ToString("f3"));
                keyFrames[i] = key;
            }

            curveDate.curve.keys = keyFrames;
            theAnimation.SetCurve(curveDate.path, curveDate.type, curveDate.propertyName, curveDate.curve);
        }
    }
}