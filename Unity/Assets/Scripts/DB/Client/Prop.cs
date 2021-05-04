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
    public partial class PropProperty : IConfig
    {
        public enum TypeEnum
        {
            Level,
            None,
            Res,
            InTheLevel,
        }

        private string mId;
        private string mName;
        private string mIcon;
        private Price mPrice;
        private int mUnlock;
        private TypeEnum mType;
        private string mDesc;
        /// <summary>
        /// Id
        /// </summary>
        public string Id
        {
            get => mId;
            set => mId = value;
        }

        /// <summary>
        /// 名称(对应到多语言表)
        /// </summary>
        public string Name
        {
            get => mName;
            set => mName = value;
        }

        /// <summary>
        /// 图标
        /// </summary>
        public string Icon
        {
            get => mIcon;
            set => mIcon = value;
        }

        /// <summary>
        /// 价格
        /// </summary>
        public Price Price
        {
            get => mPrice;
            set => mPrice = value;
        }

        /// <summary>
        /// 解锁关卡
        /// </summary>
        public int Unlock
        {
            get => mUnlock;
            set => mUnlock = value;
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
        /// 描述
        /// </summary>
        public string Desc
        {
            get => mDesc;
            set => mDesc = value;
        }

        public static PropProperty Read(string id, bool throwException = true)
        {
            return ConfigAssetManager<PropProperty>.Read(id, throwException);
        }

        public static Dictionary<string, PropProperty> ReadDict()
        {
            return ConfigAssetManager<PropProperty>.ReadstringDict();
        }

        public static List<PropProperty> ReadList()
        {
            return ConfigAssetManager<PropProperty>.ReadList();
        }
    }
}