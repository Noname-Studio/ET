using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Pathfinding;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Rendering;
using Object = UnityEngine.Object;
using Path = System.IO.Path;

public class StorySceneFBXOptiomizer : Editor {
    public const string Prefix = "Assets/Art/Assetbundle/";

    [MenuItem("Assets/剧情场景专用/生成配置文件(FBX)")]
    public static void Go()
    {
        try
        {
            var selArray = Selection.objects;
            var fbxArray = new List<ModelImporter>();
            if (selArray == null || selArray.Length == 0)
                return;
            var selection = new List<Object>(selArray);
            var path = AssetDatabase.GetAssetPath(selection[0]);
            path = PathUtils.FormatFilePath(Path.GetDirectoryName(path));
            //把所有跨文件夹的GameObject全部移出列表(避免误操作导致对数据的破坏)
            for (var index = selection.Count - 1; index >= 0; index--)
            {
                var node = selection[index];
                var assetPath = AssetDatabase.GetAssetPath(node);
                ModelImporter importer = (ModelImporter)AssetImporter.GetAtPath(assetPath);
                if (importer == null)
                {
                    selection.RemoveAt(index);
                    continue;
                }
                
                var compare = PathUtils.FormatFilePath(Path.GetDirectoryName(assetPath));
                if (path != compare)
                {
                    selection.RemoveAt(index);
                    continue;
                }

                if (Path.GetExtension(assetPath).ToLower() != ".fbx")
                {
                    selection.RemoveAt(index);
                    continue;
                }

                fbxArray.Add(importer);
            }
            
            string prefabDir = path + "/Prefab/";
            string animationDir = path + "/__Combine_Animation/";
            string tempMatDir = path + "/__DP_Materials/";
            string textureDir = path + "/__DP_Texture/";
            string baseTextureDir = "Assets/Res/Model/Scene/";

            if (!Directory.Exists(animationDir))
                Directory.CreateDirectory(animationDir);
            
            if (!Directory.Exists(textureDir))
                Directory.CreateDirectory(textureDir);
            
            if (!Directory.Exists(tempMatDir))
                Directory.CreateDirectory(tempMatDir);
            
            if (!Directory.Exists(prefabDir))
                Directory.CreateDirectory(prefabDir);
            
            AssetDatabase.Refresh();

            AssetDatabase.StartAssetEditing();
            try
            {
                //设置部分功能
                foreach (var node in fbxArray)
                {
                    var importer = node;
                    importer.materialImportMode = ModelImporterMaterialImportMode.ImportStandard;
                    importer.animationType = ModelImporterAnimationType.Legacy;
                    importer.importAnimation = true;
                    importer.importBlendShapes = true;
                    importer.importCameras = false;
                    importer.importLights = false;
                    importer.importTangents = ModelImporterTangents.None;
                    importer.importNormals = ModelImporterNormals.None;
                    importer.importTangents = ModelImporterTangents.None;
                    importer.animationCompression = ModelImporterAnimationCompression.KeyframeReduction;
                    importer.animationPositionError = 1;
                    importer.animationRotationError = 1;
                    importer.animationScaleError = 1;
                    if (node.defaultClipAnimations.Length != 0)
                    {
                        foreach (var clip in node.defaultClipAnimations)
                        {
                            if (clip.name == "Take 001")
                            {
                                clip.takeName = clip.name = "refesh";
                                ModelImporterClipAnimation[] anim = new ModelImporterClipAnimation [1];
                                anim[0] = clip;
                                node.clipAnimations = anim;
                                break;
                            }
                        }
                    }
                    EditorUtility.SetDirty(importer);
                    importer.SaveAndReimport();
                }
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                return;
            }
            finally
            {
                AssetDatabase.StopAssetEditing();
            }
            try
            {
                AssetDatabase.StartAssetEditing();
                foreach (var node in fbxArray)
                {
                    string name = Path.GetFileNameWithoutExtension(node.assetPath).ToLower();
                    var list = CommonFBXOptiomizer.ExtractAnimationClip(node.assetPath, animationDir + name + "/", false);
                    foreach (var anim in list)
                    {
                        anim.legacy = true;
                    }
                }
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                return;
            }
            finally
            {
                AssetDatabase.StopAssetEditing();
            }
            List<GameObject> needDestory = new List<GameObject>();
            try
            {
                AssetDatabase.StartAssetEditing();
                foreach (var o in selection)
                {
                    var go = (GameObject) o;
                    var wrapObj = (GameObject) PrefabUtility.InstantiatePrefab(go);

                    /*if (!dirName.EndsWith("_0"))
                    {
                        //我们播放一次记录当前的状态然后将这些状态拷贝给WrapObj
                        var animObj = (GameObject) PrefabUtility.InstantiatePrefab(go);
                        animObj.name += "________";
                        var animation = animObj.GetComponent<Animation>();
                        if (animation.GetClip("refesh") != null)
                        {
                            animation["refesh"].time = animation["refesh"].normalizedTime = 1;
                            //animation.Play("refesh",AnimationPlayMode.Stop);
                        }
    
                        Transform source = animObj.transform;
                        Component[] sourceCom = source.GetComponents<Component>();
                        Transform target = wrapObj.transform;
                        Component[] targetCom = target.GetComponents<Component>();
                        for (var index = 0; index < sourceCom.Length; index++)
                        {
                            var sc = sourceCom[index];
                            var tc = targetCom[index];
                            ComponentUtility.CopyComponent(sc);
                            ComponentUtility.PasteComponentValues(tc);
                        }
                        PasteComponentValues( animObj.transform, wrapObj.transform);
                    }*/
                    AssignSplitMaterial(wrapObj, tempMatDir, textureDir, baseTextureDir);

                    string key = go.name.ToLower();
                    GameObject obj = AssetDatabase.LoadAssetAtPath<GameObject>(prefabDir + key + ".prefab");

                    if (obj != null)
                    {
                        //优化这些Renderer
                        foreach (var node in wrapObj.GetComponentsInChildren<Renderer>())
                        {
                            node.receiveShadows = false;
                            node.shadowCastingMode = ShadowCastingMode.Off;
                            node.lightProbeUsage = LightProbeUsage.Off;
                            node.reflectionProbeUsage = ReflectionProbeUsage.Off;
                            node.motionVectorGenerationMode = MotionVectorGenerationMode.ForceNoMotion;
                            node.allowOcclusionWhenDynamic = false;
                        }

                        //查找__DD打头的文件
                        foreach (var node in obj.GetComponentsInChildren<Transform>(true))
                        {
                            if (node.name.StartsWith("__DD") || node.name.StartsWith("collider__"))
                            {
                                var temp = Instantiate(node.gameObject);
                                temp.name = node.name;
                                temp.transform.parent = wrapObj.transform;
                                temp.transform.position = node.transform.position;
                                temp.transform.localScale = node.transform.localScale;
                                temp.transform.rotation = node.transform.rotation;
                            }
                        }
                    }

                    Component com = wrapObj.GetComponent<Animator>();
                    if (com != null)
                        DestroyImmediate(com);
                    Animation animCom = null;
                    animCom = wrapObj.gameObject.GetComponent<Animation>();
                    if (animCom == null)
                    {
                        animCom = wrapObj.gameObject.AddComponent<Animation>();
                    }

                    animCom.playAutomatically = false;
                    foreach (var anim in Directory.GetFiles(animationDir + o.name + "/","*.anim"))
                    {
                        var clip = AssetDatabase.LoadAssetAtPath<AnimationClip>(anim);
                        if (clip != null && !clip.name.Contains("__preview__"))
                        {
                            animCom.AddClip(clip, clip.name);
                        }
                    }

                    obj = PrefabUtility.CreatePrefab(prefabDir + key + ".prefab", wrapObj, ReplacePrefabOptions.ConnectToPrefab);
                    var clips = new List<AnimationClip>();
                    var animation = obj.GetComponent<Animation>();
                    if (animation != null)
                    {
                        foreach (var node in animation)
                        {
                            if (node != null && node is AnimationState)
                            {
                                clips.Add(((AnimationState) node).clip);
                            }
                        }
                        AnimationUtility.SetAnimationClips(animation, clips.ToArray());
                    }
                    needDestory.Add(wrapObj);
                }
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                return;
            }
            finally
            {
                AssetDatabase.StopAssetEditing();
            }

            AssetDatabase.Refresh();

            //清除缓存
            foreach (var node in needDestory)
            {
                DestroyImmediate(node);
            }
            
            //关闭部分功能避免资源泄漏
            AssetDatabase.StartAssetEditing();
            try
            {
                foreach (var node in fbxArray)
                {
                    var importer = (ModelImporter) node;
                    importer.materialImportMode = ModelImporterMaterialImportMode.None;
                    importer.importAnimation = false;
                    importer.SaveAndReimport();
                }
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                return;
            }
            finally
            {
                AssetDatabase.StopAssetEditing();
            }
            AssetDatabase.SaveAssets();
        }
        catch (Exception e)
        {
            Debug.LogError("!!!!!!!!!!!!!!" + e);
        }
    }

