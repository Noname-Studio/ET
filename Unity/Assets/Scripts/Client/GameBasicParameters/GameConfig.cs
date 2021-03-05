using System.Collections;
using System.Collections.Generic;
using Panthea.Asset;
using UnityEngine;

public static class GameConfig 
{
    public const string LevelConfigPath = "DB/Kitchen/Levels/";
    public const string IngredientConfigPath = "DB/Kitchen/Ingredient/";
    public const string FoodConfigPath = "DB/Kitchen/Foods/";
    public const string CustomerConfigPath = "DB/Kitchen/Customer/";
    public const string CookwareConfigPath = "DB/Kitchen/Cookwares/";
    public static string PersistentDataPath { get; } = AssetsConfig.PersistentDataPath;
    public static bool MobileRuntime
    {
        get
        {
            #if UNITY_EDITOR
            return UnityEditor.EditorPrefs.GetBool(nameof(MobileRuntime), false);
            #else
            return true;
            #endif
        }
    }

}
