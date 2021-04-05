using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public interface IDBService
{
    int Order { get; }
    T Query<T>() where T : DBDefine;
    DBDefine Query(Type type);
    void Update<T>(T value) where T : DBDefine;
}