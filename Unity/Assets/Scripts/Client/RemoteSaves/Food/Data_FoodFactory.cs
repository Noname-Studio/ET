using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using RemoteSaves;

public class Data_FoodFactory
{
    private static Dictionary<RestaurantKey, Data_Food_DBDefine> mCacheDB = new Dictionary<RestaurantKey, Data_Food_DBDefine>();

    public static Data_Food_Info Get(string key, RestaurantKey rest)
    {
        if (key.StartsWith("F_"))
        {
            key = key.Remove(0, 2);
        }

        Data_Food_DBDefine db = Get(rest);
        return db?.Get(key);
    }

    public static Data_Food_DBDefine Get(RestaurantKey rest)
    {
        if (!mCacheDB.TryGetValue(rest, out var db))
        {
            db = (Data_Food_DBDefine) DBManager.Inst.Query(typeof (Data_Food_DBDefine).Assembly.GetType("Data_Food_" + rest.Key));
            mCacheDB[rest] = db;
        }

        return db;
    }

    public static void Set(string key, RestaurantKey rest, Data_Food_Info value)
    {
        Data_Food_DBDefine db;
        if (!mCacheDB.TryGetValue(rest, out db))
        {
            db = (Data_Food_DBDefine) DBManager.Inst.Query(typeof (Data_Food_DBDefine).Assembly.GetType("Data_Food_" + rest.Key));
            mCacheDB[rest] = db;
        }

        db?.Set(key, value);
    }
}