using System;
using System.Collections.Generic;
using System.Linq;
using Kitchen;
using Kitchen.Enum;
using RestaurantPreview.Config;

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
    private LevelProperty.RequirementsData Requirements { get; }
    private Dictionary<LevelProperty.LevelTypeFlags, bool> GamePass { get; }

    public EndOfKitchenProvider(IEndExecute endEndHandler, LevelProperty levelProperty)
    {
        EndHandler = endEndHandler;
        LevelProperty = levelProperty;
        Record = KitchenRoot.Inst.Record;
        Requirements = LevelProperty.Requirements;
        GamePass = new Dictionary<LevelProperty.LevelTypeFlags, bool>();
        var levelType = LevelProperty.LevelType;

        foreach (var value in Enum.GetValues(typeof (LevelProperty.LevelTypeFlags)).Cast<LevelProperty.LevelTypeFlags>())
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

        if (GamePass.ContainsKey(LevelProperty.LevelTypeFlags.固定时间))
        {
            if (Record.PlayTime >= Requirements.FixedTime)
            {
                GamePass[LevelProperty.LevelTypeFlags.固定时间] = true;
                var win = IsWin();
                EndHandler.Execute(win, win == KitchenEndState.Win? CauseFailCode.None : CauseFailCode.OutOfTime);
            }
        }

        if (GamePass.ContainsKey(LevelProperty.LevelTypeFlags.收集金币))
        {
            if (Record.CoinNumber >= Requirements.RequiredCoin)
            {
                GamePass[LevelProperty.LevelTypeFlags.收集金币] = true;
            }
        }

        if (GamePass.ContainsKey(LevelProperty.LevelTypeFlags.点赞数量))
        {
            if (Record.LikeCount >= Requirements.LikeCount)
            {
                GamePass[LevelProperty.LevelTypeFlags.点赞数量] = true;
            }
        }

        if (GamePass.ContainsKey(LevelProperty.LevelTypeFlags.服务订单))
        {
            if (Record.ServicesOrderNumber >= Requirements.NumberOfCompletedOrders)
            {
                GamePass[LevelProperty.LevelTypeFlags.服务订单] = true;
            }
        }

        if (GamePass.ContainsKey(LevelProperty.LevelTypeFlags.服务顾客))
        {
            if (Record.ServicesCustomerNumber >= Requirements.NumberOfCustomerService)
            {
                GamePass[LevelProperty.LevelTypeFlags.服务顾客] = true;
                if (!GamePass.ContainsKey(LevelProperty.LevelTypeFlags.固定时间)) //同时有顾客和有倒计时时.根据倒计时为准
                {
                    EndHandler.Execute(IsWin());
                }
            }
            //已经没有剩余顾客了.我们弹出失败
            /*if (KitchenRoot.Inst.CustomerProvider.RemainingCustomer == 0 && !KitchenRoot.Inst.CustomerProvider.HasActiveCustomer())
            {
                EndHandler.Execute(KitchenEndState.Fail, CauseFailCode.NotEnoughCustomers);
            }*/
        }

        if (!GamePass.ContainsKey(LevelProperty.LevelTypeFlags.服务顾客) && !GamePass.ContainsKey(LevelProperty.LevelTypeFlags.固定时间))
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