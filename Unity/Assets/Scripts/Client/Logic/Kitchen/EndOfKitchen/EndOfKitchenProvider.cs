using System;
using System.Collections.Generic;
using System.Linq;
using Kitchen;

public enum KitchenEndState
{
    Win,
    Fail,
    Restart
}

/// <summary>
/// 餐厅结束检测
/// 挂载了该服务得餐厅.
/// 每帧会检测餐厅得通关条件或者失败条件是否达成
/// 如果条件达成则发送事件
/// </summary>
public class EndOfKitchenProvider
{
    private IEndExecute EndHandler { get; }
    private LevelProperty LevelProperty { get; }
    private KitchenRecord Record { get; }
    private Requirements Requirements { get; }
    private Dictionary<LevelType, bool> GamePass { get; }

    public EndOfKitchenProvider(IEndExecute endEndHandler, LevelProperty levelProperty)
    {
        EndHandler = endEndHandler;
        LevelProperty = levelProperty;
        Record = KitchenRoot.Inst.Record;
        Requirements = LevelProperty.Requirements;
        GamePass = new Dictionary<LevelType, bool>();
        var levelType = LevelProperty.Type;

        if (levelType.HasFlag(LevelType.FixedTime))
        {
        }
        else if (levelType.HasFlag(LevelType.NumberOfCustomerService))
        {
        }

        foreach (var value in Enum.GetValues(typeof (LevelType)).Cast<LevelType>())
        {
            if (levelType.HasFlag(value))
            {
                GamePass.Add(value, false);
            }
        }
    }

    public void Update()
    {
        if (!Requirements.AllowBurn)
        {
            if (Record.BurnFoodCount > 0)
            {
                EndHandler.Execute(KitchenEndState.Fail);
            }
        }

        if (!Requirements.AllowLostCustomer)
        {
            if (Record.LostCustomerCount > 0)
            {
                EndHandler.Execute(KitchenEndState.Fail);
            }
        }

        if (!Requirements.AllowUseTrash)
        {
            if (Record.DropFoodCount > 0)
            {
                EndHandler.Execute(KitchenEndState.Fail);
            }
        }

        if (GamePass.ContainsKey(LevelType.LostCustomer))
        {
            if (Record.LostCustomerCount >= Requirements.LostCustomer)
            {
                EndHandler.Execute(KitchenEndState.Fail);
            }
        }

        if (GamePass.ContainsKey(LevelType.FixedTime))
        {
            if (Record.PlayTime >= Requirements.FixedTime)
            {
                GamePass[LevelType.FixedTime] = true;
                EndHandler.Execute(IsWin());
            }
        }

        if (GamePass.ContainsKey(LevelType.Coin))
        {
            if (Record.CoinNumber >= Requirements.RequiredCoin)
            {
                GamePass[LevelType.Coin] = true;
            }
        }

        if (GamePass.ContainsKey(LevelType.LikeCount))
        {
            if (Record.LikeCount >= Requirements.LikeCount)
            {
                GamePass[LevelType.LikeCount] = true;
            }
        }

        if (GamePass.ContainsKey(LevelType.NumberOfCompletedOrders))
        {
            if (Record.ServicesOrderNumber >= Requirements.NumberOfCompletedOrders)
            {
                GamePass[LevelType.NumberOfCompletedOrders] = true;
            }
        }

        if (GamePass.ContainsKey(LevelType.NumberOfCustomerService))
        {
            if (Record.ServicesCustomerNumber >= Requirements.NumberOfCustomerService)
            {
                GamePass[LevelType.NumberOfCustomerService] = true;
                if (!GamePass.ContainsKey(LevelType.FixedTime)) //同时有顾客和有倒计时时.根据倒计时为准
                {
                    EndHandler.Execute(IsWin());
                }
            }
        }

        if (!GamePass.ContainsKey(LevelType.NumberOfCustomerService) && !GamePass.ContainsKey(LevelType.FixedTime))
        {
            KitchenEndState win = IsWin();
            if (win == KitchenEndState.Win)
            {
                EndHandler.Execute(KitchenEndState.Win);
            }
        }
    }

    private KitchenEndState IsWin()
    {
        KitchenEndState state = KitchenEndState.Win;
        foreach (var type in GamePass)
        {
            if (!type.Value)
            {
                state = KitchenEndState.Fail;
                break;
            }
        }

        return state;
    }

    /*public void ForceFail()
    {
        this.EndHandler.Execute(false);
    }*/

    public void Restart()
    {
        EndHandler.Execute(KitchenEndState.Restart);
    }
}