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
    public partial class LevelProperty : IConfig
    {
        private int mId;
        private RestaurantKey mRestaurant;
        private LevelTypeFlags mLevelType;
        private int mMaxCustomerNumber;
        private string mSecret;
        private RangeFloat mOrderInterval;
        private DecayData mOrderDecay;
        private DecayData mWaitingDecay;
        private int[] mFirstArrivals;
        private ComboConfig mCombo;
        /// <summary>
        /// Id
        /// </summary>
        public int Id
        {
            get => mId;
            set => mId = value;
        }

        /// <summary>
        /// 餐厅Id
        /// </summary>
        public RestaurantKey Restaurant
        {
            get => mRestaurant;
            set => mRestaurant = value;
        }

        /// <summary>
        /// 关卡类型
        /// </summary>
        public LevelTypeFlags LevelType
        {
            get => mLevelType;
            set => mLevelType = value;
        }

        /// <summary>
        /// 最大顾客数量
        /// </summary>
        public int MaxCustomerNumber
        {
            get => mMaxCustomerNumber;
            set => mMaxCustomerNumber = value;
        }

        /// <summary>
        /// 神秘顾客
        /// </summary>
        public string Secret
        {
            get => mSecret;
            set => mSecret = value;
        }

        /// <summary>
        /// 订单间隔范围
        /// </summary>
        public RangeFloat OrderInterval
        {
            get => mOrderInterval;
            set => mOrderInterval = value;
        }

        /// <summary>
        /// 订单间隔修正
        /// </summary>
        public DecayData OrderDecay
        {
            get => mOrderDecay;
            set => mOrderDecay = value;
        }

        /// <summary>
        /// 耐心衰减系数
        /// </summary>
        public DecayData WaitingDecay
        {
            get => mWaitingDecay;
            set => mWaitingDecay = value;
        }

        /// <summary>
        /// 首次出现顾客的时间
        /// </summary>
        public int[] FirstArrivals
        {
            get => mFirstArrivals;
            set => mFirstArrivals = value;
        }

        /// <summary>
        /// 连击设定
        /// </summary>
        public ComboConfig Combo
        {
            get => mCombo;
            set => mCombo = value;
        }

        public static LevelProperty Read(int id, bool throwException = true)
        {
            return ConfigAssetManager<LevelProperty>.Read(id, throwException);
        }

        public static Dictionary<int, LevelProperty> ReadDict()
        {
            return ConfigAssetManager<LevelProperty>.ReadintDict();
        }

        public static List<LevelProperty> ReadList()
        {
            return ConfigAssetManager<LevelProperty>.ReadList();
        }
    }
}