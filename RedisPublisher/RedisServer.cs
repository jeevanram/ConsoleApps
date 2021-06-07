

using StackExchange.Redis;
using System;

namespace RedisPublisher
{
    class RedisServer
    {
        private static Lazy<ConnectionMultiplexer> Connection;

        static RedisServer()
        {
            var configOptions = new ConfigurationOptions()
            {
                EndPoints = { "localhost" }
            };

            Connection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(configOptions));
        }

        public static IDatabase Redis => Connection.Value.GetDatabase();
    }
}
