using System;

public class Data_Prop: DBDefine
{
    public int Extinguisher { get; set; } = 1;
    public int DoubleCoin { get; set; } = 1;
    public int FirePower { get; set; } = 1;
    public int ComboHelper { get; set; } = 1;
    public int SecondChance { get; set; } = 1;
    public int Add3Cus { get; set; } = 1;
    public int Add30Sec { get; set; } = 1;
    public int InfinitePatient { get; set; } = 1;

    private Action<int> SetExtinguisher { get; }
    private Action<int> SetDoubleCoin { get; }
    private Action<int> SetFirePower { get; }
    private Action<int> SetComboHelper { get; }
    public Action<int> SetSecondChance { get; } 
    public Action<int> SetAdd3Cus { get; }
    public Action<int> SetAdd30Sec { get; }
    public Action<int> SetInfinitePatient { get;  }

    public Data_Prop()
    {
        SetExtinguisher = i => Extinguisher = i;
        SetDoubleCoin = i => DoubleCoin = i;
        SetFirePower = i => FirePower = i;
        SetComboHelper = i => ComboHelper = i;
        SetSecondChance = i => SecondChance = i;
        SetAdd3Cus = i => Add3Cus = i;
        SetAdd30Sec = i => Add30Sec = i;
        SetInfinitePatient = i => InfinitePatient = i;
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
        else if (key == nameof (SecondChance))
        {
            return SetSecondChance;
        }
        else if (key == nameof (Add3Cus))
        {
            return SetAdd3Cus;
        }
        else if (key == nameof (Add30Sec))
        {
            return SetAdd30Sec;
        }
        else if (key == nameof (InfinitePatient))
        {
            return SetInfinitePatient;
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
        else if (key == nameof(SecondChance))
        {
            return SecondChance;
        }
        else if (key == nameof (Add3Cus))
        {
            return Add3Cus;
        }
        else if (key == nameof(Add30Sec))
        {
            return Add30Sec;
        }
        else if (key == nameof (InfinitePatient))
        {
            return InfinitePatient;
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