using Kitchen;

public class PlayerManager : IPlayer
{
    private static PlayerManager mInst;
    public static PlayerManager Inst => mInst ?? (mInst = new PlayerManager());
    
    private MessageKit mMessage;
    private Data_GameRecord mGameRecord;
    private PlayerManager()
    {
        mGameRecord = DBManager.Inst.Query<Data_GameRecord>().GetAwaiter().GetResult();
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
        if(rest == null)
            rest = RestaurantKey.This;
        var coins = mGameRecord.Coin;
        if (coins.Count >= rest.Index)
        {
            return coins[rest.Index - 1];
        }
        return 0;
    }

    public int GetGem()
    {
        return mGameRecord.Gem;
    }

    public void SetCoin(int coin,RestaurantKey rest = null)
    {
        if(rest == null)
            rest = RestaurantKey.This;
        
        var coins = mGameRecord.Coin;
        if (coins.Count >= rest.Index)
        {
            coins[rest.Index - 1] = coin;
        }
    }

    public void SetGem(int gem)
    {
        mGameRecord.Gem = gem;
    }
}
