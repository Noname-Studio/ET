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
    private Dictionary<Type, DBDefine> mMapping = new Dictionary<Type, DBDefine>();
    public int Order => 1;

    /// <summary>
    /// 仅调用DBManager.UpdateLocal的时候触发.告诉系统这个文件需要同步到服务器
    /// </summary>
    public HashSet<Type> NeedSyncToServer { get; set; } = new HashSet<Type>();

    public LocalDB()
    {
    }

    public T Query<T>() where T : DBDefine
    {
        var t = typeof (T);
        return (T) Query(t);
    }

    public DBDefine Query(Type t)
    {
        DBDefine db;
        if (mMapping.TryGetValue(t, out db))
        {
            return db;
        }
        else
        {
            if (File.Exists(mSavePath + PlayerManager.Inst.Id + "/" + t.Name + Extname))
            {
                var str = FileUtils.ReadAndDecodeAllText(mSavePath + PlayerManager.Inst.Id + "/" + t.Name + Extname);
                db = (DBDefine) JsonConvert.DeserializeObject(str, t);
                mMapping.Add(t, db);
                return db;
            }

            db = (DBDefine) Activator.CreateInstance(t);
            mMapping.Add(t, db);
            return db;
        }
    }

    public void Update<T>(T value) where T : DBDefine
    {
        var t = value.GetType();
        var str = JsonConvert.SerializeObject((T) value);
        FileUtils.EncodeAllTextAndWrite(mSavePath + PlayerManager.Inst.Id + "/" + t.Name + Extname, str);
    }
}