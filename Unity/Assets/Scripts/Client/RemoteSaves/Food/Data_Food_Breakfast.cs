using System;
using System.Collections.Generic;
//using MessagePack;
using RemoteSaves;

//[DBContainerKey("/id")]
//[MessagePackObject]
public partial class Data_Food_Breakfast: Data_Food_DBDefine
{
    /*[Key(5)]*/
    public Data_Food_Info Avocado_Bacon { get; set; }

    /*[Key(6)]*/
    public Data_Food_Info Bacon { get; set; }

    /*[Key(7)]*/
    public Data_Food_Info Bacon_Benedict_egg { get; set; }

    /*[Key(8)]*/
    public Data_Food_Info Bacon_Sandwiches { get; set; }

    /*[Key(9)]*/
    public Data_Food_Info Baked_Potato { get; set; }

    /*[Key(10)]*/
    public Data_Food_Info Black_Coffee { get; set; }

    /*[Key(11)]*/
    public Data_Food_Info Caesar_Salad { get; set; }

    /*[Key(12)]*/
    public Data_Food_Info ClamSoup { get; set; }

    /*[Key(13)]*/
    public Data_Food_Info Fried_Broccoli { get; set; }

    /*[Key(14)]*/
    public Data_Food_Info Fried_Eggs { get; set; }

    /*[Key(15)]*/
    public Data_Food_Info Fried_Steak { get; set; }

    /*[Key(16)]*/
    public Data_Food_Info Iced_Coffee { get; set; }

    /*[Key(17)]*/
    public Data_Food_Info Lobster_Soup { get; set; }

    /*[Key(18)]*/
    public Data_Food_Info Milkshake { get; set; }

    /*[Key(19)]*/
    public Data_Food_Info Omelette { get; set; }

    /*[Key(20)]*/
    public Data_Food_Info Poached_egg { get; set; }

    /*[Key(21)]*/
    public Data_Food_Info Raw_Chips { get; set; }

    /*[Key(22)]*/
    public Data_Food_Info Roasted_Asparagus { get; set; }

    /*[Key(23)]*/
    public Data_Food_Info Roasted_Tomatoes { get; set; }

    /*[Key(24)]*/
    public Data_Food_Info Steak_Sandwich { get; set; }

    /*[Key(25)]*/
    public Data_Food_Info Steak_With_Broccoli { get; set; }

    /*[Key(26)]*/
    public Data_Food_Info Steak_With_Tamato { get; set; }

    /*[Key(27)]*/
    public Data_Food_Info Toast { get; set; }

    /*[Key(28)]*/
    public Data_Food_Info Tomato_Benedict_egg { get; set; }

    private Dictionary<string, Func<Data_Food_Breakfast, Data_Food_Info>> GetMappings =
            new Dictionary<string, Func<Data_Food_Breakfast, Data_Food_Info>>();

    private Dictionary<string, Action<Data_Food_Breakfast, Data_Food_Info>> SetMappings =
            new Dictionary<string, Action<Data_Food_Breakfast, Data_Food_Info>>();

