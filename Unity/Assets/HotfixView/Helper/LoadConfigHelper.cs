using System.Collections.Generic;
using System.IO;
using Panthea.Asset;
using UnityEngine;

namespace ET
{
    public static class LoadConfigHelper
    {
        public static void LoadAllConfigBytes(Dictionary<string, byte[]> output)
        {
            Dictionary<string, List<UnityEngine.Object>> keys = AssetsKit.Inst.LoadAllSync("Config/Server" + AssetsConfig.Suffix);

            foreach (var kv in keys)
            {
                foreach (var obj in kv.Value)
                {
                    TextAsset v = obj as TextAsset;
                    string key = kv.Key;
                    output[key] = v.bytes;
                }
            }
        }
    }
}