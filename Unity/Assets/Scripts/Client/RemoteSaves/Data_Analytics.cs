using System;
using System.Collections.Generic;
using RemoteSaves;

public class Data_Analytics : DBDefine
{
    /// <summary>
    /// 连续统计记录,主要统计某些会突然中断的数据
    /// 如连续登录,一旦某天不登陆数据便会中断
    /// </summary>
    public class ConsecutiveLevelsData
    {
        public int TotalBurnFoodCount { get; set; }
        public int TotalDropFoodCount { get; set; }
        public int TotalLostCustomerCount { get; set; }
        public int TotalLevel { get; set; }
        public int TotalLogin { get; set; }
        public int BurnFoodCount { get; set; }
        public int DropFoodCount { get; set; }
        public int LostCustomerCount { get; set; }
        public int Level { get; set; }
        public int Login { get; set; }
    }
    
    public int ServicesOrderNumber { get; set; }
    public int LikeCount { get; set; }
    public int CoinNumber { get; set; }
    public int ServicesCustomerNumber { get; set; }
    public int BurnFoodCount { get; set; }
    public int LostCustomerCount { get; set; }
    public int DropFoodCount { get; set; }
    public float PlayTime { get; set; }
    public int ConsumeCoin { get; set; }
    public int ParticipateGuileLeague { get; set; }
    public int Combo3 { get; set; }
    public int Combo4 { get; set; }
    public int TipsNumber { get; set; }
    /// <summary>
    /// 加入过的公会数量
    /// </summary>
    public int JoinedGuildNumber { get; set; }
    public ConsecutiveLevelsData ConsecutiveLevels { get; } = new ConsecutiveLevelsData();
    public int BreakfastCount
    {
        get
        {
            DBManager.Inst.Query<Data_GameRecord>().Level.TryGetValue(RestaurantKey.Breakfast.Key,out var value);
            return value / GameConfig.RestaurantOffset;
        }
    }
    
    public int CafeCount
    {
        get
        {
            DBManager.Inst.Query<Data_GameRecord>().Level.TryGetValue(RestaurantKey.FoodTruck.Key,out var value);
            return value / GameConfig.RestaurantOffset;
        }
    }

    public int DressupCount
    {
        get
        {
            return DBManager.Inst.Query<Data_GameRecord>().Dressup.Count; 
        }
    }

    public int PetCount
    {
        get
        {
            return DBManager.Inst.Query<Data_GameRecord>().Pet.Count; 
        }
    }

    private Dictionary<string, Func<Data_Analytics, double>> GetMappings =
            new Dictionary<string, Func<Data_Analytics, double>>();

    private Dictionary<string, Action<Data_Analytics, double>> SetMappings =
            new Dictionary<string, Action<Data_Analytics, double>>();
    
