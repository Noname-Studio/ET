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

    public static readonly EventKey OnPlatformLogin = new EventKey(nameof (OnPlatformLogin));
    public static readonly EventKey R2C_GetItemList = new EventKey(nameof (R2C_GetItemList));
    public static readonly EventKey R2C_Login = new EventKey(nameof (R2C_Login));
    public static readonly EventKey PlayerMoneyChanged = new EventKey(nameof (PlayerMoneyChanged));
    public static readonly EventKey PlayerGemChanged = new EventKey(nameof (PlayerGemChanged));
    public static readonly EventKey OnApplicationFocus = new EventKey(nameof (OnApplicationFocus));
    public static readonly EventKey OnApplicationPause = new EventKey(nameof (OnApplicationPause));
    public static readonly EventKey AdsRewarded = new EventKey(nameof (AdsRewarded));
    public static readonly EventKey AdsSkipped = new EventKey(nameof (AdsSkipped));
    public static readonly EventKey AdsFailed = new EventKey(nameof (AdsFailed));
    public static readonly EventKey AdsReady = new EventKey(nameof (AdsReady));
    public static readonly EventKey GuildChanged = new EventKey(nameof (GuildChanged));
    public static readonly EventKey CurEnergyChange = new EventKey(nameof (CurEnergyChange));
    public static readonly EventKey MaxEnergyChange = new EventKey(nameof (MaxEnergyChange));
    public static readonly EventKey SyncServer = new EventKey(nameof (SyncServer));
    public static readonly EventKey InfineEnergyChange = new EventKey(nameof (InfineEnergyChange));
    public static readonly EventKey GainGameCoin = new EventKey(nameof (GainGameCoin));
    public static readonly EventKey SpentGameCoin = new EventKey(nameof (SpentGameCoin));
    public static readonly EventKey GainGem = new EventKey(nameof (GainGem));
    public static readonly EventKey SpentGem = new EventKey(nameof (SpentGem));
    public static readonly EventKey LevelFail = new EventKey(nameof (LevelFail));
    public static readonly EventKey LevelComplete = new EventKey(nameof (LevelComplete));
    public static readonly EventKey RestartLevel = new EventKey(nameof (RestartLevel));
    public static readonly EventKey GuildAskEnergyChanged = new EventKey(nameof (GuildAskEnergyChanged));
    public static readonly EventKey IAPPurchaseSuccess = new EventKey(nameof (IAPPurchaseSuccess));
    public static readonly EventKey IAPPurchaseFailed = new EventKey(nameof (IAPPurchaseFailed));
    public static readonly EventKey StartConnectToServer = new EventKey(nameof (StartConnectToServer));
    public static readonly EventKey ConnectionFailure = new EventKey(nameof (ConnectionFailure));
    public static readonly EventKey ConnectionSucceeded = new EventKey(nameof (ConnectionSucceeded));
}