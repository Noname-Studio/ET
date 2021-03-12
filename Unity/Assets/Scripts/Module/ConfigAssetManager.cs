using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Panthea.Asset;
using Newtonsoft.Json;
using UnityEngine;

namespace Config.ConfigCore
{
    public interface IConfig{}

    /// <summary>
    /// 特殊函数 PostPipeline,PrePipeline
    /// private static void PostPipeline:在配置表被加载之后做一些特殊的处理
    /// (未实现)private static void PrePipeline:在配置表被加载之前做一些特殊的处理
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ConfigAssetManager<T> : IConfig where T : IConfig
    {
        protected static Dictionary<int, T> IntKeyValue = new Dictionary<int, T>();
        protected static Dictionary<string, T> StringKeyValue = new Dictionary<string, T>();
        private static Type Type;
        /// <summary>
        /// 用于随机取值使用的
        /// </summary>
        protected static List<T> Values;

        public static async UniTask Load(string path)
        {
            Type = typeof(T);
            string json;
            json = (await AssetsKit.Inst.Load<TextAsset>(path)).text;
            if (string.IsNullOrEmpty(json))
            {
                return;
            }
            bool isInt = Type.GetProperty("Id").PropertyType == typeof(int);
            var method = Type.GetMethod("PostPipeline", BindingFlags.NonPublic | BindingFlags.Static);
            if (isInt)
            {
                IntKeyValue = JsonConvert.DeserializeObject<Dictionary<int, T>>(json);
                if (method != null)
                {
                    if(method.ReturnType == typeof(Task))
                        await (Task)method.Invoke(null,null);
                    else
                        method.Invoke(null,null);
                }
            }
            else
            {
                StringKeyValue = JsonConvert.DeserializeObject<Dictionary<string, T>>(json);
                if (method != null)
                {
                    if(method.ReturnType == typeof(Task))
                        await (Task)method.Invoke(null,null);
                    else
                        method.Invoke(null,null);
                }
            }
        }
        
        public static void Release()
        {
            if (Values != null) Values.Clear();
            IntKeyValue.Clear();
            StringKeyValue.Clear();
        }
        
        protected static T Read(int id, bool throwException = true)
        {
            T value;
            if (IntKeyValue.TryGetValue(id, out value))
            {
                return value;
            }
            //if(throwException)
            //    Debugger.LogWarning("Id:" + id + "不存在");
            return default(T);
        }

        protected static T Read(string id,bool throwException = true)
        {
            if (id == null)
                return default(T);
            T value;
            if (StringKeyValue.TryGetValue(id, out value))
            {
                return value;
            }
            //if(throwException)
            //    Debugger.LogWarning("Id:" + id + "不存在");
            return default(T);
        }

        protected static Dictionary<int, T> ReadintDict()
        {
            return IntKeyValue;
        }
        
        protected static Dictionary<string, T> ReadstringDict()
        {
            return StringKeyValue;
        }
        
        protected static List<T> ReadList()
        {
            if (Values == null)
            {
                if (IntKeyValue.Count != 0 )
                    Values = IntKeyValue.Values.ToList();
                else if (StringKeyValue.Count != 0)
                    Values = StringKeyValue.Values.ToList();
                else
                    Values = new List<T>();
            }

            return Values;
        }

        protected virtual void Dispose()
        {
            
        } 
    }

    public abstract class ConfigAssetManager
    {
        internal static List<Type> LoadedConfig = new List<Type>();
        internal static void Clear()
        {
            for (int i = 0; i < LoadedConfig.Count; i++)
            {
                // ReSharper disable once PossibleNullReferenceException
                ((IDictionary)LoadedConfig[i].GetField("Dict",BindingFlags.NonPublic | BindingFlags.Static).GetValue(LoadedConfig[i])).Clear();
            }
        }
    }
}