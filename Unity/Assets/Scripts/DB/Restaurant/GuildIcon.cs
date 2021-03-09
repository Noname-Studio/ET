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
    public partial class GuildIconProperty : ConfigAssetManager<GuildIconProperty>
    {
        public enum TypeEnum
        {
            Frame,
            Inside,
        }

        private int mId;
        private TypeEnum mType;
        private string mUrl;
        /// <summary>
        /// Id
        /// </summary>
        public int Id
        {
            get => mId;
            set => mId = value;
        }

        /// <summary>
        /// 类型
        /// </summary>
        public TypeEnum Type
        {
            get => mType;
            set => mType = value;
        }

        /// <summary>
        /// 具体参数
        /// </summary>
        public string Url
        {
            get => mUrl;
            set => mUrl = value;
        }

        public static GuildIconProperty Read(int id, bool throwException = true)
        {
            return ConfigAssetManager<GuildIconProperty>.Read(id, throwException);
        }

        public static Dictionary<int, GuildIconProperty> ReadDict()
        {
            return ConfigAssetManager<GuildIconProperty>.ReadintDict();
        }

        public static List<GuildIconProperty> ReadList()
        {
            return ConfigAssetManager<GuildIconProperty>.ReadList();
        }
    }
}