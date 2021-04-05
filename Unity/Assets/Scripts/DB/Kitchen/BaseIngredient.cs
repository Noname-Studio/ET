using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class BaseIngredient: SerializedScriptableObject
{
    [BoxGroup("基础信息")]
    [HorizontalGroup("基础信息/Split", LabelWidth = 50)]
    [VerticalGroup("基础信息/Split/Left")]
#if UNITY_EDITOR
    [SerializeField]
    [HideLabel]
    [PreviewField(55, ObjectFieldAlignment.Left)]
    [DisableInInlineEditors]
    [OnValueChanged("SetTexture")]
    protected Texture mEditorTexture; // 纹理名称
#endif
    [SerializeField]
    [LabelText("Key")]
    [HideInInlineEditors]
    [ReadOnly]
    [VerticalGroup("基础信息/Split/Right")]
    protected string mKey; // 食物名称键值

    [SerializeField]
    [HideInInspector]
    protected string mTexture;

    public string Key => mKey;
    public string Texture => mTexture;
}