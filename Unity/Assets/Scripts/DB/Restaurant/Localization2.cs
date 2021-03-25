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
    public partial class Localization2Property : ConfigAssetManager<Localization2Property>
    {
        private string mId;
        private string mChinese;
        private string mChinese_tw;
        private string mEnglish;
        /// <summary>
        /// Id
        /// </summary>
        public string Id
        {
            get => mId;
            set => mId = value;
        }

        /// <summary>
        /// 中文
        /// </summary>
        public string Chinese
        {
            get => mChinese;
            set => mChinese = value;
        }

        /// <summary>
        /// 繁体
        /// </summary>
        public string Chinese_tw
        {
            get => mChinese_tw;
            set => mChinese_tw = value;
        }

        /// <summary>
        /// 英文
        /// </summary>
        public string English
        {
            get => mEnglish;
            set => mEnglish = value;
        }

        public static Localization2Property Read(string id, bool throwException = true)
        {
            return ConfigAssetManager<Localization2Property>.Read(id, throwException);
        }

        public static Dictionary<string, Localization2Property> ReadDict()
        {
            return ConfigAssetManager<Localization2Property>.ReadstringDict();
        }

        public static List<Localization2Property> ReadList()
        {
            return ConfigAssetManager<Localization2Property>.ReadList();
        }
    }
}