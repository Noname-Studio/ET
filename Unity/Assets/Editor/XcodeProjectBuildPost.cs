#if UNITY_IOS
using System.IO;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;
public class XCodeProjectMod  {
    [PostProcessBuild]
    public  static  void OnPostprocessBuild (BuildTarget BuildTarget, string path) {
        if (BuildTarget == BuildTarget.iOS) {
            //这里是固定的
            string projPath = PBXProject.GetPBXProjectPath(path);
            PBXProject proj = new PBXProject();
            proj.ReadFromString(File.ReadAllText(projPath));
            string target = proj.TargetGuidByName("Unity-iPhone");

            // set code sign identity & provisioning profile
            proj.SetBuildProperty (target, "CODE_SIGN_IDENTITY", "iPhone Developer: ming xing (9V4FTD5US7)");//替换你的code sign identity
            proj.SetBuildProperty (target, "PROVISIONING_PROFILE_SPECIFIER", "com.companyname");//替换你的provisioning profile specifier
            //proj.SetBuildProperty (target, "CODE_SIGN_ENTITLEMENTS", "KeychainAccessGroups.plist");
            proj.SetBuildProperty (target, "DEVELOPMENT_TEAM", "A3A6A4A6DB");//替换你的development team
            proj.SetBuildProperty (target, "CODE_SIGN_STYLE", "Manual");

            //ulua 库不支持 bitcode必须要关闭，才能打包
            proj.SetBuildProperty(target,"ENABLE_BITCODE", "NO");

            File.WriteAllText(projPath, proj.WriteToString());
        }
    }
}
#endif