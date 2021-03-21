using System;
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
    public void SwitchToKitchen(LevelProperty property)
    {
        try
        {
            var kitchen = new NormalKitchenMode(property);
            mMode = kitchen;
            mMode.Enter();
        }
        catch(Exception e)
        {
            Debug.LogError(e);
        }
    }

    /// <summary>
    /// 切换显示到餐厅场景
    /// </summary>
    public void SwitchToStory()
    {
        //try
        //{
        //    mMode = mContainer.Instantiate<NormalRestaurantMode>();
        //    mMode.Enter();
        //}
        //catch(Exception e)
        //{
        //    Debug.LogError("切换到餐厅场景发生错误，检查一下错误内容\n" + e);
        //}
    }
}
