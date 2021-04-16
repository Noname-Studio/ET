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
    public partial class AchievementProperty : IConfig
    {
        private string mId;
        private string mGoogleId;
        private string mAppleId;
        private string mIcon;
        private int mStep;
        private string mNextStep;
        private string mType;
        private string mName;
        private string mDesc;
        private int mTarget;
        private Price mReward;
        /// <summary>
        /// 成就ID
        /// </summary>
        public string Id
        {
            get => mId;
            set => mId = value;
        }

        /// <summary>
        /// GooglePlay Game Services成就ID
        /// </summary>
        public string GoogleId
        {
            get => mGoogleId;
            set => mGoogleId = value;
        }

        /// <summary>
        /// AppStore Game Center成就D
        /// </summary>
        public string AppleId
        {
            get => mAppleId;
            set => mAppleId = value;
        }

        /// <summary>
        /// 成就图标
        /// </summary>
        public string Icon
        {
            get => mIcon;
            set => mIcon = value;
        }

        /// <summary>
        /// 成就等级
        /// </summary>
        public int Step
        {
            get => mStep;
            set => mStep = value;
        }

        /// <summary>
        /// 下一等级
        /// </summary>
        public string NextStep
        {
            get => mNextStep;
            set => mNextStep = value;
        }

        /// <summary>
        /// 成就统计类型
        /// </summary>
        public string Type
        {
            get => mType;
            set => mType = value;
        }

        /// <summary>
        /// 成就名称
        /// </summary>
        public string Name
        {
            get => mName;
            set => mName = value;
        }

        /// <summary>
        /// 成就描述
        /// </summary>
        public string Desc
        {
            get => mDesc;
            set => mDesc = value;
        }

        /// <summary>
        /// 成就目标
        /// </summary>
        public int Target
        {
            get => mTarget;
            set => mTarget = value;
        }

        /// <summary>
        /// 成就奖励
        /// </summary>
        public Price Reward
        {
            get => mReward;
            set => mReward = value;
        }

        public static AchievementProperty Read(string id, bool throwException = true)
        {
            return ConfigAssetManager<AchievementProperty>.Read(id, throwException);
        }

        public static Dictionary<string, AchievementProperty> ReadDict()
        {
            return ConfigAssetManager<AchievementProperty>.ReadstringDict();
        }

        public static List<AchievementProperty> ReadList()
        {
            return ConfigAssetManager<AchievementProperty>.ReadList();
        }
    }
}