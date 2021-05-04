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
    public partial class FoodProperty : IConfig
    {
        private string mId;
        private RestaurantKey mRestaurant;
        private float mWaitTime;
        private float mPatient;
        private List<string> mAllIngredients;
        private string mCookware;
        private Vector3? mPosition;
        private string mTexture;
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
        /// 等待时间
        /// </summary>
        public float WaitTime
        {
            get => mWaitTime;
            set => mWaitTime = value;
        }

        /// <summary>
        /// 耐心指数
        /// </summary>
        public float Patient
        {
            get => mPatient;
            set => mPatient = value;
        }

        /// <summary>
        /// 需要食材
        /// </summary>
        public List<string> AllIngredients
        {
            get => mAllIngredients;
            set => mAllIngredients = value;
        }

        /// <summary>
        /// 烹饪厨具
        /// </summary>
        public string Cookware
        {
            get => mCookware;
            set => mCookware = value;
        }

        /// <summary>
        /// 食材位置
        /// </summary>
        public Vector3? Position
        {
            get => mPosition;
            set => mPosition = value;
        }

        /// <summary>
        /// 贴图
        /// </summary>
        public string Texture
        {
            get => mTexture;
            set => mTexture = value;
        }

        public static FoodProperty Read(string id, bool throwException = true)
        {
            return ConfigAssetManager<FoodProperty>.Read(id, throwException);
        }

        public static Dictionary<string, FoodProperty> ReadDict()
        {
            return ConfigAssetManager<FoodProperty>.ReadstringDict();
        }

        public static List<FoodProperty> ReadList()
        {
            return ConfigAssetManager<FoodProperty>.ReadList();
        }
    }
}