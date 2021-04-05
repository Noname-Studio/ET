using System;

public class Data_Prop: DBDefine
{
    public int Extinguisher { get; set; } = 1;
    public int DoubleCoin { get; set; } = 1;
    public int FirePower { get; set; } = 1;
    public int ComboHelper { get; set; } = 1;
    private Action<int> SetExtinguisher { get; }
    private Action<int> SetDoubleCoin { get; }
    private Action<int> SetFirePower { get; }
    private Action<int> SetComboHelper { get; }

    public Data_Prop()
    {
        SetExtinguisher = i => Extinguisher = i;
        SetDoubleCoin = i => DoubleCoin = i;
        SetFirePower = i => FirePower = i;
        SetComboHelper = i => ComboHelper = i;
    }

    private Action<int> GetSetAction(string key)
    {
        if (key == nameof (Extinguisher))
        {
            return SetExtinguisher;
        }
        else if (key == nameof (DoubleCoin))
        {
            return SetDoubleCoin;
        }
        else if (key == nameof (FirePower))
        {
            return SetFirePower;
        }
        else if (key == nameof (ComboHelper))
        {
            return SetComboHelper;
        }

        return null;
    }

    public int GetNumByKey(string key)
    {
        if (key == nameof (Extinguisher))
        {
            return Extinguisher;
        }
        else if (key == nameof (DoubleCoin))
        {
            return DoubleCoin;
        }
        else if (key == nameof (FirePower))
        {
            return FirePower;
        }
        else if (key == nameof (ComboHelper))
        {
            return ComboHelper;
        }

        return 0;
    }

    public int IncrementNumByKey(string key, int count = 1)
    {
        var action = GetSetAction(key);
        if (action == null)
        {
            return -1;
        }

        var num = GetNumByKey(key) + count;
        action(num);
        return num;
    }

    public int DecrementNumByKey(string key, int count = 1)
    {
        var action = GetSetAction(key);
        if (action == null)
        {
            return -1;
        }

        var num = GetNumByKey(key) - count;
        action(num);
        return num;
    }
}