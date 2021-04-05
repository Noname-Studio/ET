using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using RemoteSaves;

public class Data_CookwareFactory
{
    private static Dictionary<RestaurantKey, Data_Cookware_DBDefine> mCacheDB = new Dictionary<RestaurantKey, Data_Cookware_DBDefine>();

    public static Data_Cookware_Info Get(string key, RestaurantKey rest)
    {
        Data_Cookware_DBDefine db;
        if (!mCacheDB.TryGetValue(rest, out db))
        {
            db = (Data_Cookware_DBDefine) DBManager.Inst.Query(typeof (Data_Cookware_DBDefine).Assembly.GetType("Data_Cookware_" + rest.Key));
            mCacheDB[rest] = db;
        }

        return db?.Get(key);
    }

    public static void Set(string key, RestaurantKey rest, Data_Cookware_Info value)
    {
        Data_Cookware_DBDefine db;
        if (!mCacheDB.TryGetValue(rest, out db))
        {
            db = (Data_Cookware_DBDefine) DBManager.Inst.Query(typeof (Data_Cookware_DBDefine).Assembly.GetType("Data_Cookware_" + rest.Key));
            mCacheDB[rest] = db;
        }

        db?.Set(key, value);
    }
}