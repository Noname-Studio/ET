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
    public partial class StandaloneKitchenConfigProperty : IConfig
    {
        private string mId;
        private Vector3 mPlayerInitializePosition;
        /// <summary>
        /// Id
        /// </summary>
        public string Id
        {
            get => mId;
            set => mId = value;
        }

        /// <summary>
        /// 角色初始位置
        /// </summary>
        public Vector3 PlayerInitializePosition
        {
            get => mPlayerInitializePosition;
            set => mPlayerInitializePosition = value;
        }

        public static StandaloneKitchenConfigProperty Read(string id, bool throwException = true)
        {
            return ConfigAssetManager<StandaloneKitchenConfigProperty>.Read(id, throwException);
        }

        public static Dictionary<string, StandaloneKitchenConfigProperty> ReadDict()
        {
            return ConfigAssetManager<StandaloneKitchenConfigProperty>.ReadstringDict();
        }

        public static List<StandaloneKitchenConfigProperty> ReadList()
        {
            return ConfigAssetManager<StandaloneKitchenConfigProperty>.ReadList();
        }
    }
}