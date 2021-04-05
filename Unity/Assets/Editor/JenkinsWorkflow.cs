using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using Panthea.Editor.Asset;
using UnityEditor;
#if UNITY_IOS
using UnityEditor.iOS.Xcode;
#endif
using UnityEditor.SceneManagement;
using UnityEngine;
using Debug = UnityEngine.Debug;

/// <summary>
/// 这个类只有在MAC环境下才能使用
/// 主要是为了android和IOS能够共同出包
/// </summary>
public class JenkinsWorkflow: Editor
{
    private static string GetBasePath => Application.dataPath.Remove(Application.dataPath.Length - 6);

    private static string ExecuteProcessTerminal(string argument, string fileName, string workingDir)
    {
        try
        {
            Debug.Log("============== Start Executing [" + argument + "] ===============");
            ProcessStartInfo startInfo = new ProcessStartInfo()
            {
                FileName = fileName,
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                CreateNoWindow = true,
                WorkingDirectory = workingDir,
                Arguments = argument
            };
            Process p = new Process { StartInfo = startInfo };
            p.OutputDataReceived += new DataReceivedEventHandler((s, e) => { Debug.Log(e.Data); });
            p.ErrorDataReceived += new DataReceivedEventHandler((s, e) => { Debug.Log(e.Data); });

            p.Start();
            p.BeginOutputReadLine();
            p.BeginErrorReadLine();
            p.WaitForExit();
            return "";
        }
        catch (Exception e)
        {
            Debug.LogError(e);
            return null;
        }
    }

    public class CommandParams
    {
        public string Platform;
        public bool isCompress;
        public bool isMono;
        public string BundleName;
    }

    [MenuItem("Tools/Test")]
    public static void XXX()
    {
        ExecuteProcessTerminal($"{PlayerSettings.bundleVersion}", GetBasePath + "S3Sync/Upload.bat", GetBasePath + "S3Sync/");
    }

