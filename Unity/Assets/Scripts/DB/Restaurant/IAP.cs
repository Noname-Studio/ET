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
    public partial class IAPProperty : IConfig
    {
        public enum CategoriesEnum
        {
            gem,
            pack,
            starterpack,
        }

        private string mId;
        private string mName;
        private string mIcon;
        private int mOriginNum;
        private int mCurrentNum;
        private CategoriesEnum mCategories;
        private Panthea.NativePlugins.IAP.ProductType mProductType;
        private bool mRecommend;
        private Dictionary<string, int> mContent;
        /// <summary>
        /// Id
        /// </summary>
        public string Id
        {
            get => mId;
            set => mId = value;
        }

        /// <summary>
        /// 名称
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
        /// 原数量
        /// </summary>
        public int OriginNum
        {
            get => mOriginNum;
            set => mOriginNum = value;
        }

        /// <summary>
        /// 现数量
        /// </summary>
        public int CurrentNum
        {
            get => mCurrentNum;
            set => mCurrentNum = value;
        }

        /// <summary>
        /// 商品分类
        /// </summary>
        public CategoriesEnum Categories
        {
            get => mCategories;
            set => mCategories = value;
        }

        /// <summary>
        /// 商品类型
        /// </summary>
        public Panthea.NativePlugins.IAP.ProductType ProductType
        {
            get => mProductType;
            set => mProductType = value;
        }

        /// <summary>
        /// 推荐
        /// </summary>
        public bool Recommend
        {
            get => mRecommend;
            set => mRecommend = value;
        }

        /// <summary>
        /// 商品内容
        /// </summary>
        public Dictionary<string, int> Content
        {
            get => mContent;
            set => mContent = value;
        }

        public static IAPProperty Read(string id, bool throwException = true)
        {
            return ConfigAssetManager<IAPProperty>.Read(id, throwException);
        }

        public static Dictionary<string, IAPProperty> ReadDict()
        {
            return ConfigAssetManager<IAPProperty>.ReadstringDict();
        }

        public static List<IAPProperty> ReadList()
        {
            return ConfigAssetManager<IAPProperty>.ReadList();
        }
    }
}