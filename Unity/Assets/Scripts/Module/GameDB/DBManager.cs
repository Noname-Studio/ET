using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;

public partial class DBManager : IDBService
{
    private static DBManager _inst;
    public static DBManager Inst => _inst ?? (_inst = new DBManager());
    public int Order => -1;
    private List<IDBService> mDBServices = new List<IDBService>();
    private DBManager()
    {
        //TODO 这里加入对服务器的判断.然后添加加载DB设置
        mDBServices.Add(new LocalDB());
        //mDBServices.Add(resolver.Resolve<ServerDB>());
    }

    public async UniTask<T> Query<T>(string userId = "") where T : DBDefine
    {
        return (T) await Query(typeof(T), userId);
    }

    public async UniTask<DBDefine> Query(Type type, string userId = "")
    {
        var service = GetPriorityService();
        if (service == null)
        {
            throw new Exception("你必须注册至少一个DB服务才能查询！！");
        }
        return await service.Query(type,userId);
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

    public void Update<T>(T value) where T : DBDefine
    {
        for (int i = 0; i < mDBServices.Count; i++)
        {
            var node = mDBServices[i];
            node.Update(value);
        }
    }
}
