using System;
using System.Collections.Generic;
using System.IO;
using Cysharp.Threading.Tasks;
using ET;
using Module.Panthea.Utils;
using Newtonsoft.Json;

public class LocalDB : IDBService
{
    private static readonly string mSavePath = GameConfig.PersistentDataPath + "/DB/Local/";
    private const string Extname = ".json"; 
    Dictionary<Type,DBDefine> mMapping = new Dictionary<Type, DBDefine>();
    public int Order => 1;

    public LocalDB()
    {
    }

    public T Query<T>(string userId) where T : DBDefine
    {
        var t = typeof(T);
        return (T) Query(t, userId); 
    }

    public DBDefine Query(Type t, string userId)
    {
        DBDefine db;
        if (mMapping.TryGetValue(t, out db))
        {
            return db;
        }
        else
        {
            if (File.Exists(mSavePath + t.Name + Extname))
            {
                var str = FileUtils.ReadAndDecodeAllText(mSavePath + t.Name + Extname);
                db = (DBDefine) JsonConvert.DeserializeObject(str, t);
                mMapping.Add(t, db);
                return db;
            }
            db = (DBDefine) Activator.CreateInstance(t);
            mMapping.Add(t,db);
            return db;
        }
    }

    public void Update<T>(T value) where T : DBDefine
    {
        var t = typeof(T);
        if (mMapping.TryGetValue(t, out DBDefine db))
        {
            var str = JsonConvert.SerializeObject((T)db);
            FileUtils.EncodeAllTextAndWrite(mSavePath + t.Name + Extname,str);
        }
    }
}
