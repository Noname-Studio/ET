using System.Collections;
using System.Collections.Generic;
using Panthea.Asset;
using UnityEngine;

public static class GameConfig
{
    public const string LevelConfigPath = "Config/Kitchen/Levels/";
    public const string IngredientConfigPath = "Config/Kitchen/Ingredient/";
    public const string FoodConfigPath = "Config/Kitchen/Foods/";
    public const string CustomerConfigPath = "Config/Kitchen/Customer/";
    public const string CookwareConfigPath = "Config/Kitchen/Cookwares/";
    public static string PersistentDataPath { get; } = AssetsConfig.PersistentDataPath;

    public static bool MobileRuntime
    {
        get
        {
#if UNITY_EDITOR
            return UnityEditor.EditorPrefs.GetBool(nameof (MobileRuntime), false);
#else
            return true;
#endif
        }
    }

    public static char[] StringSplit = { ',' };
}