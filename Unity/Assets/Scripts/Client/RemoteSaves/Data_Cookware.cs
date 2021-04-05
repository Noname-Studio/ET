using System;
using System.Collections.Generic;
using ProtoBuf;

//因为MPC生成代码必须要使用公用变量.所以下方的Info变量都必须是Public否则无法生成代码
public class Data_Cookware: DBDefine
{
    public class Info
    {
        public int Level;
    }

    public Info K2_GrillPan { get; set; }
    public Info K2_Toastoven { get; set; }
    public Info K2_Coffee_Machine { get; set; }
    public Info K2_HoldingPlate { get; set; }

    private Dictionary<string, Func<Data_Cookware, Info>> GetMappings = new Dictionary<string, Func<Data_Cookware, Info>>();
    private Dictionary<string, Action<Data_Cookware, Info>> SetMappings = new Dictionary<string, Action<Data_Cookware, Info>>();

    public Data_Cookware()
    {
        var properties = GetType().GetProperties();
        foreach (var node in properties)
        {
            var getter = (Func<Data_Cookware, Info>) node.GetMethod.CreateDelegate(typeof (Func<Data_Cookware, Info>));
            GetMappings.Add(node.Name, getter);
            var setter = (Action<Data_Cookware, Info>) node.SetMethod.CreateDelegate(typeof (Action<Data_Cookware, Info>));
            SetMappings.Add(node.Name, setter);
        }
    }

    public void Set(string key, Info info)
    {
        Action<Data_Cookware, Info> setter;
        if (SetMappings.TryGetValue(key, out setter))
        {
            setter(this, info);
        }
    }

    public Info Get(string key)
    {
        Func<Data_Cookware, Info> getter;
        if (GetMappings.TryGetValue(key, out getter))
        {
            return getter(this);
        }

        return null;
    }
}