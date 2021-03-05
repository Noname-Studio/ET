using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBFurniture
{
    public int Index;
    public string Animation;
}

public class Data_FurnitureBase : DBDefine
{
    /// <summary>
    /// 当前活跃的家具
    /// 或者说是当前替换的家具索引
    /// </summary>
    public List<DBFurniture> ActiveFurniture = new List<DBFurniture>();
    /// <summary>
    /// 已购买的家具索引
    /// </summary>
    public Dictionary<string,int[]> Bought = new Dictionary<string, int[]>();
}
