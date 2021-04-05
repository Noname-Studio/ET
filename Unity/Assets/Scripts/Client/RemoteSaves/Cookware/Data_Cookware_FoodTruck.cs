using System;
using System.Collections.Generic;
//using MessagePack;
using RemoteSaves;

//[DBContainerKey("/id")]
//[MessagePackObject]
public partial class Data_Cookware_FoodTruck: Data_Cookware_DBDefine
{
    private Dictionary<string, Func<Data_Cookware_FoodTruck, Data_Cookware_Info>> GetMappings =
            new Dictionary<string, Func<Data_Cookware_FoodTruck, Data_Cookware_Info>>();

    private Dictionary<string, Action<Data_Cookware_FoodTruck, Data_Cookware_Info>> SetMappings =
            new Dictionary<string, Action<Data_Cookware_FoodTruck, Data_Cookware_Info>>();

    public Data_Cookware_FoodTruck()
    {
    }

    public override void Set(string key, Data_Cookware_Info info)
    {
        Action<Data_Cookware_FoodTruck, Data_Cookware_Info> setter;
        if (SetMappings.TryGetValue(key, out setter))
        {
            setter(this, info);
        }
    }

    public override Data_Cookware_Info Get(string key)
    {
        Func<Data_Cookware_FoodTruck, Data_Cookware_Info> getter;
        if (GetMappings.TryGetValue(key, out getter))
        {
            return getter(this);
        }

        return null;
    }
}