using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/*class MSEditorSettings : SettingsProvider  {
    public override void OnGUI(string searchContext)
    {
        bool UseAws = EditorPrefs.GetBool("AWSSavedSystem",false);
        UseAws = EditorGUILayout.Toggle("使用AWS存档系统: ", UseAws);
        if (GUI.changed)
        {
            EditorPrefs.SetBool("AWSSavedSystem", UseAws);
        }

        bool simulationMobileRuntime = EditorPrefs.GetBool(nameof(GameConfig.SimulationMobileRuntime), false);
        EditorGUILayout.Toggle("开启实际游戏模式: ", simulationMobileRuntime);
        if (GUI.changed)
        {
            EditorPrefs.SetBool(nameof(GameConfig.SimulationMobileRuntime), simulationMobileRuntime);
        }
        
        EditorGUI.BeginChangeCheck();
        var localization = ArrayUtility.FindIndex(Language.All, t1 => t1.Value == EditorPrefs.GetString("Localization"));
        if (localization == -1)
            localization = 0;
        var s = new string[Language.All.Length];
        for (var i = 0; i < Language.All.Length; i++)
        {
            var node = Language.All[i];
            s[i] = node.Value + "(" + node.EditorName + ")";
        }

        int index = EditorGUILayout.Popup("语言", localization, s);
        if (EditorGUI.EndChangeCheck())
        {
            EditorPrefs.SetString("Localization", Language.All[index]);
            /*if(Application.isPlaying)
                FairyManager.Instance.RefreshLocalization();#1#
        }
        EditorGUILayout.HelpBox("UI需要在下次启动游戏的时候才能生效",MessageType.Info);
    }

    public MSEditorSettings(string path, SettingsScope scopes = SettingsScope.User, IEnumerable<string> keywords = null) : base(path, scopes, keywords)
    {
        
    }
}*/

internal static class MSEditorSettings
{
    [SettingsProvider]
    public static SettingsProvider CreateMyCustomSettingsProvider()
    {
        var provider = new SettingsProvider("MinistoneSettings", SettingsScope.User)
        {
            label = "Ministone Settings",
            guiHandler = (searchContext) =>
            {
                bool UseAws = EditorPrefs.GetBool("AWSSavedSystem", false);
                UseAws = EditorGUILayout.Toggle("使用AWS存档系统: ", UseAws);
                if (GUI.changed)
                {
                    EditorPrefs.SetBool("AWSSavedSystem", UseAws);
                }

                bool simulationMobileRuntime = EditorPrefs.GetBool(nameof (GameConfig.MobileRuntime), false);
                simulationMobileRuntime = EditorGUILayout.Toggle("开启实际游戏模式: ", simulationMobileRuntime);
                if (GUI.changed)
                {
                    EditorPrefs.SetBool(nameof (GameConfig.MobileRuntime), simulationMobileRuntime);
                }

                EditorGUI.BeginChangeCheck();
                var localization = ArrayUtility.FindIndex(Language.All, t1 => t1.Value == EditorPrefs.GetString("Localization"));
                if (localization == -1)
                {
                    localization = 0;
                }

                var s = new string[Language.All.Length];
                for (var i = 0; i < Language.All.Length; i++)
                {
                    var node = Language.All[i];
                    s[i] = node.Value + "(" + node.EditorName + ")";
                }

                int index = EditorGUILayout.Popup("语言", localization, s);
                if (EditorGUI.EndChangeCheck())
                {
                    EditorPrefs.SetString("Localization", Language.All[index]);
                    /*if(Application.isPlaying)
                        FairyManager.Instance.RefreshLocalization();*/
                }

                EditorGUILayout.HelpBox("UI需要在下次启动游戏的时候才能生效", MessageType.Info);
            }
        };
        return provider;
    }
}