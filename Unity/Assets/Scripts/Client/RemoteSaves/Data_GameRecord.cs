using System.Collections.Generic;

public class RestaurantRecord
{
    public bool is_open;

    public HashSet<string> open_area = new HashSet<string>();

    //public Dictionary<string, RestaurantObjectPersistence> persistence = new Dictionary<string, RestaurantObjectPersistence>();
    public long challenge_stamp; //挑战关卡时间戳
}

public class Data_GameRecord: DBDefine
{
    public Dictionary<int, int> mCoin = new Dictionary<int, int>(); //金币

    public int Coin
    {
        get
        {
            if (!mCoin.TryGetValue(1, out int value))
            {
                value = mCoin[1] = 0;
            }

            return value;
        }
        set => mCoin[1] = value;
    }

    public int Gem = 10; //点券
    public int ArriveRestaurant { get; set; } = 2; //到达餐厅
    public int Level { get; set; } = 2000001; //关卡
    public int InfineEnergy { get; set; } = -1;
    public int Energy { get; set; } = 5;
    public int MaxEnergy { get; set; } = 5;
    public long CosumeEnergy { get; set; } = -1;
    public string Name { get; set; } = "Player";
    public string Head { get; set; } = "ui://Settings/0";
}