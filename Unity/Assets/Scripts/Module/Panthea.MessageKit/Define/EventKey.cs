using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct EventKey
{
    public string Key;

    private EventKey(string key)
    {
        Key = key;
    }

    public static EventKey OnPlatformLogin = new EventKey(nameof(OnPlatformLogin));
    public static EventKey R2C_GetItemList = new EventKey(nameof(R2C_GetItemList));
    public static EventKey R2C_Login = new EventKey(nameof(R2C_Login));
    public static EventKey PlayerMoneyChanged = new EventKey(nameof(PlayerMoneyChanged));
    public static EventKey PlayerGemChanged = new EventKey(nameof(PlayerGemChanged));
    public static EventKey OnApplicationFocus = new EventKey(nameof(OnApplicationFocus));
    public static EventKey OnApplicationPause = new EventKey(nameof(OnApplicationPause));
    public static EventKey AdsRewarded = new EventKey(nameof(AdsRewarded));
    public static EventKey AdsSkipped = new EventKey(nameof(AdsSkipped));
    public static EventKey AdsFailed = new EventKey(nameof(AdsFailed));
    public static EventKey AdsReady = new EventKey(nameof(AdsReady));
    public static EventKey GuildChanged = new EventKey(nameof(GuildChanged));
    public static EventKey CurEnergyChange = new EventKey(nameof (CurEnergyChange));
    public static EventKey MaxEnergyChange = new EventKey(nameof (MaxEnergyChange));
    public static EventKey SyncServer = new EventKey(nameof (SyncServer));
    public static EventKey InfineEnergyChange = new EventKey(nameof (InfineEnergyChange));
    public static EventKey GainGameCoin = new EventKey(nameof (GainGameCoin));
    public static EventKey SpentGameCoin = new EventKey(nameof (SpentGameCoin));
    public static EventKey GainGem = new EventKey(nameof (GainGem));
    public static EventKey SpentGem = new EventKey(nameof (SpentGem));
}
