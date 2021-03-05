/*
using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using MessagePack;
using ServerMessage;
using UnityEngine;

public class ServerDB : IDBService
{
    public int Order => 10;
    private ClientHandler mClient;
    Dictionary<Type,DBDefine> mMapping = new Dictionary<Type, DBDefine>();
    private ServerDB(ClientHandler client)
    {
        mClient = client;
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
            var request = new FetchDBRequest();
            request.TypeName = t.Name;
            var response = (FetchDBResponse)await mClient.Call(request);
            var dbContent = (DBDefine) MessagePackSerializer.Deserialize(Type.GetType(response.TypeName), response.DBContent);
            mMapping.Add(t, dbContent);
            return dbContent;
        }
    }

    /// <summary>
    /// 目前我们暂时无法根据修改的变量传递数据.
    /// 但是在未来我们会解决这个问题.以减少不必要的网络流量损失.
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="T"></typeparam>
    public void Update<T>(T value) where T : DBDefine
    {
        var request = new UpdateDBRequest();
        request.DBContent = MessagePackSerializer.Serialize(value);
        request.TypeName = typeof(T).Name;
        mClient.Send(request);
    }
}
*/
