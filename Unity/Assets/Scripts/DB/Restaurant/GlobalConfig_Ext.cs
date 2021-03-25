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
    public partial class GlobalConfigProperty : ConfigAssetManager<GlobalConfigProperty>
    {
        private int? mInt;

        public int Int
        {
            get
            {
                if (mInt.HasValue)
                    return this.mInt.Value;
                int.TryParse(this.Value, out int result);
                this.mInt = result;
                return result;
            }
        }
        
        private string[] mStringArray;

        public string[] StringArray
        {
            get
            {
                if (mStringArray != null)
                    return mStringArray;
                this.mStringArray = this.Value.Split(GameConfig.StringSplit);
                return this.mStringArray;
            }
        }
    }
}