using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace RestaurantPreview.Config
{
    public partial class FoodProperty
    {
        public class FoodDetailProperty
        {
            private int mLevel;
            private int mUnlockLv;
            private int mTips; // 默认的小费数额
            private Price mPrice = new Price(); //升级消耗
            private string mTexture;

            public string Texture
            {
                get => mTexture;
                set => mTexture = value;
            }

            public int Level
            {
                get => mLevel;
                set => mLevel = value;
            }

            public int UnlockLv
            {
                get => mUnlockLv;
                set => mUnlockLv = value;
            }

            public int Tips
            {
                get => mTips;
                set => mTips = value;
            }

            public Price Price
            {
                get => mPrice;
                set => mPrice = value;
            }
        }

        public List<FoodDetailProperty> Levels { get; } = new List<FoodDetailProperty>();
        private int mLevelCap;
        private string mDisplayName;

        public string DisplayName
        {
            get
            {
                return mDisplayName ??= LocalizationProperty.Read(Id);
            }
        }
        public int LevelCap
        {
            get
            {
                if(mLevelCap == 0)
                    mLevelCap = Levels.Count;
                return mLevelCap;
            }
        }

        /// <summary>
        /// 当前级别的食物
        /// </summary>
        public FoodDetailProperty CurrentLevel
        {
            get
            {
                if (LevelCap == 1)//无法升级的食物默认都返回0.
                {
                    return Levels[0];
                }
                
                var dt = DBManager.Inst.Query<Data_Food>();
                var info = dt.Get(this);
                if (info == null)
                {
                    return Levels[0];
                }

                return Levels[Mathf.Max(0, info.Level - 1)];
            }
        }

        /// <summary>
        /// 下一级别的食物
        /// </summary>
        public FoodDetailProperty NextLevel
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
    

    public class FoodConverter: JsonConverter<FoodProperty>
    {
        public override void WriteJson(JsonWriter writer, FoodProperty value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override FoodProperty ReadJson(JsonReader reader, Type objectType, FoodProperty existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var property = new FoodProperty();
            var token = JObject.Load(reader);
            if (token.TryGetValue("Id", out var id))
                property.Id = id.ToObject<string>();
            else
                throw new Exception("ID丢失");
            if (token.TryGetValue("Restaurant", out var restaurant))
                property.Restaurant = RestaurantKey.Wrap(restaurant.ToObject<string>());
            else
                property.Restaurant = RestaurantKey.Unknown;
            try
            {
                if (token.TryGetValue("WaitTime", out var waitTime))
                    property.WaitTime = waitTime.ToObject<float>();
                if (token.TryGetValue("Patient", out var patient))
                    property.Patient = patient.ToObject<float>();
                if (token.TryGetValue("Cookware", out var cookware))
                {
                    property.Cookware = cookware.ToObject<string>();
                    CookwareProperty.Read(property.Cookware).FoodKey.Add(property);
                }

                if (token.TryGetValue("AllIngredients", out var ing))
                    property.AllIngredients = ing.ToObject<List<string>>();
                else
                    property.AllIngredients = new List<string>();
                if (token.TryGetValue("Texture", out var texture))
                    property.Texture = texture.ToObject<string>();
                if (token.TryGetValue("Position", out var position))
                {
                    var result = position.ToObject<float[]>();
                    property.Position = new Vector3(result[0], result[1], result[2]);
                }
                else
                {
                    property.Position = null;
                }

                for (int i = 1; i <= 3; i++)
                {
                    var level = new FoodProperty.FoodDetailProperty();
                    level.Level = i;
                    level.Texture = property.Texture;
                    if (token.TryGetValue("Upgrade.Coin" + i, out var coin))
                        level.Price.Coin = coin.ToObject<int>();
                    if (token.TryGetValue("Upgrade.Gem" + i, out var gem))
                        level.Price.Gem = gem.ToObject<int>();
                    if (token.TryGetValue("Tips" + i, out var tips))
                        level.Tips = tips.ToObject<int>();
                    if (token.TryGetValue("Unlock" + i, out var unlock))
                        level.UnlockLv = unlock.ToObject<int>();
                    property.Levels.Add(level);
                }
            }
            catch(Exception e)
            {
                Log.Error("解析Food表,ID为:" + property.Id + "发生错误");
                throw;
            }
            
            return property;
        }
    } 
}