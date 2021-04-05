using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerHelper
{
    public static readonly int IngoreNav = LayerMask.NameToLayer("IgnoreNav");
    public static readonly int Default = LayerMask.NameToLayer("Default");
    public static readonly int Water = LayerMask.NameToLayer("Water");
    public static readonly int IngoreRaycast = LayerMask.NameToLayer("Ignore Raycast");
    public static readonly int UI = LayerMask.NameToLayer("UI");
    public static readonly int TransparentFX = LayerMask.NameToLayer("TransparentFX");
}