using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using DB.Kitchen;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public enum CustomerType
{
    [LabelText("普通")]
    Normal,

    [LabelText("特殊")]
    Special,

    [LabelText("公会")]
    Club
}

[Serializable]
[InlineEditor(Expanded = true)]
public partial class CustomerProperty: SerializedScriptableObject
{
    [HorizontalGroup("设定/Split")]
    [HorizontalGroup("设定/Split/Normal", LabelWidth = 100)]
    [BoxGroup("设定")]
    [VerticalGroup("设定/Split/Normal/Right")]
    [SerializeField]
    [LabelText("Key")]
    [HideInInlineEditors]
    [ReadOnly]
    [VerticalGroup("设定/Split/Normal/Right")]
    private string mKey; // 顾客名字键值

    [SerializeField]
    [LabelText("顾客类型")]
    [HideInInlineEditors]
    [VerticalGroup("设定/Split/Normal/Right")]
    [ValueDropdown("EDITOR_CustomerType")]
    private CustomerType mType; // 类型

#if UNITY_EDITOR
    [FormerlySerializedAs("mIconTexture")]
    [SerializeField]
    [PreviewField(55, ObjectFieldAlignment.Left)]
    [DisableInInlineEditors]
    [HideLabel]
    [VerticalGroup("设定/Split/Normal/Left")]
    [PropertyOrder(-100)]
    private Texture mEditorTexture; // 图标材质
#endif

#if UNITY_EDITOR
    [SerializeField]
    [BoxGroup("模型相关")]
    [HideInInlineEditors]
    [LabelText("模型资源")]
    [AssetsOnly]
    [AssetSelector(Paths = "Assets/Res/Model/Customer")]
    [InlineEditor(PreviewHeight = 300, Expanded = true)]
    [OnValueChanged("SetModelPath")]
    private GameObject mModelObject; // 模型名称
#endif
    [SerializeField]
    [LabelText("移动速度")]
    [HideInInlineEditors]
    [BoxGroup("模型相关")]
    private float mMoveSpeed; //移动的速度

    [SerializeField]
    [BoxGroup("模型相关")]
    [HideInInlineEditors]
    [LabelText("模型资源")]
    [ReadOnly]
    private string mModelPath;

    public float MoveSpeed => mMoveSpeed;

    public string DisplayName => "Customer_" + mKey;

    public string ModelPath => mModelPath;

    public CustomerType Type => mType;

    //public bool CanLitter => mCanLitter;

    public string Key => mKey;

    //public int Id => mId;

    protected override void OnBeforeSerialize()
    {
        base.OnBeforeSerialize();
        mKey = name;
    }
}

#if UNITY_EDITOR
public partial class CustomerProperty: ILevelEditorImp
{
    private static ValueDropdownList<CustomerType> EDITOR_CustomerType()
    {
        var value = new ValueDropdownList<CustomerType>();
        var enumType = typeof (CustomerType);
        var memberInfos = enumType.GetFields(BindingFlags.Public | BindingFlags.Static);
        foreach (var node in memberInfos)
        {
            var valueAttributes = node.GetCustomAttributes(typeof (LabelTextAttribute), false);
            var description = ((LabelTextAttribute) valueAttributes[0]).Text;
            value.Add(description, (CustomerType) node.GetValue(null));
        }

        return value;
    }

    private void SetModelPath()
    {
        if (mModelObject != null)
        {
            var path = AssetDatabase.GetAssetPath(mModelObject);
            path = path.Replace("Assets/Res/", "");
            path = PathUtils.RemoveFileExtension(path);
            mModelPath = path;
        }
        else
        {
            mModelPath = null;
        }
    }

    public void UpdatePath()
    {
        SetModelPath();
    }
}
#endif