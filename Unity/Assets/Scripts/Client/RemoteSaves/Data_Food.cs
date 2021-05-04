using System;
using System.Collections.Generic;
using ProtoBuf;
using RestaurantPreview.Config;

//因为MPC生成代码必须要使用公用变量.所以下方的Info变量都必须是Public否则无法生成代码
public class Data_Food: DBDefine
{
    public class Info
    {
        public int Level;
    }

    public Dictionary<string, Info> Levels = new Dictionary<string, Info>();
    public Info Get(string key, RestaurantKey restaurantKey)
    {
        if (!Levels.TryGetValue(key, out var value))
        {
            Levels.Add(key, value = new Info());
        }
        return value;
    }
    
    public Info Get(FoodProperty property)
    {
        if (!Levels.TryGetValue(property.Id, out var value))
        {
            Levels.Add(property.Id, value = new Info());
        }
        return value;
    }
}