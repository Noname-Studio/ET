using System;
using StackExchange.Redis;

namespace ET
{
    public class RedisComponentSystem : AwakeSystem<RedisComponent, string, string>
    {
        public override void Awake(RedisComponent self, string ip, string port)
        {
            self.Connection = ConnectionMultiplexer.Connect("127.0.0.1:6379");
            self.Database= self.Connection.GetDatabase();
            RedisComponent.Instance = self;
        }
    }

    public static class RedisHelper
    {
        private static TimeSpan DefaultTime = TimeSpan.FromDays(7);
        private static void Set2(this RedisComponent redis,RedisKey key, RedisValue value,TimeSpan? expiry = null,When when = When.Always,CommandFlags flags = CommandFlags.None)
        {
            expiry ??= DefaultTime;
            redis.Database.StringSet(key, value, expiry, when, flags);
        }
        
        public static void Set(this RedisComponent redis, Entity value,TimeSpan? expiry = null,When when = When.Always,CommandFlags flags = CommandFlags.None)
        {
            RedisKey key = value.GetType() + ":" + value.Id;
            Set2(redis, key, ProtobufHelper.ToBytes(value), expiry, when, flags);
        }

        public static T Get<T>(this RedisComponent redis,RedisKey key,CommandFlags flags = CommandFlags.None)
        {
            try
            {
                key = typeof (T) + ":" + (string) key;
                RedisValue value = redis.Database.StringGet(key, flags);
                return FromByteArray<T>(value);
            }
            catch(Exception e)
            {
                Log.Error(e);
                return default;
            }
        }
        
        private static T FromByteArray<T>(byte[] data)
        {
            if (data == null)
                return default(T);
            return ProtobufHelper.FromBytes<T>(data, 0, data.Length);
        }
    }
}