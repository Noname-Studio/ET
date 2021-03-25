using System;
using Cysharp.Threading.Tasks;
using Manager;
using UnityEngine;

/// <summary>
/// 切换后厨和餐厅的显示的管理器
/// K: Kitchen后厨
/// R: Restaurant餐厅
/// </summary>
public class KRManager : Singleton<KRManager>
{
    private IGameMode mMode;
    public bool IsKitchen => mMode is NormalKitchenMode;
    
    private KRManager()
    {
    }

    /// <summary>
    /// 切换显示到后厨场景
    /// </summary>
    public async UniTask SwitchToKitchen<T>(LevelProperty property)where T : IKitchenMode
    {
        try
        {
            var kitchen = new NormalKitchenMode(property);
            mMode = kitchen;
            await mMode.Enter();
        }
        catch(Exception e)
        {
            Debug.LogError(e);
        }
    }

    /// <summary>
    /// 切换显示到餐厅场景
    /// </summary>
    public async UniTask SwitchToRestaurant<T>() where T : IRestaurantMode,new()
    {
        try
        {
            var restaurant = new NormalRestaurantMode();
            mMode = restaurant;
            await mMode.Enter();
        }
        catch(Exception e)
        {
            Debug.LogError(e);
        }
    }
}
