using StackExchange.Redis;
using System;

namespace RedisSubscriber
{
    class RedisServer
    {
        public static readonly Lazy<ConnectionMultiplexer> connectionMultiplexer;

        static RedisServer()
        {
            var configOptions = new ConfigurationOptions
            {
                EndPoints = { "127.0.0.1" }
            };

            connectionMultiplexer = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(configOptions));
        }

        public static IDatabase Redis => connectionMultiplexer.Value.GetDatabase();
    }
}
