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
    public partial class BuffProperty : IConfig
    {
        private string mId;
        private float mCWBurnTime;
        private float mCWWorkTime;
        /// <summary>
        /// Id
        /// </summary>
        public string Id
        {
            get => mId;
            set => mId = value;
        }

        /// <summary>
        /// 厨具烧焦速度
        /// </summary>
        public float CWBurnTime
        {
            get => mCWBurnTime;
            set => mCWBurnTime = value;
        }

        /// <summary>
        /// 厨具工作速度
        /// </summary>
        public float CWWorkTime
        {
            get => mCWWorkTime;
            set => mCWWorkTime = value;
        }

        public static BuffProperty Read(string id, bool throwException = true)
        {
            return ConfigAssetManager<BuffProperty>.Read(id, throwException);
        }

        public static Dictionary<string, BuffProperty> ReadDict()
        {
            return ConfigAssetManager<BuffProperty>.ReadstringDict();
        }

        public static List<BuffProperty> ReadList()
        {
            return ConfigAssetManager<BuffProperty>.ReadList();
        }
    }
}