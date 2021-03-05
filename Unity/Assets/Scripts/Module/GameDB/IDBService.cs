using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public interface IDBService
{
    int Order { get; }
    UniTask<T> Query<T>(string userId = "") where T : DBDefine;
    UniTask<DBDefine> Query(Type type, string userId = "");
    void Update<T>(T value) where T : DBDefine;
}
