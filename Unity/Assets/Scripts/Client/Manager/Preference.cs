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
        get => mSoundEffectVolume;
        set
        {
            mSoundEffectVolume = value;
            Dirty = true;
        }
    }

    public float mMusicVolume = 0;

    public float MusicVolume
    {
        get => mMusicVolume;
        set
        {
            mMusicVolume = value;
            Dirty = true;
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
        if (Dirty == false)
        {
            return;
        }

        Dirty = false;
        var str = JsonConvert.SerializeObject(this);
        PlayerPrefs.SetString(Key, str);
    }
}