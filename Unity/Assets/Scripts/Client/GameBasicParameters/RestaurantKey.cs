using System;
using Newtonsoft.Json;
using NPOI.SS.Formula.Functions;
using Sirenix.OdinInspector;
using UnityEngine;

[Serializable]
public class RestaurantKey
{
    private string mKey;
    private int mIndex;
    private string mId;
    public string Key => mKey;
    public int Index => mIndex;
    public string Id => mId;
    private RestaurantKey(string key, int index,string id)
    {
        mKey = key;
        mIndex = index;
        mId = id;
    }

    public static RestaurantKey Unknown = new RestaurantKey("无", 0,"Unknown");
    //public static RestaurantKey FoodTruck = new RestaurantKey("快餐车", 1,"FoodTruck");
    public static RestaurantKey Breakfast = new RestaurantKey("早餐厅", 1,"Breakfast");
    //public static RestaurantKey Cafe = new RestaurantKey("咖啡厅", 3, "Cafe");


    public static RestaurantKey This
    {
        get
        {
            var gameRecord = DBManager.Inst.Query<Data_GameRecord>();
            foreach (var node in All)
            {
                if (node.Index == gameRecord.ArriveRestaurant)
                {
                    return node;
                }
            }

            return null;
        }
    }

    public static RestaurantKey[] All = { Breakfast };

    public static string Map(int id)
    {
        for (int i = 0; i < All.Length; i++)
        {
            var node = All[i];
            if (node.Index == id)
            {
                return node.Key;
            }
        }

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

        return Unknown.Index;
    }

    public static RestaurantKey Wrap(string id)
    {
        for (int i = 0; i < All.Length; i++)
        {
            var node = All[i];
            if (node.Key == id)
            {
                return node;
            }
        }

        return Unknown;
    }

    public static RestaurantKey Wrap(int id)
    {
        for (int i = 0; i < All.Length; i++)
        {
            var node = All[i];
            if (node.Index == id)
            {
                return node;
            }
        }

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
        dropdown.Add(Unknown.Key, Unknown.Key);
        foreach (var node in All)
        {
            dropdown.Add(node.Key, node.Key);
        }

        return dropdown;
    }
#endif
}