using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;

public partial class DBManager: IDBService
{
    private static DBManager _inst;
    public static DBManager Inst => _inst ?? (_inst = new DBManager());
    public int Order => -1;
    private List<IDBService> mDBServices = new List<IDBService>();
    /// <summary>
    /// 我们不能使用PlayerManager.Inst.Id,因为PlayerManager有部分内容依赖了DB.使用PlayerManager.Id可能会引发无限循环的Bug
    /// </summary>
    public long UserId { get; set; } = 0;
    private DBManager()
    {
        //TODO 这里加入对服务器的判断.然后添加加载DB设置
        mDBServices.Add(new LocalDB());
        //mDBServices.Add(new ServerDB());
    }

    public T Query<T>() where T : DBDefine
    {
        return (T) Query(typeof (T));
    }

    public DBDefine Query(Type type)
    {
        var service = GetPriorityService();
        if (service == null)
        {
            throw new Exception("你必须注册至少一个DB服务才能查询！！");
        }

        return service.Query(type);
    }

    private IDBService GetPriorityService()
    {
        int order = -1;
        IDBService service = null;
        for (int i = 0; i < mDBServices.Count; i++)
        {
            var node = mDBServices[i];
            if (node.Order > order)
            {
                order = node.Order;
                service = node;
            }
        }

        return service;
    }

    public void UpdateLocal<T>(T value) where T : DBDefine
    {
        var db = GetLocalService();
        db.Update(value);
        db.NeedSyncToServer.Add(value.GetType());
    }

    public void Update<T>(T value) where T : DBDefine
    {
        for (int i = 0; i < mDBServices.Count; i++)
        {
            var node = mDBServices[i];
            node.Update(value);
        }
    }

    public void Update()
    {
        var db = GetLocalService();
        foreach (var node in db.NeedSyncToServer)
        {
            var result = db.Query(node);
            Update(result);
        }
    }

    private LocalDB GetLocalService()
    {
        for (int i = 0; i < mDBServices.Count; i++)
        {
            var node = mDBServices[i];
            if (node is LocalDB db)
            {
                return db;
            }
        }

        var localDb = new LocalDB();
        mDBServices.Add(localDb);
        return localDb;
    }
}