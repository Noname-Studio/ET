using System;
using System.Collections.Generic;
using System.IO;
using Cysharp.Threading.Tasks;
using ET;

public class LocalDB : IDBService
{
    private static readonly string mSavePath = GameConfig.PersistentDataPath + "/DB/Local/";
    private const string Extname = ".json"; 
    Dictionary<Type,DBDefine> mMapping = new Dictionary<Type, DBDefine>();
    public int Order => 1;

    public LocalDB()
    {
    }

    public async UniTask<T> Query<T>(string userId) where T : DBDefine
    {
        var t = typeof(T);
        return (T) await Query(t, userId); 
    }

    public async UniTask<DBDefine> Query(Type t, string userId)
    {
        DBDefine db;
        if (mMapping.TryGetValue(t, out db))
        {
            return db;
        }
        else
        {
            if (File.Exists(mSavePath + t.Name))
            {
                var bytes = File.ReadAllBytes(mSavePath + t.Name + Extname);
                db = (DBDefine) ProtobufHelper.FromBytes(t, bytes, 0, bytes.Length);
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
            var bytes = ProtobufHelper.ToBytes((T)db);
            File.WriteAllBytes(mSavePath + t.Name + Extname, bytes);
        }
    }
}