    public Data_Food_Breakfast()
    {
        GetMappings.Add("Avocado_Bacon", (t) => t.Avocado_Bacon ?? (t.Avocado_Bacon = new Data_Food_Info()));
        GetMappings.Add("Bacon", (t) => t.Bacon ?? (t.Bacon = new Data_Food_Info()));
        GetMappings.Add("Bacon_Benedict_egg", (t) => t.Bacon_Benedict_egg ?? (t.Bacon_Benedict_egg = new Data_Food_Info()));
        GetMappings.Add("Bacon_Sandwiches", (t) => t.Bacon_Sandwiches ?? (t.Bacon_Sandwiches = new Data_Food_Info()));
        GetMappings.Add("Baked_Potato", (t) => t.Baked_Potato ?? (t.Baked_Potato = new Data_Food_Info()));
        GetMappings.Add("Black_Coffee", (t) => t.Black_Coffee ?? (t.Black_Coffee = new Data_Food_Info()));
        GetMappings.Add("Caesar_Salad", (t) => t.Caesar_Salad ?? (t.Caesar_Salad = new Data_Food_Info()));
        GetMappings.Add("ClamSoup", (t) => t.ClamSoup ?? (t.ClamSoup = new Data_Food_Info()));
        GetMappings.Add("Fried_Broccoli", (t) => t.Fried_Broccoli ?? (t.Fried_Broccoli = new Data_Food_Info()));
        GetMappings.Add("Fried_Eggs", (t) => t.Fried_Eggs ?? (t.Fried_Eggs = new Data_Food_Info()));
        GetMappings.Add("Fried_Steak", (t) => t.Fried_Steak ?? (t.Fried_Steak = new Data_Food_Info()));
        GetMappings.Add("Iced_Coffee", (t) => t.Iced_Coffee ?? (t.Iced_Coffee = new Data_Food_Info()));
        GetMappings.Add("Lobster_Soup", (t) => t.Lobster_Soup ?? (t.Lobster_Soup = new Data_Food_Info()));
        GetMappings.Add("Milkshake", (t) => t.Milkshake ?? (t.Milkshake = new Data_Food_Info()));
        GetMappings.Add("Omelette", (t) => t.Omelette ?? (t.Omelette = new Data_Food_Info()));
        GetMappings.Add("Poached_egg", (t) => t.Poached_egg ?? (t.Poached_egg = new Data_Food_Info()));
        GetMappings.Add("Raw_Chips", (t) => t.Raw_Chips ?? (t.Raw_Chips = new Data_Food_Info()));
        GetMappings.Add("Roasted_Asparagus", (t) => t.Roasted_Asparagus ?? (t.Roasted_Asparagus = new Data_Food_Info()));
        GetMappings.Add("Roasted_Tomatoes", (t) => t.Roasted_Tomatoes ?? (t.Roasted_Tomatoes = new Data_Food_Info()));
        GetMappings.Add("Steak_Sandwich", (t) => t.Steak_Sandwich ?? (t.Steak_Sandwich = new Data_Food_Info()));
        GetMappings.Add("Steak_With_Broccoli", (t) => t.Steak_With_Broccoli ?? (t.Steak_With_Broccoli = new Data_Food_Info()));
        GetMappings.Add("Steak_With_Tamato", (t) => t.Steak_With_Tamato ?? (t.Steak_With_Tamato = new Data_Food_Info()));
        GetMappings.Add("Toast", (t) => t.Toast ?? (t.Toast = new Data_Food_Info()));
        GetMappings.Add("Tomato_Benedict_egg", (t) => t.Tomato_Benedict_egg ?? (t.Tomato_Benedict_egg = new Data_Food_Info()));

        SetMappings.Add("Avocado_Bacon", (t1, t2) => t1.Avocado_Bacon = t2);
        SetMappings.Add("Bacon", (t1, t2) => t1.Bacon = t2);
        SetMappings.Add("Bacon_Benedict_egg", (t1, t2) => t1.Bacon_Benedict_egg = t2);
        SetMappings.Add("Bacon_Sandwiches", (t1, t2) => t1.Bacon_Sandwiches = t2);
        SetMappings.Add("Baked_Potato", (t1, t2) => t1.Baked_Potato = t2);
        SetMappings.Add("Black_Coffee", (t1, t2) => t1.Black_Coffee = t2);
        SetMappings.Add("Caesar_Salad", (t1, t2) => t1.Caesar_Salad = t2);
        SetMappings.Add("ClamSoup", (t1, t2) => t1.ClamSoup = t2);
        SetMappings.Add("Fried_Broccoli", (t1, t2) => t1.Fried_Broccoli = t2);
        SetMappings.Add("Fried_Eggs", (t1, t2) => t1.Fried_Eggs = t2);
        SetMappings.Add("Fried_Steak", (t1, t2) => t1.Fried_Steak = t2);
        SetMappings.Add("Iced_Coffee", (t1, t2) => t1.Iced_Coffee = t2);
        SetMappings.Add("Lobster_Soup", (t1, t2) => t1.Lobster_Soup = t2);
        SetMappings.Add("Milkshake", (t1, t2) => t1.Milkshake = t2);
        SetMappings.Add("Omelette", (t1, t2) => t1.Omelette = t2);
        SetMappings.Add("Poached_egg", (t1, t2) => t1.Poached_egg = t2);
        SetMappings.Add("Raw_Chips", (t1, t2) => t1.Raw_Chips = t2);
        SetMappings.Add("Roasted_Asparagus", (t1, t2) => t1.Roasted_Asparagus = t2);
        SetMappings.Add("Roasted_Tomatoes", (t1, t2) => t1.Roasted_Tomatoes = t2);
        SetMappings.Add("Steak_Sandwich", (t1, t2) => t1.Steak_Sandwich = t2);
        SetMappings.Add("Steak_With_Broccoli", (t1, t2) => t1.Steak_With_Broccoli = t2);
        SetMappings.Add("Steak_With_Tamato", (t1, t2) => t1.Steak_With_Tamato = t2);
        SetMappings.Add("Toast", (t1, t2) => t1.Toast = t2);
        SetMappings.Add("Tomato_Benedict_egg", (t1, t2) => t1.Tomato_Benedict_egg = t2);
    }

    public override void Set(string key, Data_Food_Info info)
    {
        Action<Data_Food_Breakfast, Data_Food_Info> setter;
        if (SetMappings.TryGetValue(key, out setter))
        {
            setter(this, info);
        }
    }

    public override Data_Food_Info Get(string key)
    {
        Func<Data_Food_Breakfast, Data_Food_Info> getter;
        if (GetMappings.TryGetValue(key, out getter))
        {
            return getter(this);
        }

        return null;
    }
}