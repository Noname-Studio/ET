using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[Serializable]
[InlineEditor(Expanded = true)]
public partial class IngredientProperty: BaseIngredient
{
    //[SerializeField, LabelText("价格"),HideInInlineEditors,VerticalGroup("基础信息/Split/Right")]
    //protected int mPrice; // 食物价格
    [SerializeField]
    [LabelText("食材摆放位置")]
    [HideInInlineEditors]
    private List<ReachItemDPosition> mDisPosList = new List<ReachItemDPosition>(); // 解析后的厨具显示位置

    public List<ReachItemDPosition> DisPosList => mDisPosList;

    public string DisplayName => "Ingredient_" + Key;
    //public int Price => mPrice;
}

#if UNITY_EDITOR
public partial class IngredientProperty
{
    protected override void OnBeforeSerialize()
    {
        base.OnBeforeSerialize();
        mKey = "I_" + name;
    }

    private void SetTexture()
    {
        if (mEditorTexture != null)
        {
            mTexture = PathUtils.RemoveFileExtension(UnityEditor.AssetDatabase.GetAssetPath(mEditorTexture).Replace("Assets/Res/", ""));
        }
        else
        {
            mTexture = null;
        }
    }
}
#endif