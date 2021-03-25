using System;
using Sirenix.OdinInspector;
using UnityEngine;
[Serializable]
public class RestaurantKey
{
    [SerializeField,HideInInspector]
    private string mKey;
    [SerializeField,HideInInspector]
    private int mIndex;
    public string Key => mKey;
    public int Index => mIndex;
    
    #if UNITY_EDITOR
    /// <summary>
    /// 注释(用于编辑器内部显示)
    /// </summary>
    private string Comment { get; set; }
    #endif
    
    private RestaurantKey(string key, int index,string comment)
    {
        mKey = key;
        mIndex = index;
        
        #if UNITY_EDITOR
        Comment = comment;
        #endif
    }
    
    public static RestaurantKey Unknown = new RestaurantKey(nameof(Unknown), 0,"无");
    public static RestaurantKey FoodTruck = new RestaurantKey(nameof(FoodTruck), 1,"快餐车");
    public static RestaurantKey Breakfast = new RestaurantKey(nameof(Breakfast), 2,"早餐厅");

    public static RestaurantKey This
    {
        get
        {
            var gameRecord = DBManager.Inst.Query<Data_GameRecord>();
            foreach (var node in All)
            {
                if (node.Index == gameRecord.ArriveRestaurant)
                    return node;
            }
            return null;
        }
    }

    public static RestaurantKey[] All = {FoodTruck, Breakfast};

    public static string Map(int id)
    {
        for (int i = 0; i < All.Length; i++)
        {
            var node = All[i];
            if (node.Index == id)
                return node.Key;
        }
        Log.Error("非法的ID.不存在这个ID的餐厅");
        return Unknown.Key;
    }
    
    public static int Map(string id)
    {
        for (int i = 0; i < All.Length; i++)
        {
            var node = All[i];
            if (node.Key == id)
            {
                return node.Index;
            }
        }
        Log.Error("非法的ID.不存在这个ID的餐厅");
        return Unknown.Index;
    }

    public static RestaurantKey Wrap(string id)
    {
        for (int i = 0; i < All.Length; i++)
        {
            var node = All[i];
            if (node.Key == id)
                return node;
        }
        Log.Error("非法的ID.不存在这个ID的餐厅");
        return Unknown;
    }
    
    public static RestaurantKey Wrap(int id)
    {
        for (int i = 0; i < All.Length; i++)
        {
            var node = All[i];
            if (node.Index == id)
                return node;
        }
        Log.Error("非法的ID.不存在这个ID的餐厅");
        return Unknown;
    }

    public override string ToString()
    {
        return mKey;
    }

#if UNITY_EDITOR
    public static ValueDropdownList<string> EDITOR_RESTAURANTSELECT()
    {
        var dropdown = new ValueDropdownList<string>();
        dropdown.Add(Unknown.Comment,Unknown.Key);
        foreach (var node in All)
        {
            dropdown.Add(node.Comment, node.Key);
        }
        return dropdown;
    }
#endif
}
