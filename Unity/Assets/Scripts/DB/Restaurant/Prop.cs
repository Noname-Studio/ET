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
    public partial class PropProperty: IConfig
    {
        public enum TypeEnum
        {
            Level
        }

        private string mId;
        private string mLoc;
        private string mIcon;
        private Price mPrice;
        private int mUnlock;
        private TypeEnum mType;

        /// <summary>
        /// Id
        /// </summary>
        public string Id
        {
            get => mId;
            set => mId = value;
        }

        /// <summary>
        /// 本地化Key
        /// </summary>
        public string Loc
        {
            get => mLoc;
            set => mLoc = value;
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