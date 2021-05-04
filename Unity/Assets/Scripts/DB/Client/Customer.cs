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
    public partial class CustomerProperty : IConfig
    {
        private string mId;
        private string mModelPath;
        /// <summary>
        /// Id
        /// </summary>
        public string Id
        {
            get => mId;
            set => mId = value;
        }

        /// <summary>
        /// 模型资源
        /// </summary>
        public string ModelPath
        {
            get => mModelPath;
            set => mModelPath = value;
        }

        public static CustomerProperty Read(string id, bool throwException = true)
        {
            return ConfigAssetManager<CustomerProperty>.Read(id, throwException);
        }

        public static Dictionary<string, CustomerProperty> ReadDict()
        {
            return ConfigAssetManager<CustomerProperty>.ReadstringDict();
        }

        public static List<CustomerProperty> ReadList()
        {
            return ConfigAssetManager<CustomerProperty>.ReadList();
        }
    }
}