public struct CookwareUpgradeSuccess: IEventHandle
{
    public string Key { get; set; }

    public CookwareUpgradeSuccess(string key)
    {
        Key = key;
    }
}