using System;
using Sirenix.OdinInspector;
using UnityEngine;

[Serializable]
public partial class ReachItemDPosition
{
    [LabelText("起始关卡")]
    public int Start = 0;

    [LabelText("结束关卡")]
    public int End = 0;

    [LabelText("位置")]
    public Vector3 Pos;

    /*[LabelText("碰撞盒大小(过时的,不要用)")]
    public Vector3 ColliderSize;
    [LabelText("碰撞盒偏移(过时的,不要用)")]
    public Vector3 ColliderOffset;*/
    [LabelText("等级限制")]
    [SerializeField]
    private int mLevel;

    public int Level => mLevel;

    [LabelText("餐厅")]
    [ValueDropdown("@RestaurantKey.EDITOR_RESTAURANTSELECT()")]
    [SerializeField]
    private string mRestaurant = RestaurantKey.FoodTruck.Key;

    public RestaurantKey Restaurant => RestaurantKey.Wrap(mRestaurant);
}