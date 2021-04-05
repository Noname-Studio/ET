﻿using Kitchen;
using UnityEngine.Experimental.Rendering.Client.Logic.Helpler;

public partial class PlayerManager: IPlayer
{
    private static PlayerManager mInst;
    public static PlayerManager Inst => mInst ?? (mInst = new PlayerManager());
    public static long Id { get; set; } = 0;

    private MessageKit mMessage;
    private Data_GameRecord mGameRecord;

    /// <summary>
    /// 当前游玩的餐厅(非最大餐厅)
    /// </summary>
    public RestaurantKey PlayingRestaurant { get; set; } = RestaurantKey.Breakfast;

    private PlayerManager()
    {
        mGameRecord = DBManager.Inst.Query<Data_GameRecord>();
        mMessage = MessageKit.Inst;
    }

    /// <summary>
    /// 当前玩家打至关卡
    /// </summary>
    public LevelProperty CurrentLevels
    {
        get
        {
            return KitchenDataHelper.LoadLevel(mGameRecord.Level);
            return null;
        }
    }
    
    public int GetCoin(RestaurantKey rest = null)
    {
        return ResourcesHelper.GetCoin(rest);
    }

    public int GetGem()
    {
        return ResourcesHelper.GetGem();
    }

    public void SetCoin(int coin, RestaurantKey rest = null)
    {
        ResourcesHelper.SetGameCoin(coin);
    }

    public void SetGem(int gem)
    {
        ResourcesHelper.SetGem(gem);
    }
}