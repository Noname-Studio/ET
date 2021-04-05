using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

public class DataCookwareCodeGenerator: Editor
{
    private static string Template = @"
using System;
using System.Collections.Generic;
//using MessagePack;
using RemoteSaves;

//[DBContainerKey(""/id"")]
//[MessagePackObject]
public partial class Data_Cookware_[@Suffix] : Data_Cookware_DBDefine
{              
[@Property]
    private Dictionary<string, Func<Data_Cookware_[@Suffix],Data_Cookware_Info>> GetMappings = new Dictionary<string, Func<Data_Cookware_[@Suffix],Data_Cookware_Info>>();
    private Dictionary<string, Action<Data_Cookware_[@Suffix],Data_Cookware_Info>> SetMappings = new Dictionary<string, Action<Data_Cookware_[@Suffix],Data_Cookware_Info>>();

    public Data_Cookware_[@Suffix]()
    {
[@GetProperty]
[@SetProperty]
    }

    public override void Set(string key, Data_Cookware_Info info)
    {
        Action<Data_Cookware_[@Suffix],Data_Cookware_Info> setter;
        if (SetMappings.TryGetValue(key, out setter))
        {
            setter(this, info);
        }
    }

    public override Data_Cookware_Info Get(string key)
    {
        Func<Data_Cookware_[@Suffix],Data_Cookware_Info> getter;
        if (GetMappings.TryGetValue(key, out getter))
        {
            return getter(this);
        }

        return null;
    }
}
";

    public class Writer
    {
        public StringBuilder Main;
        public StringBuilder Variable;
        public StringBuilder GetDelegate;
        public StringBuilder SetDelegate;

        public Writer(StringBuilder main, StringBuilder variable, StringBuilder get, StringBuilder set)
        {
            Main = main;
            Variable = variable;
            GetDelegate = get;
            SetDelegate = set;
        }

        public void Flush()
        {
            Main.Replace("[@Property]", Variable.ToString());
            Main.Replace("[@GetProperty]", GetDelegate.ToString());
            Main.Replace("[@SetProperty]", SetDelegate.ToString());
        }

        public override string ToString()
        {
            return Main.ToString();
        }
    }

    [MenuItem("Tools/Restaurant/Kitchen/GenerateCookwareCode")]
    public static void Do()
    {
        DirectoryInfo dir = new DirectoryInfo(Application.dataPath + "/" + "Res/Config/Kitchen/Cookwares/");
        Dictionary<RestaurantKey, Writer> writer = new Dictionary<RestaurantKey, Writer>();
        Dictionary<RestaurantKey, int> indexCounter = new Dictionary<RestaurantKey, int>();

        foreach (RestaurantKey node in RestaurantKey.All)
        {
            var sb = new StringBuilder(Template);
            var propertyWriter = new StringBuilder();
            var getPropertyWriter = new StringBuilder();
            var setPropertyWriter = new StringBuilder();
            writer.Add(node, new Writer(sb, propertyWriter, getPropertyWriter, setPropertyWriter));
            indexCounter.Add(node, 0);
            sb.Replace("[@Suffix]", node.Key);
        }

        var files = dir.GetFiles("*.asset");
        for (var index = 0; index < files.Length; index++)
        {
            var file = files[index];
            var variable = Path.GetFileNameWithoutExtension(file.FullName);
            var property = AssetDatabase.LoadAssetAtPath<CookwareProperty>(PathUtils.FullPathToUnityPath(file.FullName));
            if (property == null)
            {
                continue;
            }

            var rest = property.RestaurantId;
            if (rest == RestaurantKey.Unknown)
            {
                continue;
            }

            writer[rest].Variable.AppendLine($"    /*[Key({indexCounter[rest] + 5})]*/ public Data_Cookware_Info {variable}" + " { get; set; }");
            writer[rest].GetDelegate
                    .AppendLine($"         GetMappings.Add(\"{variable}\", (t) => t.{variable} ?? (t.{variable} = new Data_Cookware_Info()));");
            writer[rest].SetDelegate.AppendLine($"         SetMappings.Add(\"{variable}\", (t1, t2) => t1.{variable} = t2);");
            indexCounter[rest]++;
        }

        foreach (var node in writer)
        {
            node.Value.Flush();
            File.WriteAllText(Application.dataPath + "/Scripts/Client/RemoteSaves/Cookware/Data_Cookware_" + node.Key + ".cs", node.Value.ToString());
        }
    }
}