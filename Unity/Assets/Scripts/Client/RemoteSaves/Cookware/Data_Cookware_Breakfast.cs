using System;
using System.Collections.Generic;
//using MessagePack;
using RemoteSaves;

//[DBContainerKey("/id")]
//[MessagePackObject]
public partial class Data_Cookware_Breakfast: Data_Cookware_DBDefine
{
    /*[Key(5)]*/
    public Data_Cookware_Info k2_benedicttable { get; set; }

    /*[Key(6)]*/
    public Data_Cookware_Info k2_coffee_machine { get; set; }

    /*[Key(7)]*/
    public Data_Cookware_Info k2_cuttingboard { get; set; }

    /*[Key(8)]*/
    public Data_Cookware_Info k2_grillPan { get; set; }

    /*[Key(9)]*/
    public Data_Cookware_Info k2_holding_plate { get; set; }

    /*[Key(10)]*/
    public Data_Cookware_Info k2_milkshake { get; set; }

    /*[Key(11)]*/
    public Data_Cookware_Info k2_omelette { get; set; }

    /*[Key(12)]*/
    public Data_Cookware_Info k2_oven { get; set; }

    /*[Key(13)]*/
    public Data_Cookware_Info k2_pan { get; set; }

    /*[Key(14)]*/
    public Data_Cookware_Info k2_poachedegg { get; set; }

    /*[Key(15)]*/
    public Data_Cookware_Info k2_soupcooker { get; set; }

    /*[Key(16)]*/
    public Data_Cookware_Info k2_steakBoard { get; set; }

    /*[Key(17)]*/
    public Data_Cookware_Info k2_steakgriddle { get; set; }

    /*[Key(18)]*/
    public Data_Cookware_Info k2_tablecloth { get; set; }

    /*[Key(19)]*/
    public Data_Cookware_Info k2_toastoven { get; set; }

    /*[Key(20)]*/
    public Data_Cookware_Info k2_worktable { get; set; }

    private Dictionary<string, Func<Data_Cookware_Breakfast, Data_Cookware_Info>> GetMappings =
            new Dictionary<string, Func<Data_Cookware_Breakfast, Data_Cookware_Info>>();

    private Dictionary<string, Action<Data_Cookware_Breakfast, Data_Cookware_Info>> SetMappings =
            new Dictionary<string, Action<Data_Cookware_Breakfast, Data_Cookware_Info>>();

    public Data_Cookware_Breakfast()
    {
        GetMappings.Add("k2_benedicttable", (t) => t.k2_benedicttable ?? (t.k2_benedicttable = new Data_Cookware_Info()));
        GetMappings.Add("k2_coffee_machine", (t) => t.k2_coffee_machine ?? (t.k2_coffee_machine = new Data_Cookware_Info()));
        GetMappings.Add("k2_cuttingboard", (t) => t.k2_cuttingboard ?? (t.k2_cuttingboard = new Data_Cookware_Info()));
        GetMappings.Add("k2_grillPan", (t) => t.k2_grillPan ?? (t.k2_grillPan = new Data_Cookware_Info()));
        GetMappings.Add("k2_holding_plate", (t) => t.k2_holding_plate ?? (t.k2_holding_plate = new Data_Cookware_Info()));
        GetMappings.Add("k2_milkshake", (t) => t.k2_milkshake ?? (t.k2_milkshake = new Data_Cookware_Info()));
        GetMappings.Add("k2_omelette", (t) => t.k2_omelette ?? (t.k2_omelette = new Data_Cookware_Info()));
        GetMappings.Add("k2_oven", (t) => t.k2_oven ?? (t.k2_oven = new Data_Cookware_Info()));
        GetMappings.Add("k2_pan", (t) => t.k2_pan ?? (t.k2_pan = new Data_Cookware_Info()));
        GetMappings.Add("k2_poachedegg", (t) => t.k2_poachedegg ?? (t.k2_poachedegg = new Data_Cookware_Info()));
        GetMappings.Add("k2_soupcooker", (t) => t.k2_soupcooker ?? (t.k2_soupcooker = new Data_Cookware_Info()));
        GetMappings.Add("k2_steakBoard", (t) => t.k2_steakBoard ?? (t.k2_steakBoard = new Data_Cookware_Info()));
        GetMappings.Add("k2_steakgriddle", (t) => t.k2_steakgriddle ?? (t.k2_steakgriddle = new Data_Cookware_Info()));
        GetMappings.Add("k2_tablecloth", (t) => t.k2_tablecloth ?? (t.k2_tablecloth = new Data_Cookware_Info()));
        GetMappings.Add("k2_toastoven", (t) => t.k2_toastoven ?? (t.k2_toastoven = new Data_Cookware_Info()));
        GetMappings.Add("k2_worktable", (t) => t.k2_worktable ?? (t.k2_worktable = new Data_Cookware_Info()));

        SetMappings.Add("k2_benedicttable", (t1, t2) => t1.k2_benedicttable = t2);
        SetMappings.Add("k2_coffee_machine", (t1, t2) => t1.k2_coffee_machine = t2);
        SetMappings.Add("k2_cuttingboard", (t1, t2) => t1.k2_cuttingboard = t2);
        SetMappings.Add("k2_grillPan", (t1, t2) => t1.k2_grillPan = t2);
        SetMappings.Add("k2_holding_plate", (t1, t2) => t1.k2_holding_plate = t2);
        SetMappings.Add("k2_milkshake", (t1, t2) => t1.k2_milkshake = t2);
        SetMappings.Add("k2_omelette", (t1, t2) => t1.k2_omelette = t2);
        SetMappings.Add("k2_oven", (t1, t2) => t1.k2_oven = t2);
        SetMappings.Add("k2_pan", (t1, t2) => t1.k2_pan = t2);
        SetMappings.Add("k2_poachedegg", (t1, t2) => t1.k2_poachedegg = t2);
        SetMappings.Add("k2_soupcooker", (t1, t2) => t1.k2_soupcooker = t2);
        SetMappings.Add("k2_steakBoard", (t1, t2) => t1.k2_steakBoard = t2);
        SetMappings.Add("k2_steakgriddle", (t1, t2) => t1.k2_steakgriddle = t2);
        SetMappings.Add("k2_tablecloth", (t1, t2) => t1.k2_tablecloth = t2);
        SetMappings.Add("k2_toastoven", (t1, t2) => t1.k2_toastoven = t2);
        SetMappings.Add("k2_worktable", (t1, t2) => t1.k2_worktable = t2);
    }

    public override void Set(string key, Data_Cookware_Info info)
    {
        Action<Data_Cookware_Breakfast, Data_Cookware_Info> setter;
        if (SetMappings.TryGetValue(key, out setter))
        {
            setter(this, info);
        }
    }

    public override Data_Cookware_Info Get(string key)
    {
        Func<Data_Cookware_Breakfast, Data_Cookware_Info> getter;
        if (GetMappings.TryGetValue(key, out getter))
        {
            return getter(this);
        }

        return null;
    }
}