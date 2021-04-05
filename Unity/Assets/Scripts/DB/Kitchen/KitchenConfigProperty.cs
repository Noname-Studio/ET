using System;
using Sirenix.OdinInspector;
using UnityEngine;

[Serializable]
public class KitchenConfigProperty: SerializedScriptableObject
{
    [LabelText("连击消逝速度")]
    [SerializeField]
    private float mComboLoseSpeed = 1;

    public float ComboLoseSpeed => mComboLoseSpeed;
}