    public static void CommandLineExtenral()
    {
        try
        {
            var line = Environment.GetCommandLineArgs();

            //命令行传递的参数从第9个开始
            for (var index = 0; index < line.Length; index++)
            {
                var node = line[index];
                Console.WriteLine($"[{index}]:{node}");
            }

            var args = new CommandParams();
            var regex = Regex.Matches(line[9], @"\[.*?\]+");
            var type = typeof (CommandParams);
            foreach (Match node in regex)
            {
                var s = node.Value.TrimStart('[').TrimEnd(']').Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                var fieldName = s[0];
                var fieldValue = s[1];

                var field = type.GetField(fieldName);
                var fieldType = field.FieldType;
                if (fieldType == typeof (string))
                {
                    field.SetValue(args, fieldValue);
                }
                else if (fieldType == typeof (bool))
                {
                    field.SetValue(args, bool.Parse(fieldValue));
                }
            }

            EditorUserBuildSettings.compressFilesInPackage = true;
            //PlayerSettings.stripEngineCode = true;
            //PlayerSettings.strippingLevel = 
            EditorUserBuildSettings.development = true;
            EditorUserBuildSettings.allowDebugging = true;
            PlayerSettings.stripEngineCode = false;
            PlayerSettings.SetManagedStrippingLevel(BuildTargetGroup.Android, ManagedStrippingLevel.Disabled);
            ExecuteProcessTerminal($"+x Upload.sh", "chmod", GetBasePath + "S3Sync/");
            //打开Scene场景然后把控制台添加进去
            //EditorSceneManager.OpenScene("Assets/Scenes/Load.unity",OpenSceneMode.Single);
            //var ingameDebug = GameObject.Find("IngameDebugConsole");
            //if (ingameDebug == null)
            //{
            //	var asset = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Plugins/IngameDebugConsole/IngameDebugConsole.prefab");
            //	Instantiate(asset);
            //}
            //
            //EditorSceneManager.SaveOpenScenes();

            if (args.isCompress) //是否压缩包体
            {
                Debug.Log("开启压缩");
                var str = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android);
                PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, str + ";UseSplitAB");
            }
            else
            {
                Debug.Log("关闭压缩");
                var str = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android);
                PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, str.Replace("UseSplitAB;", ""));
            }

            if (!string.IsNullOrEmpty(args.BundleName))
            {
                PlayerSettings.bundleVersion = args.BundleName;
            }
            else
            {
                PlayerSettings.bundleVersion = "Dev";
            }

            if (string.Equals(args.Platform, "IOS", StringComparison.OrdinalIgnoreCase))
            {
                Debug.Log("!!!!!打包IPA");
                CommandLineBuildIPA(args);
            }
            else if (args.Platform == "Android")
            {
                Debug.Log("!!!!!打包Android");
                CommandLineBuildAndroid(args);
            }
        }
        catch (Exception e)
        {
            Debug.LogError("打包失败" + e);
        }
    }

    public static void CommandLineBuildAndroid(CommandParams args)
    {
        string androidAB = Application.streamingAssetsPath + "/Android/";
        string localServerAB = "/Users/donny/ApacheResources/Resources/Android/";
        if (EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Android, BuildTarget.Android))
        {
            EditorApplication.ExecuteMenuItem("Assets/Play Services Resolver/Android Resolver/Force Resolve");
            EditorApplication.ExecuteMenuItem("Assets/Play Services Resolver/Android Resolver/Resolve");

            EditorUserBuildSettings.exportAsGoogleAndroidProject = true;
            if (args.isMono)
            {
                Debug.Log("打包Mono");
                PlayerSettings.SetScriptingBackend(BuildTargetGroup.Android, ScriptingImplementation.Mono2x);
            }
            else
            {
                PlayerSettings.SetScriptingBackend(BuildTargetGroup.Android, ScriptingImplementation.IL2CPP);
            }

            PlayerSettings.SetIncrementalIl2CppBuild(BuildTargetGroup.Android, true);
            EditorUserBuildSettings.androidBuildSystem = AndroidBuildSystem.Gradle;
            var osxPath = Application.streamingAssetsPath + "/OSX/";
            if (Directory.Exists(osxPath))
            {
                Directory.Delete(osxPath, true);
            }

            AssetBundleBuilder.Pack();
            var exportPath = GetBasePath + "AndroidProject";
            //删除掉文件夹避免冗余
            /*if(Directory.Exists(exportPath))
                Directory.Delete(exportPath,true);*/
            Directory.CreateDirectory(exportPath);
            //拷贝文件到服务器路径,并且把文件提交服务器
            if (Directory.Exists(androidAB))
            {
                /*if(Directory.Exists(localServerAB))
                    Directory.Delete(localServerAB,true);*/
                Debug.Log("上传AB文件到本地服务器");
                DirectoryCopy(androidAB, localServerAB, true);
            }

            if (args.isCompress)
            {
                Debug.Log("清除多余的AB文件");
                //AssetBundleEditor.ClearAB();
            }

            Debug.Log("开始打包App");
            //生成谷歌项目
            var options = BuildOptions.AcceptExternalModificationsToPlayer | BuildOptions.CompressWithLz4HC | BuildOptions.Development;
            if (!args.isMono)
            {
                PlayerSettings.SetScriptingBackend(BuildTargetGroup.Android, ScriptingImplementation.IL2CPP);
            }

            var result = BuildPipeline.BuildPlayer(GetBuildScenes(), exportPath, BuildTarget.Android, options);
            Debug.Log(result);
            Debug.Log("Build Complete Path:" + exportPath);
        }
    }

    public static void CommandLineBuildIPA(CommandParams args)
    {
        string iosAB = Application.streamingAssetsPath + "/iOS/";
        string localServerAB = "/Users/donny/ApacheResources/Resources/iOS/";
        if (EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.iOS, BuildTarget.iOS))
        {
            var osxPath = Application.streamingAssetsPath + "/OSX/";
            if (Directory.Exists(osxPath))
            {
                Directory.Delete(osxPath, true);
            }

            AssetBundleBuilder.Pack();
            var exportPath = GetBasePath + "IOSProject";
            Debug.Log(exportPath);
            //删除掉文件夹避免冗余
            /*if (Directory.Exists(exportPath))
	            Directory.Delete(exportPath, true);*/
            Directory.CreateDirectory(exportPath);
            //拷贝文件到服务器路径,并且把文件提交服务器
            if (Directory.Exists(iosAB))
            {
                /*if(Directory.Exists(localServerAB))
                    Directory.Delete(localServerAB);*/
                Debug.Log("上传AB文件到本地服务器");
                DirectoryCopy(iosAB, localServerAB, true);
            }

            if (args.isCompress)
            {
                Debug.Log("清除多余的AB文件");
                //AssetBundleEditor.ClearAB();
            }

            Debug.Log("开始打包IPA");
            PlayerSettings.iOS.scriptCallOptimization = ScriptCallOptimizationLevel.SlowAndSafe;
            PlayerSettings.SetArchitecture(BuildTargetGroup.iOS, 1);
            //生成苹果项目
            BuildPipeline.BuildPlayer(GetBuildScenes(), exportPath, BuildTarget.iOS,
                BuildOptions.AcceptExternalModificationsToPlayer | BuildOptions.CompressWithLz4HC | BuildOptions.Development);

#if UNITY_IOS
			string projectPath = exportPath + "/Unity-iPhone.xcodeproj/project.pbxproj";

			PBXProject pbxProject = new PBXProject();
			pbxProject.ReadFromFile(projectPath);

			string target = pbxProject.TargetGuidByName("Unity-iPhone");            
			pbxProject.SetBuildProperty(target, "ENABLE_BITCODE", "NO");

			pbxProject.WriteToFile (projectPath);
#endif
            Console.WriteLine("Build Complete Path:" + exportPath);
            Debug.Log("Build Complete Path:" + exportPath);
        }
    }

    /// <summary>
    /// 获取build Setting 列表里的打勾场景
    /// </summary>
    /// <returns></returns>
    private static string[] GetBuildScenes()
    {
        List<string> names = new List<string>();
        foreach (var node in EditorBuildSettings.scenes)
        {
            if (!node.enabled)
            {
                continue;
            }

            names.Add(node.path);
        }

        return names.ToArray();
    }

    private static void DirectoryCopy(
    string sourceDirName, string destDirName, bool copySubDirs)
    {
        DirectoryInfo dir = new DirectoryInfo(sourceDirName);
        DirectoryInfo[] dirs = dir.GetDirectories();

        // If the source directory does not exist, throw an exception.
        if (!dir.Exists)
        {
            throw new DirectoryNotFoundException("Source directory does not exist or could not be found: "
                + sourceDirName);
        }

        // If the destination directory does not exist, create it.
        if (!Directory.Exists(destDirName))
        {
            Directory.CreateDirectory(destDirName);
        }

        // Get the file contents of the directory to copy.
        FileInfo[] files = dir.GetFiles();

        foreach (FileInfo file in files)
        {
            // Create the path to the new copy of the file.
            string temppath = Path.Combine(destDirName, file.Name);

            // Copy the file.
            file.CopyTo(temppath, true);
        }

        // If copySubDirs is true, copy the subdirectories.
        if (copySubDirs)
        {
            foreach (DirectoryInfo subdir in dirs)
            {
                // Create the subdirectory.
                string temppath = Path.Combine(destDirName, subdir.Name);

                // Copy the subdirectories.
                DirectoryCopy(subdir.FullName, temppath, copySubDirs);
            }
        }
    }
}