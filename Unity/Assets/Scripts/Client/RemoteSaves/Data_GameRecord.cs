using System.Collections.Generic;
using ProtoBuf;

public class RestaurantRecord
{
    public bool is_open;
    public HashSet<string> open_area = new HashSet<string>();
    //public Dictionary<string, RestaurantObjectPersistence> persistence = new Dictionary<string, RestaurantObjectPersistence>();
    public long challenge_stamp;//挑战关卡时间戳
}

[DBContainerKey("/id")]
[ProtoContract]
public class Data_GameRecord : DBDefine
{
    [ProtoMember(0)]
    public List<int> Coin = new List<int>();//金币
    [ProtoMember(1)]
    public int Gem = 10;//点券
    [ProtoMember(2)]
    public int ArriveRestaurant = 2;//到达餐厅
    [ProtoMember(3)]
    public int Level = 2000001;//关卡
}