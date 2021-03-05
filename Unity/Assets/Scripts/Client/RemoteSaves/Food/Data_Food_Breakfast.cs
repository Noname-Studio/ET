using System;
using System.Collections.Generic;
using ProtoBuf;
using RemoteSaves;

[DBContainerKey("/id")]
[ProtoContract]
public partial class Data_Food_Breakfast : Data_Food_DBDefine
{              
    [ProtoMember(0)]public Data_Food_Info Avocado_Bacon { get; set; }
    [ProtoMember(1)]public Data_Food_Info Bacon { get; set; }
    [ProtoMember(2)]public Data_Food_Info Bacon_Benedict_egg { get; set; }
    [ProtoMember(3)]public Data_Food_Info Bacon_Sandwiches { get; set; }
    [ProtoMember(4)]public Data_Food_Info Baked_Potato { get; set; }
    [ProtoMember(5)] public Data_Food_Info Black_Coffee { get; set; }
    [ProtoMember(6)] public Data_Food_Info Caesar_Salad { get; set; }
    [ProtoMember(7)] public Data_Food_Info ClamSoup { get; set; }
    [ProtoMember(8)] public Data_Food_Info Fried_Broccoli { get; set; }
    [ProtoMember(9)] public Data_Food_Info Fried_Eggs { get; set; }
    [ProtoMember(10)] public Data_Food_Info Fried_Steak { get; set; }
    [ProtoMember(11)] public Data_Food_Info Iced_Coffee { get; set; }
    [ProtoMember(12)] public Data_Food_Info Lobster_Soup { get; set; }
    [ProtoMember(13)] public Data_Food_Info Milkshake { get; set; }
    [ProtoMember(14)] public Data_Food_Info Omelette { get; set; }
    [ProtoMember(15)] public Data_Food_Info Poached_egg { get; set; }
    [ProtoMember(16)] public Data_Food_Info Raw_Chips { get; set; }
    [ProtoMember(17)] public Data_Food_Info Roasted_Asparagus { get; set; }
    [ProtoMember(18)] public Data_Food_Info Roasted_Tomatoes { get; set; }
    [ProtoMember(19)] public Data_Food_Info Steak_Sandwich { get; set; }
    [ProtoMember(20)] public Data_Food_Info Steak_With_Broccoli { get; set; }
    [ProtoMember(21)] public Data_Food_Info Steak_With_Tamato { get; set; }
    [ProtoMember(22)] public Data_Food_Info Toast { get; set; }
    [ProtoMember(23)] public Data_Food_Info Tomato_Benedict_egg { get; set; }

    private Dictionary<string, Func<Data_Food_Breakfast,Data_Food_Info>> GetMappings = new Dictionary<string, Func<Data_Food_Breakfast,Data_Food_Info>>();
    private Dictionary<string, Action<Data_Food_Breakfast,Data_Food_Info>> SetMappings = new Dictionary<string, Action<Data_Food_Breakfast,Data_Food_Info>>();

    public Data_Food_Breakfast()
    {
         GetMappings.Add("Avocado_Bacon", (t) => t.Avocado_Bacon);
         GetMappings.Add("Bacon", (t) => t.Bacon);
         GetMappings.Add("Bacon_Benedict_egg", (t) => t.Bacon_Benedict_egg);
         GetMappings.Add("Bacon_Sandwiches", (t) => t.Bacon_Sandwiches);
         GetMappings.Add("Baked_Potato", (t) => t.Baked_Potato);
         GetMappings.Add("Black_Coffee", (t) => t.Black_Coffee);
         GetMappings.Add("Caesar_Salad", (t) => t.Caesar_Salad);
         GetMappings.Add("ClamSoup", (t) => t.ClamSoup);
         GetMappings.Add("Fried_Broccoli", (t) => t.Fried_Broccoli);
         GetMappings.Add("Fried_Eggs", (t) => t.Fried_Eggs);
         GetMappings.Add("Fried_Steak", (t) => t.Fried_Steak);
         GetMappings.Add("Iced_Coffee", (t) => t.Iced_Coffee);
         GetMappings.Add("Lobster_Soup", (t) => t.Lobster_Soup);
         GetMappings.Add("Milkshake", (t) => t.Milkshake);
         GetMappings.Add("Omelette", (t) => t.Omelette);
         GetMappings.Add("Poached_egg", (t) => t.Poached_egg);
         GetMappings.Add("Raw_Chips", (t) => t.Raw_Chips);
         GetMappings.Add("Roasted_Asparagus", (t) => t.Roasted_Asparagus);
         GetMappings.Add("Roasted_Tomatoes", (t) => t.Roasted_Tomatoes);
         GetMappings.Add("Steak_Sandwich", (t) => t.Steak_Sandwich);
         GetMappings.Add("Steak_With_Broccoli", (t) => t.Steak_With_Broccoli);
         GetMappings.Add("Steak_With_Tamato", (t) => t.Steak_With_Tamato);
         GetMappings.Add("Toast", (t) => t.Toast);
         GetMappings.Add("Tomato_Benedict_egg", (t) => t.Tomato_Benedict_egg);

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
        Action<Data_Food_Breakfast,Data_Food_Info> setter;
        if (SetMappings.TryGetValue(key, out setter))
        {
            setter(this, info);
        }
    }

    public override Data_Food_Info Get(string key)
    {
        Func<Data_Food_Breakfast,Data_Food_Info> getter;
        if (GetMappings.TryGetValue(key, out getter))
        {
            return getter(this);
        }

        return null;
    }
}
