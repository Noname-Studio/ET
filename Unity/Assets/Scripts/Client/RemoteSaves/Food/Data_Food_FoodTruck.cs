using System;
using System.Collections.Generic;
//using MessagePack;
using RemoteSaves;

//[DBContainerKey("/id")]
//[MessagePackObject]
public partial class Data_Food_FoodTruck: Data_Food_DBDefine
{
    /*[Key(5)]*/
    public Data_Food_Info BurnedFood { get; set; }

    private Dictionary<string, Func<Data_Food_FoodTruck, Data_Food_Info>> GetMappings =
            new Dictionary<string, Func<Data_Food_FoodTruck, Data_Food_Info>>();

    private Dictionary<string, Action<Data_Food_FoodTruck, Data_Food_Info>> SetMappings =
            new Dictionary<string, Action<Data_Food_FoodTruck, Data_Food_Info>>();

    public Data_Food_FoodTruck()
    {
        GetMappings.Add("BurnedFood", (t) => t.BurnedFood ?? (t.BurnedFood = new Data_Food_Info()));
        SetMappings.Add("BurnedFood", (t1, t2) => t1.BurnedFood = t2);
    }

    public override void Set(string key, Data_Food_Info info)
    {
        Action<Data_Food_FoodTruck, Data_Food_Info> setter;
        if (SetMappings.TryGetValue(key, out setter))
        {
            setter(this, info);
        }
    }

    public override Data_Food_Info Get(string key)
    {
        Func<Data_Food_FoodTruck, Data_Food_Info> getter;
        if (GetMappings.TryGetValue(key, out getter))
        {
            return getter(this);
        }

        return null;
    }
}