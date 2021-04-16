using UnityEditor;
 
[InitializeOnLoad]
public class KeystoreHelper
{
    static KeystoreHelper()
    {
        PlayerSettings.Android.keystorePass = "159357";
        PlayerSettings.Android.keyaliasName = "testkeystore";
        PlayerSettings.Android.keyaliasPass = "159357";
    }
}
