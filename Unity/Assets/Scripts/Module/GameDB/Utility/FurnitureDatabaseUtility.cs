using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public partial class DBManager
{
    public async UniTask<Data_FurnitureBase> GetFurnitureByKey(RestaurantKey restKey)
    {
        var t = typeof (Data_FurnitureBase).Assembly.GetType("Data_" + restKey.Key + "Furniture");
        return (Data_FurnitureBase) Inst.Query(t);
    }
}