using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedisSubscriber
{
    class RedisKeyListValue : RedisConnect
    {
        public RedisKeyListValue(string keysPattern = "list-*") : base(keysPattern)
        {

        }

        public override void PrintValues(bool deleteKeys = false)
        {
            foreach(RedisKey redisKey in RedisKeys)
            {
                Console.WriteLine(string.Join("-",Redis.ListRange(redisKey,0, Redis.ListLength(redisKey))));
                if (deleteKeys)
                    Redis.KeyDelete(redisKey);
            }
        }

    }
}
