using StackExchange.Redis;

namespace ET
{
    public class RedisComponent
    {
        public static RedisComponent Instance;
        public ConnectionMultiplexer Connection { get; set; }
        public IDatabase Database { get; set; }
    }
}