    public Data_Analytics()
    {
        GetMappings.Add("ServicesOrderNumber", analytics => analytics.ServicesOrderNumber);
        GetMappings.Add("LikeCount", analytics => analytics.LikeCount);
        GetMappings.Add("CoinNumber", analytics => analytics.CoinNumber);
        GetMappings.Add("ServicesCustomerNumber", analytics => analytics.ServicesCustomerNumber);
        GetMappings.Add("BurnFoodCount", analytics => analytics.BurnFoodCount);
        GetMappings.Add("LostCustomerCount", analytics => analytics.LostCustomerCount);
        GetMappings.Add("DropFoodCount", analytics => analytics.DropFoodCount);
        GetMappings.Add("PlayTime", analytics => analytics.PlayTime);
        GetMappings.Add("ConsumeCoin", analytics => analytics.ConsumeCoin);
        GetMappings.Add("ParticipateGuileLeague", analytics => analytics.ParticipateGuileLeague);
        GetMappings.Add("Combo3", analytics => analytics.Combo3);
        GetMappings.Add("Combo4", analytics => analytics.Combo4);
        GetMappings.Add("TipsNumber", analytics => analytics.TipsNumber);
        GetMappings.Add("ConsecutiveLevels.TotalBurnFoodCount", analytics => analytics.ConsecutiveLevels.TotalBurnFoodCount);
        GetMappings.Add("ConsecutiveLevels.TotalDropFoodCount", analytics => analytics.ConsecutiveLevels.TotalDropFoodCount);
        GetMappings.Add("ConsecutiveLevels.TotalLostCustomerCount", analytics => analytics.ConsecutiveLevels.TotalLostCustomerCount);
        GetMappings.Add("ConsecutiveLevels.TotalLevel", analytics => analytics.ConsecutiveLevels.TotalLevel);
        GetMappings.Add("ConsecutiveLevels.TotalLogin", analytics => analytics.ConsecutiveLevels.TotalLogin);
        GetMappings.Add("ConsecutiveLevels.BurnFoodCount", analytics => analytics.ConsecutiveLevels.BurnFoodCount);
        GetMappings.Add("ConsecutiveLevels.DropFoodCount", analytics => analytics.ConsecutiveLevels.DropFoodCount);
        GetMappings.Add("ConsecutiveLevels.LostCustomerCount", analytics => analytics.ConsecutiveLevels.LostCustomerCount);
        GetMappings.Add("ConsecutiveLevels.Level", analytics => analytics.ConsecutiveLevels.Level);
        GetMappings.Add("ConsecutiveLevels.Login", analytics => analytics.ConsecutiveLevels.Login);
        GetMappings.Add("BreakfastCount", analytics => analytics.BreakfastCount);
        GetMappings.Add("DressupCount", analytics => analytics.DressupCount);
        GetMappings.Add("CafeCount", analytics => analytics.CafeCount);
        GetMappings.Add("PetCount", analytics => analytics.PetCount);
        GetMappings.Add("JoinedGuildNumber", analytics => analytics.JoinedGuildNumber);

        SetMappings.Add("ServicesOrderNumber", (analytics,t1) => analytics.ServicesOrderNumber = (int)t1);
        SetMappings.Add("LikeCount", (analytics,t1) => analytics.LikeCount = (int)t1);
        SetMappings.Add("CoinNumber", (analytics,t1) => analytics.CoinNumber = (int)t1);
        SetMappings.Add("ServicesCustomerNumber", (analytics,t1) => analytics.ServicesCustomerNumber = (int)t1);
        SetMappings.Add("BurnFoodCount", (analytics,t1) => analytics.BurnFoodCount = (int)t1);
        SetMappings.Add("LostCustomerCount", (analytics,t1) => analytics.LostCustomerCount = (int)t1);
        SetMappings.Add("DropFoodCount", (analytics,t1) => analytics.DropFoodCount = (int)t1);
        SetMappings.Add("PlayTime", (analytics,t1) => analytics.PlayTime = (float)t1);
        SetMappings.Add("ConsumeCoin", (analytics,t1) => analytics.ConsumeCoin = (int)t1);
        SetMappings.Add("ParticipateGuileLeague", (analytics,t1) => analytics.ParticipateGuileLeague = (int)t1);
        SetMappings.Add("Combo3", (analytics,t1) => analytics.Combo3 = (int)t1);
        SetMappings.Add("Combo4", (analytics,t1) => analytics.Combo4 = (int)t1);
        SetMappings.Add("TipsNumber", (analytics,t1) => analytics.TipsNumber = (int)t1);
        SetMappings.Add("ConsecutiveLevels.TotalBurnFoodCount", (analytics,t1) => analytics.ConsecutiveLevels.TotalBurnFoodCount = (int)t1);
        SetMappings.Add("ConsecutiveLevels.TotalDropFoodCount", (analytics,t1) => analytics.ConsecutiveLevels.TotalDropFoodCount = (int)t1);
        SetMappings.Add("ConsecutiveLevels.TotalLostCustomerCount", (analytics,t1) => analytics.ConsecutiveLevels.TotalLostCustomerCount = (int)t1);
        SetMappings.Add("ConsecutiveLevels.TotalLevel", (analytics,t1) => analytics.ConsecutiveLevels.TotalLevel = (int)t1);
        SetMappings.Add("ConsecutiveLevels.TotalLogin", (analytics,t1) => analytics.ConsecutiveLevels.TotalLogin = (int)t1);
        SetMappings.Add("ConsecutiveLevels.BurnFoodCount", (analytics,t1) => analytics.ConsecutiveLevels.BurnFoodCount = (int)t1);
        SetMappings.Add("ConsecutiveLevels.DropFoodCount", (analytics,t1) => analytics.ConsecutiveLevels.DropFoodCount = (int)t1);
        SetMappings.Add("ConsecutiveLevels.LostCustomerCount", (analytics,t1) => analytics.ConsecutiveLevels.LostCustomerCount = (int)t1);
        SetMappings.Add("ConsecutiveLevels.Level", (analytics,t1) => analytics.ConsecutiveLevels.Level = (int)t1);
        SetMappings.Add("ConsecutiveLevels.Login", (analytics,t1) => analytics.ConsecutiveLevels.Login = (int)t1);
        SetMappings.Add("JoinedGuildNumber", (analytics,t1) => analytics.JoinedGuildNumber = (int) t1);
    }
    
    public void Set(string key, double value)
    {
        Action<Data_Analytics, double> setter;
        if (SetMappings.TryGetValue(key, out setter))
        {
            setter(this, value);
        }
    }

    public double Get(string key)
    {
        Func<Data_Analytics, double> getter;
        if (GetMappings.TryGetValue(key, out getter))
        {
            return getter(this);
        }
        return 0;
    }
}
