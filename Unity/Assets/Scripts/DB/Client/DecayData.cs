public class DecayData
{
    public float Interval; // 衰减间隔
    public float Rate; // 每次衰减比例
    public float Limit; // 衰减极限值
    public DecayData()
    {
    }

    public DecayData(float interval, float rate, float limit = -1)
    {
        Interval = interval;
        Rate = rate;
        Limit = limit;
    }
}

public class ComboConfig
{
    public float Gain = 0.35f; // 连击增益系数
}