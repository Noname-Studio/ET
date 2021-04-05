public class FoodUpgradeSuccess: IEventHandle
{
    public string Key { get; set; }

    public FoodUpgradeSuccess(string key)
    {
        Key = key;
    }
}