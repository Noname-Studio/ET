using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneKey 
{
    public string Key { get; }
    public int Index { get; }
    public Type LoadType { get; }
    private SceneKey(string key,int index,Type type)
    {
        Key = key;
        Index = index;
        LoadType = type;
    }

    public static SceneKey Entry = new SceneKey("Entry", 0, null);
}
