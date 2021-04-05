/********************************
  该脚本是自动生成的请勿手动修改
*********************************/

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Config.ConfigCore;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

namespace RestaurantPreview.Config
{
    public partial class GlobalConfigProperty: IConfig
    {
        private string mId;
        private string mValue;

        /// <summary>
        /// Id
        /// </summary>
        public string Id
        {
            get => mId;
            set => mId = value;
        }

        /// <summary>
        /// 具体参数
        /// </summary>
        public string Value
        {
            get => mValue;
            set => mValue = value;
        }

        public static GlobalConfigProperty Read(string id, bool throwException = true)
        {
            return ConfigAssetManager<GlobalConfigProperty>.Read(id, throwException);
        }

        public static Dictionary<string, GlobalConfigProperty> ReadDict()
        {
            return ConfigAssetManager<GlobalConfigProperty>.ReadstringDict();
        }

        public static List<GlobalConfigProperty> ReadList()
        {
            return ConfigAssetManager<GlobalConfigProperty>.ReadList();
        }
    }
}