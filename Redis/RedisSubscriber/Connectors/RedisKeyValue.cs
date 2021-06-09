using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedisSubscriber
{
    class RedisKeyValue : RedisConnect
    {
        public RedisKeyValue(string keysPattern = "key-*") : base(keysPattern)
        {

        }

        public override void PrintValues(bool deleteKeys = false)
        {
            foreach(RedisKey redisKey in RedisKeys)
            {
                Console.WriteLine(Redis.StringGet(redisKey));
                if (deleteKeys)
                    Redis.KeyDelete(redisKey);
            }
        }

    }
}
