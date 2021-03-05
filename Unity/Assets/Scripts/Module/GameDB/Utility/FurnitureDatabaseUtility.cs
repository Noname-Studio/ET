using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public partial class DBManager 
{
    public async UniTask<Data_FurnitureBase> GetFurnitureByKey(RestaurantKey restKey,string userId)
    {
        var t = typeof(Data_FurnitureBase).Assembly.GetType("Data_" + restKey.Key + "Furniture");
        return (Data_FurnitureBase)await Inst.Query(t, userId);
    }
}
