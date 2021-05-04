using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace RestaurantPreview.Config
{
    public partial class CookwareProperty
    {
        [Serializable]
        public class CookwareDetailProperty
        {
            private int mLevel;
            private int mWorkTime; //厨具工作时间
            private int mBurnTime; //厨具烧焦时间
            private int mMakeCount = 1; // 产出的食物数量
            private Price mPrice = new Price(); // 购买价格
            private int mUnlockLv;
            private string mSpineData;
            private string mTexture;
            private List<Vector3> mPosition = new List<Vector3>(1);
            private string mId;
            public string Id
            {
                get => mId;
                set => mId = value;
            }
            public int Level
            {
                get => mLevel;
                set => mLevel = value;
            }

            public int WorkTime
            {
                get => mWorkTime;
                set => mWorkTime = value;
            }

            public int BurnTime
            {
                get => mBurnTime;
                set => mBurnTime = value;
            }

            public int MakeCount
            {
                get => mMakeCount;
                set => mMakeCount = value;
            }

            public Price Price
            {
                get => mPrice;
                set => mPrice = value;
            }

            public int UnlockLv
            {
                get => mUnlockLv;
                set => mUnlockLv = value;
            }

            public string SpineData
            {
                get => mSpineData;
                set => mSpineData = value;
            }

            public string Texture
            {
                get => mTexture;
                set => mTexture = value;
            }
            
            public List<Vector3> Position
            {
                get => mPosition;
                set => mPosition = value;
            }
        }
        private int mLevelCap = -1;

        public int LevelCap
        {
            get
            {
                if (mLevelCap == -1)
                    mLevelCap = Levels.Count;
                return mLevelCap;
            }
        }
        
        public List<CookwareDetailProperty> Levels { get; } =  new List<CookwareDetailProperty>();
        public List<FoodProperty> FoodKey { get; } = new List<FoodProperty>();
        private string mDisplayName;

        public string DisplayName
        {
            get
            {
                return mDisplayName ??= LocalizationProperty.Read(Id);
            }
        }

        /// <summary>
        /// 当前级别的厨具
        /// </summary>
        public CookwareDetailProperty CurrentLevel
        {
            get
            {
                Data_Cookware dt = DBManager.Inst.Query<Data_Cookware>();
                var info = dt.Get(this);
                if (info == null)
                {
                    return Levels[0];
                }

                return Levels[Mathf.Max(0, info.Level - 1)];
            }
        }

        /// <summary>
        /// 下一级别的厨具
        /// </summary>
        public CookwareDetailProperty NextLevel
        {
            get
            {
                var current = CurrentLevel;
                if (Levels.Count > current.Level)
                {
                    return Levels[current.Level]; //因为current.Level是从1开始得并不是从0.所以这里数组返回Level是正确的
                }
                return null;
            }
        }
    }
    
    public class CookwarePropertyConverter : JsonConverter<CookwareProperty>
    {
        private Regex PositionRegex = new Regex(@"\[(.*?)\]", RegexOptions.Compiled);

        public override void WriteJson(JsonWriter writer, CookwareProperty value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override CookwareProperty ReadJson(JsonReader reader, Type objectType, CookwareProperty existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var property = new CookwareProperty();
            var token = JObject.Load(reader);
            if (token.TryGetValue("Id", out var id))
                property.Id = id.ToObject<string>();
            else
                throw new Exception("ID丢失");
            if (token.TryGetValue("Restaurant", out var restaurant))
                property.Restaurant = RestaurantKey.Wrap(restaurant.ToObject<string>());
            else
                property.Restaurant = RestaurantKey.Unknown;
            if (token.TryGetValue("SpineData", out var waitTime))
                property.SpineData = waitTime.ToObject<string>();
            if(token.TryGetValue("EffectPath",out var patient))
                property.EffectPath = patient.ToObject<string>();
            for (int i = 1; i <= 3; i++)
            {
                var level = new CookwareProperty.CookwareDetailProperty();
                level.Level = i;
                level.SpineData = property.SpineData;
                level.Texture = property.Texture;
                if (token.TryGetValue("Upgrade.Coin" + i, out var coin))
                    level.Price.Coin = coin.ToObject<int>();
                if (token.TryGetValue("Upgrade.Gem" + i, out var gem))
                    level.Price.Gem = gem.ToObject<int>();
                if (token.TryGetValue("WorkTime" + i, out var workTime))
                    level.WorkTime = workTime.ToObject<int>();
                if (token.TryGetValue("BurnTime" + i, out var burnTime))
                    level.BurnTime = burnTime.ToObject<int>();
                if (token.TryGetValue("MakeCount" + i, out var makeCount))
                    level.MakeCount = makeCount.ToObject<int>();
                if (token.TryGetValue("Position" + i, out var position))
                {
                    var pos = position.ToObject<float[]>();
                    for (int index = 0; index < pos.Length; index+=3)
                    {
                        level.Position.Add(new Vector3(pos[index], pos[index + 1], pos[index + 2]));
                    }

                }
                if (token.TryGetValue("Unlock" + i, out var unlock))
                    level.UnlockLv = unlock.ToObject<int>();
                property.Levels.Add(level);
            }
            return property;
        }
    }
}