    private static void PasteComponentValues(Transform animObj, Transform wrapObj)
    {
        int count = animObj.childCount;

        for(int i = 0;i<count;i++)
        {
            var source = animObj.GetChild(i);
            var sourceCom = source.GetComponents<Component>();
            var target = wrapObj.GetChild(i);
            var targetCom = target.GetComponents<Component>();
            for (int j = 0; j < sourceCom.Length; j++)
            {
                ComponentUtility.CopyComponent(sourceCom[j]);
                ComponentUtility.PasteComponentValues(targetCom[j]);
            }

            if (source.childCount > 0)
            {
                PasteComponentValues(source, target);
            }
        }
    }

    /// <summary>
    /// 细分材质球
    /// </summary>
    public static void AssignSplitMaterial(GameObject go, string matDir, string textureDir, string baseTextureDir)
    {
        var renderers = go.GetComponentsInChildren<Renderer>();
        var baseShader = AssetDatabase.LoadAssetAtPath<Shader>("Assets/Res/Shader/BetterTransparent.shader");
        foreach (var node in renderers)
        {
            Material[] materials = node.sharedMaterials;
            for (var i = 0; i < materials.Length; i++)
            {
                var mat = materials[i];
                if (mat == null)
                    continue;
                
                int index = 0;
                var path = matDir + go.name.Replace("(Clone)","") + "_" + GameObjectUtils.GetObjPath(go.transform,node.transform).Replace("/","_");
                if (i > 0)
                    path += "__" + i;
                path += ".mat";
                //检查路径是否存在材质球如果存在则只更换贴图即可
                var pathMat = AssetDatabase.LoadAssetAtPath<Material>(path);
                if (pathMat != null)
                {
                    if (pathMat.shader != baseShader)
                    {
                        var order = pathMat.renderQueue;
                        pathMat.shader = baseShader;
                        pathMat.renderQueue = order;
                    }
                    if (mat.mainTexture == null)
                    {
                        var tex = AssetDatabase.LoadAssetAtPath<Texture2D>(baseTextureDir + mat.name + ".png") ?? AssetDatabase.LoadAssetAtPath<Texture2D>(textureDir + mat.name + ".png");
                        if(tex != null)
                            pathMat.mainTexture = tex;
                    }
                    else
                    {
                        var texturePath = Path.GetDirectoryName(PathUtils.FormatFilePath(AssetDatabase.GetAssetPath(mat.mainTexture))) + '/';
                        if(texturePath == textureDir || texturePath == baseTextureDir)
                            pathMat.mainTexture = mat.mainTexture;
                        else
                        {
                            if (mat.mainTexture.name.Contains("yinying") || mat.mainTexture.name.Contains("yingying") || mat.mainTexture.name.Contains("yiying"))
                            {
                                pathMat.SetFloat("_Cutoff",0);
                                pathMat.mainTexture = AssetDatabase.LoadAssetAtPath<Texture>(baseTextureDir + "yinying.png");
                            }
                        }
                    }
                    materials[i] = pathMat;
                }
                else
                {
                    var newMat = new Material(baseShader);
                    newMat.CopyPropertiesFromMaterial(mat);
                    newMat.SetColor("_Color",Color.white);
                    newMat.SetFloat("_Cutoff", 0);
                    AssetDatabase.CreateAsset(newMat, path);
                    materials[i] = AssetDatabase.LoadAssetAtPath<Material>(path);
                }
            }
            node.sharedMaterials = materials;
        }
    }
}
