using System;
using Manager;
using Newtonsoft.Json;
using UnityEngine;

public class Preference 
{
    private static string Key { get; } = "com." + Application.companyName + "." + Application.productName + ".Prefs";
    private bool Dirty { get; set; } = false;
    private float mSoundEffectVolume;
    public float SoundEffectVolume
    {
        get => this.mSoundEffectVolume;
        set
        {
            this.mSoundEffectVolume = value;
            this.Dirty = true;
        }
    }
    public float mMusicVolume = 0;
    public float MusicVolume
    {
        get => this.mMusicVolume;
        set
        {
            this.mMusicVolume = value;
            this.Dirty = true;
        }
    }

    private static Preference mInst;
    public static Preference Inst
    {
        get
        {
            if (mInst == null)
            {
                mInst = JsonConvert.DeserializeObject<Preference>(PlayerPrefs.GetString(Key, "")) ?? new Preference();
            }
            return mInst;
        }
    }
    
    public void Save()
    {
        if (this.Dirty == false)
            return;
        this.Dirty = false;
        var str = JsonConvert.SerializeObject(this);
        PlayerPrefs.SetString(Key, str);
    }
}
