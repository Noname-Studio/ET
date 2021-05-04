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
    public partial class CookwareProperty : IConfig
    {
        private string mId;
        private RestaurantKey mRestaurant;
        private string mSpineData;
        private string mTexture;
        private string mEffectPath;
        /// <summary>
        /// Id
        /// </summary>
        public string Id
        {
            get => mId;
            set => mId = value;
        }

        /// <summary>
        /// 餐厅
        /// </summary>
        public RestaurantKey Restaurant
        {
            get => mRestaurant;
            set => mRestaurant = value;
        }

        /// <summary>
        /// Spine数据
        /// </summary>
        public string SpineData
        {
            get => mSpineData;
            set => mSpineData = value;
        }

        /// <summary>
        /// 贴图
        /// </summary>
        public string Texture
        {
            get => mTexture;
            set => mTexture = value;
        }

        /// <summary>
        /// 音效文件
        /// </summary>
        public string EffectPath
        {
            get => mEffectPath;
            set => mEffectPath = value;
        }

        public static CookwareProperty Read(string id, bool throwException = true)
        {
            return ConfigAssetManager<CookwareProperty>.Read(id, throwException);
        }

        public static Dictionary<string, CookwareProperty> ReadDict()
        {
            return ConfigAssetManager<CookwareProperty>.ReadstringDict();
        }

        public static List<CookwareProperty> ReadList()
        {
            return ConfigAssetManager<CookwareProperty>.ReadList();
        }
    }
}