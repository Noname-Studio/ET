using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using RemoteSaves;

public class Data_FoodFactory
{
    private static Dictionary<RestaurantKey,Data_Food_DBDefine> mCacheDB = new Dictionary<RestaurantKey, Data_Food_DBDefine>();
    public static Data_Food_Info Get(string key,RestaurantKey rest)
    {
        Data_Food_DBDefine db;
        if (!mCacheDB.TryGetValue(rest, out db))
        {
            var task = DBManager.Inst.Query(typeof(Data_Food_DBDefine).Assembly.GetType("Data_Food_" + rest.Key)).AsTask();
            db = task.Result as Data_Food_DBDefine;
            mCacheDB[rest] = db;
        }

        return db?.Get(key);
    }
    
    public static void Set(string key,Data_Food_Info value,RestaurantKey rest)
    {
        Data_Food_DBDefine db;
        if (!mCacheDB.TryGetValue(rest, out db))
        {
            var task = DBManager.Inst.Query(typeof(Data_Food_DBDefine).Assembly.GetType("Data_Food_" + rest.Key)).AsTask();
            db = task.Result as Data_Food_DBDefine;
            mCacheDB[rest] = db;
        }

        db?.Set(key, value);
    }
}
