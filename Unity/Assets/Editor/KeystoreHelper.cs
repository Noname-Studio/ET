using System.IO;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class KeystoreHelper
{
    static KeystoreHelper()
    {
        var dir = new DirectoryInfo(Application.dataPath);
        PlayerSettings.Android.keystoreName = dir.Parent.Parent.FullName + "/user.keystore"; 
        PlayerSettings.Android.keystorePass = "159357";
        PlayerSettings.Android.keyaliasName = "testkeystore";
        PlayerSettings.Android.keyaliasPass = "159357";
    }
}
