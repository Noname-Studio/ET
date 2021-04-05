using System;
using System.Collections.Generic;
using Client.UI.ViewModel;
using Cysharp.Threading.Tasks;
using FairyGUI;
using Manager;
using UnityEngine;

/// <summary>
/// 切换后厨和餐厅的显示的管理器
/// K: Kitchen后厨
/// R: Restaurant餐厅
/// </summary>
public class KRManager: Singleton<KRManager>
{
    private IGameMode PrevMode { get; set; }
    private IGameMode Mode { get; set; }
    public bool IsKitchen => Mode is NormalKitchenMode;

    private KRManager()
    {
    }

    /// <summary>
    /// 切换显示到后厨场景
    /// </summary>
    public async UniTask SwitchToKitchen<T>(LevelProperty property, List<string> usedProp, bool visible = true) where T : IKitchenMode
    {
        try
        {
            var kitchen = new NormalKitchenMode(property, usedProp);
            var loading = UIKit.Inst.Create<UI_Loading>();
            await UniTask.NextFrame();
            if (Mode != null)
            {
                await Mode.Exit();
            }

            loading.AddTask(kitchen.Enter());
            if (visible == false)
            {
                GRoot.inst.RemoveChild(loading.View);
            }

            await loading.StartTask();
            SwitchMode(kitchen);
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }
    }

    /// <summary>
    /// 切换显示到餐厅场景
    /// </summary>
    public async UniTask SwitchToRestaurant<T>(bool visible = true) where T : IRestaurantMode, new()
    {
        try
        {
            var loading = UIKit.Inst.Create<UI_Loading>();
            await UniTask.NextFrame();
            var restaurant = new T();
            if (Mode != null)
            {
                await Mode.Exit();
            }

            loading.AddTask(restaurant.Enter());
            if (visible == false)
            {
                GRoot.inst.RemoveChild(loading.View);
            }

            await loading.StartTask();
            SwitchMode(restaurant);
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }
    }

    public async UniTask SwitchToRestaurant(Type type,bool visible = true)
    {
        try
        {
            var loading = UIKit.Inst.Create<UI_Loading>();
            await UniTask.NextFrame();
            var restaurant = (IRestaurantMode) Activator.CreateInstance(type);
            if (Mode != null)
            {
                loading.AddTask(Mode.Exit());
            }

            loading.AddTask(restaurant.Enter());
            if (visible == false)
            {
                GRoot.inst.RemoveChild(loading.View);
            }

            await loading.StartTask();
            SwitchMode(restaurant);
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }
    }
    
    private void SwitchMode(IGameMode mode)
    {
        PrevMode = Mode;
        Mode = mode;
    }
    
    public async UniTask BackPrevMode()
    {
        if (PrevMode is IRestaurantMode)
            await SwitchToRestaurant(PrevMode.GetType());
        else
        {
            Log.Error("暂不支持该格式");
        }
    }
}