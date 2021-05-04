using System;
using System.Collections.Generic;
using System.Linq;
using ET;
using Kitchen;
using RestaurantPreview.Config;
using UnityEngine.Experimental.Rendering.Client.Logic.Helpler;

public partial class PlayerManager: IPlayer
{
    private static PlayerManager mInst;
    public static PlayerManager Inst => mInst ?? (mInst = new PlayerManager());
    public long Id { get; set; } = 0;
    public long GuildId { get; set; } = 0;
    public List<string> AchievementList { get; } = new List<string>();
    private MessageKit mMessage;
    private Data_GameRecord mGameRecord;
    public List<GuildInviteInfo> GuildInvite { get; } = new List<GuildInviteInfo>();
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
    public int CurrentLevel
    {
        get
        {
            int value;
            if (mGameRecord.Level.TryGetValue(RestaurantKey.This.Key, out value))
            {
                return value;
            }
            try
            {
                var @default = mGameRecord.Level.First();
                return @default.Value;
            }
            catch(Exception e)
            {
                Log.Error(e);
                return 0;
            }
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