using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using Spine.Unity;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.Serialization;

public enum CookwareFuncType
{
    [LabelText("制作食物")]MakeFood,
    [LabelText("存储食物")]HoldingItem,
    [LabelText("杂项")]Misc//需要脚本扩展的厨具.一些特殊厨具.例如垃圾桶我们也当他是一种厨具.
}

[Serializable]
public partial class CookwareDetailProperty
{
    [SerializeField,ReadOnly,LabelText("等级")]
    private int mLevel;
#if UNITY_EDITOR
    [SerializeField,HideLabel,OnValueChanged("SetTexture"),PreviewField(55,ObjectFieldAlignment.Left)]
    private Texture mEditorTexture; // 静态图片材质
#endif
    [SerializeField,LabelText("工作时间"),HideInInlineEditors]
    private int mWorkTime; //厨具工作时间
    [SerializeField,LabelText("烧焦时间"),HideInInlineEditors]
    private int mBurnTime; //厨具烧焦时间
    [SerializeField,LabelText("产出数量"),HideInInlineEditors]
    private int mMakeCount = 1; // 产出的食物数量
    [SerializeField, BoxGroup("升级消耗"),HideInInlineEditors,HideLabel]
    private Price mPrice = new Price(); // 购买价格
    //private List<string> mFunctions; // 功能类型
    //private List<string> mAttributes; // 属性类型列表           
    //private Dictionary<string, string> mSpecialEffects; // 特效
    [SerializeField, LabelText("Spine数据"),HideInInlineEditors]
    private SkeletonDataAsset mSpineData;
    [SerializeField, LabelText("音效文件"),HideInInlineEditors]
    private AudioClip mEffectPath; // 音效文件
    
    private string mArmatureName; //
    private bool mIsWastage; // 是否会损耗
    private bool mIsFire; //火属性，火加速的顾客可以让厨具加速
    //[SerializeField, LabelText("超级厨具"),HideInInlineEditors]
    //private bool mIsSuper; //是否是超级厨具
    [SerializeField, LabelText("解锁等级"),HideInInlineEditors]
    private int mUnlockLv;
    
    public int Level => mLevel;
    public int WorkTime => mWorkTime;

    public int BurnTime => mBurnTime;
    
    public int MakeCount => mMakeCount;
    
    public Price Price => mPrice;
    
    public SkeletonDataAsset SpineData => mSpineData;
    public AudioClip EffectPath => mEffectPath;

    public string ArmatureName => mArmatureName;

    public bool IsWastage => mIsWastage;

    public bool IsFire => mIsFire;
    
    public int UnlockLv => mUnlockLv;

    [SerializeField,HideInInspector]
    private string mTexture;
    public string Texture => mTexture;
}

[InlineProperty]
[InlineEditor(Expanded = true)]
public partial class CookwareProperty : SerializedScriptableObject
{
#if UNITY_EDITOR
    [FormerlySerializedAs("mTexture")] [SerializeField,HideLabel,ReadOnly,PreviewField(55,ObjectFieldAlignment.Left)]
    private Texture mEditorTexture; // 静态图片材质
#endif
    
    [SerializeField,LabelText("真实ID"),ReadOnly,HideInInlineEditors,VerticalGroup("Split")]
    private string mKey; // 键值
    
    #if UNITY_EDITOR
    [SerializeField,LabelText("Key"),HideInInlineEditors,OnValueChanged("OnIdChanged"),VerticalGroup("Split")]
    private string EDITORKey; // 键值
    #endif
    
    [SerializeField, LabelText("餐厅Key"),ValueDropdown("@RestaurantKey.EDITOR_RESTAURANTSELECT()"),OnValueChanged("OnIdChanged"),VerticalGroup("Split"),HideInInlineEditors]
    private string mRestId;

    [SerializeField]
    private List<FoodProperty> mFoodKey = new List<FoodProperty>();
    
    [SerializeField,LabelText("厨具功能类型"),ValueDropdown("EDITOR_CookwareFuncType"),HideInInlineEditors]
    private CookwareFuncType mFunType; //厨具功能类型
    
    [SerializeField, LabelText("显示位置"),HideInInlineEditors]
    private List<ReachItemDPosition> mDisPosList = new List<ReachItemDPosition>(); // 解析后的厨具显示位置

