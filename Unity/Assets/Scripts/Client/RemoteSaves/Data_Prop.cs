using System;
using System.Collections.Generic;

public class Data_Prop: DBDefine
{
    public class Info
    {
        public int Count { get; set; } = 999;
        public int Level { get; set; } = 1;
    }

    public Dictionary<string, Info> Prop = new Dictionary<string, Info>();

    public Info Get(string propId)
    {
        if (Prop.TryGetValue(propId, out var value))
            return value;
        value = Prop[propId] = new Info();
        return value;
    }
}