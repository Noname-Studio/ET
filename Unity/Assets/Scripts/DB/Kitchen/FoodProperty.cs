﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using Panthea.Asset;
using RestaurantPreview.Config;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;
#if UNITY_EDITOR
using UnityEditor;

#endif
[Serializable]
public partial class FoodDetailProperty
{
    [SerializeField]
    [ReadOnly]
    [LabelText("等级")]
    private int mLevel;

    [SerializeField]
    [LabelText("解锁等级")]
    [HideInInlineEditors]
    private int mUnlockLv;

    [FormerlySerializedAs("mPriceList")]
    [SerializeField]
    [LabelText("升级消耗")]
    [HideInInlineEditors]
    [BoxGroup("杂项")]
    private Price mPrice = new Price(); //升级消耗

    [SerializeField]
    [LabelText("小费")]
    [HideInInlineEditors]
    [BoxGroup("杂项")]
    private int mTips; // 默认的小费数额

    public int Tips => mTips;
    public Price Price => mPrice;
    public int Level => mLevel;
    public int UnlockLv => mUnlockLv;
}

/// <summary>
/// 继承自BaseIngredient是因为有时候Food也可以作为食材使用
/// 比如说做好了得鸡蛋.它属于蛋包饭得食材.但实际上他本质也可以当作食物直接给顾客
/// </summary>
[Serializable]
[InlineProperty]
[InlineEditor(Expanded = true)]
public partial class FoodProperty: BaseIngredient
{
    public const string FOOD_KEY_BURN = "Burn food";
    public const string FOOD_KEY_ANY = "anyfood";

    private static Dictionary<string, FoodProperty> mDict;

    private ReadOnlyCollection<FoodDetailProperty> mTempLevels;

    public ReadOnlyCollection<FoodDetailProperty> Levels
    {
        get
        {
            if (mTempLevels != null)
            {
                return mTempLevels;
            }

            return mTempLevels = new ReadOnlyCollection<FoodDetailProperty>(mLevels);
        }
    }

    [SerializeField]
    [LabelText("餐厅Key")]
    [HideInInlineEditors]
    [ValueDropdown("@RestaurantKey.EDITOR_RESTAURANTSELECT()")]
    [Required]
    private string mRestId;

    [SerializeField]
    [LabelText("顾客等待时间")]
    [HideInInlineEditors]
    private float mWaitTime; // 默认等待时间

    [SerializeField]
    [LabelText("等级")]
    [HideInInlineEditors]
    [OnValueChanged("LevelCapChanged")]
    private List<FoodDetailProperty> mLevels = new List<FoodDetailProperty>();

    [SerializeField]
    [LabelText("基础耐心")]
    [HideInInlineEditors]
    private float mBasePatient = 100;

    [SerializeField]
    [LabelText("烹饪厨具")]
    [HideInInlineEditors]
    [OnValueChanged("SetCookware")]
    private CookwareProperty mCookware; // 最终烹饪所使用的厨具类型

    [SerializeField]
    [LabelText("烹饪所需食材")]
    [HideInInlineEditors]
    private List<BaseIngredient> mAllIngredients = new List<BaseIngredient>(); // 最终烹饪所需要的食材/食物

    private int mLevelCap = -1;

    public int LevelCap
    {
        get
        {
            if (mLevelCap == -1)
            {
                mLevelCap = Levels.Count;
            }

            return mLevelCap;
        }
    }

    public float WaitTime => mWaitTime;

    public RestaurantKey RestaurantId => RestaurantKey.Wrap(mRestId);

    public List<BaseIngredient> AllIngredients => mAllIngredients;

    public string DisplayName => LocalizationProperty.Read("Food_" + Key);

    public CookwareProperty Cookware => mCookware;

    public float BasePatient => mBasePatient;

    /// <summary>
    /// 当前级别的食物
    /// </summary>
    public FoodDetailProperty CurrentLevel
    {
        get
        {
            var food = Data_FoodFactory.Get(Key, RestaurantId);
            if (food == null)
            {
                return Levels[0];
            }

            return Levels[food.Level - 1];
        }
    }

    /// <summary>
    /// 下一级别的食物
    /// </summary>
    public FoodDetailProperty NextLevel
    {
        get
        {
            var current = CurrentLevel;
            if (Levels.Count > current.Level)
            {
                return Levels[current.Level]; //因为current.Level是从1开始得并不是从0.所以这里数组返回Level是正确的
            }

            return null;
        }
    }

    public static Dictionary<string, FoodProperty> ReadDict()
    {
        if (mDict == null)
        {
            mDict = new Dictionary<string, FoodProperty>();
            var filter = AssetsKit.Inst.GetFilterAssetBundle(new string[] { "Config/Kitchen/Foods" });
            foreach (var node in filter)
            {
                var objects = AssetsKit.Inst.LoadAllSync(node);
                foreach (var o in objects.Values)
                {
                    for (int i = 0; i < o.Count; i++)
                    {
                        var property = o[i] as FoodProperty;
                        if (property != null)
                        {
                            mDict[property.Key] = property;
                        }
                    }
                }
            }
        }

        return mDict;
    }

    public static FoodProperty Read(string key)
    {
        if (key.StartsWith("F_"))
        {
            key = key.Remove(0, 2);
        }

        return AssetsKit.Inst.LoadSync<FoodProperty>(GameConfig.FoodConfigPath + key);
    }
}

#if UNITY_EDITOR
public partial class FoodProperty
{
    private CookwareProperty mBeforeChangedCookware;

    protected override void OnBeforeSerialize()
    {
        base.OnBeforeSerialize();
        mKey = "F_" + name;
    }

    private void OnEnable()
    {
        mBeforeChangedCookware = Cookware;
    }

    private void LevelCapChanged()
    {
        var detailProperty = typeof (FoodDetailProperty);
        for (var index = 0; index < Levels.Count; index++)
        {
            var node = Levels[index];
            detailProperty.GetField("mLevel", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(node, index + 1);
        }
    }

    private void SetTexture()
    {
        if (mEditorTexture != null)
        {
            mTexture = PathUtils.RemoveFileExtension(AssetDatabase.GetAssetPath(mEditorTexture).Replace("Assets/Res/", ""));
        }
        else
        {
            mTexture = null;
        }
    }

    private void SetCookware()
    {
        CookwareModify(true);
        mBeforeChangedCookware = mCookware;
        CookwareModify(false);
        AssetDatabase.SaveAssets();
        //AssetDatabase.Refresh();
    }

    private void CookwareModify(bool remove)
    {
        if (mBeforeChangedCookware != null)
        {
            var cookware = AssetDatabase.LoadAssetAtPath<CookwareProperty>("Assets/Res/DB/Kitchen/Cookwares/" + mBeforeChangedCookware.Key +
                ".asset");
            var list =
                    cookware.GetType().GetField("mFoodKey", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(cookware) as List<FoodProperty>;
            if (list != null)
            {
                if (remove)
                {
                    list.RemoveAll(t1 => t1 == null);
                    list.RemoveAll(t1 => t1.Key == Key);
                }
                else
                {
                    list.Add(this);
                }
            }
            else
            {
                Debug.LogError("Cookware List is Null");
            }

            EditorUtility.SetDirty(cookware);
        }
    }
}
#endif