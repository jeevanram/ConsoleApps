using StackExchange.Redis;
using System.Linq;
using System.Net;

namespace RedisSubscriber
{
    internal abstract class RedisConnect
    {
        public RedisKey[] RedisKeys { get; set; }
        public IDatabase Redis { get; set; }

        internal RedisConnect(string keyPattern = "*")
        {
            Redis = RedisServer.Redis;
            IConnectionMultiplexer multiplexer = RedisServer.Redis.Multiplexer;
            EndPoint endPoint = multiplexer.GetEndPoints().First();
            RedisKeys = multiplexer.GetServer(endPoint).Keys(pattern: keyPattern).ToArray();
        }

        public abstract void PrintValues(bool deleteKeys = false);
    }
}