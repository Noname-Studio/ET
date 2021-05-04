/********************************
  该脚本是自动生成的请勿手动修改
*********************************/
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Config.ConfigCore;
using System.IO;

namespace RestaurantPreview.Config
{
    public partial class DrawReward_FriendPointProperty : IConfig
    {
        private string mId;
        private string mItem;
        private int mWeight;
        private int mNumber;
        /// <summary>
        /// Id
        /// </summary>
        public string Id
        {
            get => mId;
            set => mId = value;
        }

        /// <summary>
        /// 奖励物品ID
        /// </summary>
        public string Item
        {
            get => mItem;
            set => mItem = value;
        }

        /// <summary>
        /// 权重
        /// </summary>
        public int Weight
        {
            get => mWeight;
            set => mWeight = value;
        }

        /// <summary>
        /// 个数
        /// </summary>
        public int Number
        {
            get => mNumber;
            set => mNumber = value;
        }

        public static DrawReward_FriendPointProperty Read(string id, bool throwException = true)
        {
            return ConfigAssetManager<DrawReward_FriendPointProperty>.Read(id, throwException);
        }

        public static Dictionary<string, DrawReward_FriendPointProperty> ReadDict()
        {
            return ConfigAssetManager<DrawReward_FriendPointProperty>.ReadstringDict();
        }

        public static List<DrawReward_FriendPointProperty> ReadList()
        {
            return ConfigAssetManager<DrawReward_FriendPointProperty>.ReadList();
        }
    }
}