    /*[SerializeField,LabelText("厨具类型"),ValueDropdown("EDITOR_CookwareType", HideChildProperties = true)]
    private CookwareType mTypeId; //厨具类型的ID*/
    [SerializeField,LabelText("等级"),HideInInlineEditors,OnValueChanged("LevelCapChanged")]
    private List<CookwareDetailProperty> mLevels = new List<CookwareDetailProperty>();

    private ReadOnlyCollection<CookwareDetailProperty> mTempLevels;
    public ReadOnlyCollection<CookwareDetailProperty> Levels
    {
        get
        {
            if (mTempLevels != null)
                return mTempLevels;
            return mTempLevels = new ReadOnlyCollection<CookwareDetailProperty>(mLevels);
        }   
    }
    
    private ReadOnlyCollection<FoodProperty> mTempFoodKey;
    public ReadOnlyCollection<FoodProperty> FoodKey
    {
        get
        {
            if (mTempFoodKey != null)
                return mTempFoodKey;
            return mTempFoodKey = new ReadOnlyCollection<FoodProperty>(mFoodKey);
        }   
    }
    
    public RestaurantKey RestaurantId => RestaurantKey.Wrap(mRestId);
    public CookwareFuncType FunType => mFunType;
    public List<ReachItemDPosition> DisPosList => mDisPosList;
    public string Key => mKey;
    
    public string DisplayName => Key;

    private int mLevelCap = -1;

    public int LevelCap
    {
        get
        {
            if (mLevelCap == -1)
                mLevelCap = Levels.Count;
            return mLevelCap;
        }
    }
    
    
    /// <summary>
    /// 当前级别的厨具
    /// </summary>
    public CookwareDetailProperty Current
    {
        get
        {
            var cookware = DBManager.Inst.Query<Data_Cookware>().AsTask();
            var result = cookware.Result;
            var info = result.Get(Key);
            if (info == null)
            {
                return Levels[0];
            }
            return Levels[info.Level];
        }
    }
}

#if UNITY_EDITOR
public partial class CookwareProperty
{
    private bool IdChanged;
    [Button(ButtonSizes.Large,Name = "应用"),VerticalGroup("Split"),ShowIf("@IdChanged == true")]
    private void Apply()
    {
        var path = AssetDatabase.GetAssetPath(this);
        var error = AssetDatabase.RenameAsset(path, mKey + ".asset");
        if (!string.IsNullOrEmpty(error))
            Log.Error(error);
    }
    
    private void LevelCapChanged()
    {
        var detailProperty = typeof(CookwareDetailProperty);
        for (var index = 0; index < Levels.Count; index++)
        {
            var node = Levels[index];
            detailProperty.GetField("mLevel",BindingFlags.Instance | BindingFlags.NonPublic).SetValue(node, index + 1);
        }
    }
    
    private static ValueDropdownList<CookwareFuncType> EDITOR_CookwareFuncType()
    {
        var value = new ValueDropdownList<CookwareFuncType>();
        var enumType = typeof(CookwareFuncType);
        var memberInfos = enumType.GetFields(BindingFlags.Public | BindingFlags.Static);
        foreach (var node in memberInfos)
        {
            var valueAttributes = node.GetCustomAttributes(typeof(LabelTextAttribute), false);
            var description = ((LabelTextAttribute)valueAttributes[0]).Text;
            value.Add(description,(CookwareFuncType)node.GetValue(null));
        }

        return value;
    }

    protected override void OnBeforeSerialize()
    {
        base.OnBeforeSerialize();
        if (Levels.Count > 0)
        {
            mEditorTexture = (Texture)typeof(CookwareDetailProperty).GetField("mEditorTexture", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(Levels[0]);
        }
    }

    private void OnIdChanged()
    {
        var rest = "k" + RestaurantId.Index + "_";
        mKey = rest + EDITORKey;
        var path = AssetDatabase.GetAssetPath(this);
        var fileName = Path.GetFileNameWithoutExtension(path);
        IdChanged = !mKey.Equals(fileName);
    }
}

public partial class CookwareDetailProperty
{
    private void SetTexture()
    {
        if (mEditorTexture != null)
        {
            mTexture = PathUtils.RemoveFileExtension(UnityEditor.AssetDatabase.GetAssetPath(mEditorTexture).Replace("Assets/Res/", ""));
        }
        else
            mTexture = null;
        
    }
}

#endif
