using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Pathfinding.Serialization;

namespace RestaurantPreview.Config
{
    public partial class LevelProperty
    {
        [Flags]
        public enum LevelTypeFlags
        {
            Unknown = 1 << 0,
            收集金币 = 1 << 1,
            固定时间 = 1 << 2,
            服务顾客 = 1 << 3,
            点赞数量 = 1 << 4,
            服务订单 = 1 << 5,
        }
        
        [Serializable]
        public class RequirementsData
        {
            public bool AllowBurn { get; set; } = true; // 是否允许烧焦
            public bool AllowLostCustomer { get; set; }= true; // 是否允许流失顾客
            public bool AllowUseTrash { get; set; }= true; // 是否允许使用垃圾桶
            public int RequiredCoin{ get; set; }
            public int LikeCount{ get; set; } //
            public int FixedTime{ get; set; } //
            public int LostCustomer{ get; set; } //
            public int NumberOfCustomerService{ get; set; }
            public int NumberOfCompletedOrders{ get; set; }
        }
        
        public class CustomerOrder
        {
            public string Customer { get; set; }
            public string[] Foods { get; set; }
        }

        public RequirementsData Requirements { get; } = new RequirementsData();
        public int LevelId { get; set; }
        public List<CustomerOrder> Orders { get; set; } = new List<CustomerOrder>();

        /// <summary>
        /// 有时候我们无法获得真实的LevelProperty,因为玩家可能已经到了无尽关卡了.这时候我们想要返回当前餐厅的通关关卡数量只能走这个方法
        /// </summary>
        /// <returns></returns>
        public static int GetLevelId(int propertyId)
        {
            return propertyId % GameConfig.RestaurantOffset;
        }
    }

    public class LevelPropertyConverter: JsonConverter<LevelProperty>
    {
        private Regex OrderRegex = new Regex(@"\[(.*?)\]", RegexOptions.Compiled);
        public override void WriteJson(JsonWriter writer, LevelProperty value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override LevelProperty ReadJson(JsonReader reader, Type objectType, LevelProperty existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var property = new LevelProperty();
            var token = JObject.Load(reader);
            if (token.TryGetValue("Id", out var id))
                property.Id = id.ToObject<int>();
            else
                throw new Exception("ID丢失");
            if (token.TryGetValue("Restaurant", out var restaurant))
            {
                property.Restaurant = RestaurantKey.Wrap(restaurant.ToObject<string>());
                property.LevelId = property.Id - GameConfig.RestaurantOffset * property.Restaurant.Index;
            }
            else
            {
                throw new Exception("ID：" + property.Id + "丢失餐厅Id");
            }


            if (token.TryGetValue("LevelType", out var levelType))
                property.LevelType = levelType.ToObject<LevelProperty.LevelTypeFlags>();
            else
                throw new Exception("LevelType is missing");
            if (token.TryGetValue("MaxCustomerNumber", out var maxCustomerNumber))
                property.MaxCustomerNumber = maxCustomerNumber.ToObject<int>();
            
            if (token.TryGetValue("Orders", out var orders))
            {
                var regex = OrderRegex.Matches(orders.ToObject<string>() ?? string.Empty);
                foreach (Match node in regex)
                {
                    var s = node.Value.TrimStart('[').TrimEnd(']').Split(GameConfig.StringSplit, StringSplitOptions.RemoveEmptyEntries);
                    var order = new LevelProperty.CustomerOrder();
                    order.Foods = s;
                    property.Orders.Add(order);
                }
            }

            //Todo
            token.TryGetValue("Secret", out var secret);

            if (token.TryGetValue("AllowBurn", out var allowBurn))
                property.Requirements.AllowBurn = allowBurn.ToObject<bool>();
            if (token.TryGetValue("AllowLostCustomer", out var allowLostCustomer))
                property.Requirements.AllowLostCustomer = allowLostCustomer.ToObject<bool>();
            if (token.TryGetValue("AllowUseTrash", out var allowUseTrash))
                property.Requirements.AllowUseTrash = allowUseTrash.ToObject<bool>();
            if (token.TryGetValue("RequireCoin", out var requireCoin))
                property.Requirements.RequiredCoin = requireCoin.ToObject<int>();
            if (token.TryGetValue("FixedTime", out var fixedTime))
                property.Requirements.FixedTime = fixedTime.ToObject<int>();
            if (token.TryGetValue("LikeCount", out var likeCount))
                property.Requirements.LikeCount = likeCount.ToObject<int>();
            if (token.TryGetValue("NumberOfCompletedOrders", out var numberOfCompletedOrders))
                property.Requirements.NumberOfCompletedOrders = numberOfCompletedOrders.ToObject<int>();
            if (token.TryGetValue("NumberOfCustomerService", out var numberOfCustomerService))
                property.Requirements.NumberOfCustomerService = numberOfCustomerService.ToObject<int>();
            if (token.TryGetValue("OrderInterval", out var orderInterval))
                property.OrderInterval = orderInterval.ToObject<RangeFloat>();
            if (token.TryGetValue("OrderDecay", out var orderDecay))
                property.OrderDecay = orderDecay.ToObject<DecayData>();
            if (token.TryGetValue("WaitingDecay", out var waitingDecay))
                property.WaitingDecay = waitingDecay.ToObject<DecayData>();
            if (token.TryGetValue("FirstArrivals", out var firstArrivals))
                property.FirstArrivals = firstArrivals.ToObject<int[]>();
            else
                property.FirstArrivals = new int[0];
            if (token.TryGetValue("Combo", out var combo))
                property.Combo = combo.ToObject<ComboConfig>();
            return property;
        }
    }
}