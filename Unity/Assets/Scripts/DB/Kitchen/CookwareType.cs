using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CookwareType
{
    [SerializeField,HideInInspector]
    private string mKey;
    public string Key => mKey;

    private CookwareType(string key)
    {
        mKey = key;
    }
    
    public static CookwareType K2FryingPan = new CookwareType(nameof(K2FryingPan));
    public static CookwareType K2CuttingBoard = new CookwareType(nameof(K2CuttingBoard));
    public static CookwareType K2CoffeeMachine = new CookwareType(nameof(K2CoffeeMachine));
    public static CookwareType K2GrillPan = new CookwareType(nameof(K2GrillPan));
    public static CookwareType K2HoldingPlate = new CookwareType(nameof(K2HoldingPlate));
    public static CookwareType K2Oven = new CookwareType(nameof(K2Oven));
}
