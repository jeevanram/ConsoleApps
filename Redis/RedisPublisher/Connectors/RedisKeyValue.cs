using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedisPublisher
{
    class RedisKeyValue : RedisConnect
    {
        public override void PromptInputConsole()
        {
            Console.WriteLine("Key-value example");
            Console.WriteLine("Enter Key:");
            string key = Console.ReadLine();
            Console.WriteLine("Enter Value:");
            string value = Console.ReadLine();
            Redis.StringSet($"key-{key}", value);
        }

        public override void WalkthroughFunctionalities()
        {

            //key1 : value1
            Redis.StringSet("key1", "value1");

            //key2 : value2
            Redis.StringSet(new KeyValuePair<RedisKey,RedisValue>[]
            {
               new KeyValuePair<RedisKey, RedisValue>("key2","value2")
            });

            //key3: 1
            Redis.StringSet("key3", "1");

            //key2 : value1append
            Redis.StringAppend("key2", "append");

            Console.WriteLine(Redis.StringBitCount("key2"));

            //Redis.StringBitOperation(Bitwise.Not, "key3", "key1", "key2");
            //Console.WriteLine(Redis.StringGet("key3"));

            Console.WriteLine(Redis.StringBitPosition("key1", true));

            //Increment the integer value in the key key3 by 1
            //key3: 1
            Redis.StringIncrement("key3", 1);
            //key3: 2
            //output: 2
            Console.WriteLine(Redis.StringGet("key3"));

            //Decrement the integer value in the key key3 by 1
            //key3: 2
            Redis.StringDecrement("key3", 1);
            //key3: 1
            //output: 1
            Console.WriteLine(Redis.StringGet("key3"));

            //Print a substring from start index 1 to the penultimate index of the value in the key key2
            //key2 : value2append
            //output : alue2appen
            Console.WriteLine(Redis.StringGetRange("key2", 1, -2));

            //Sets the value of key2 to value2appendnew and returns value2append
            string oldKey2value = Redis.StringGetSet("key2", "value2appendnew");
            //oldKey2value = value2append
            Console.WriteLine(oldKey2value);
            //key2 = value2appendnew
            Console.WriteLine(Redis.StringGet("key2"));


            //Replace the value in the key2 from index 3 with the string "test"
            //key2 : value2appendnew
            Redis.StringSetRange("key2", 3, "test");
            //key2 : valtestppendnew
            //output : valtestppendnew
            Console.WriteLine(Redis.StringGet("key2"));

            Redis.KeyDelete("key1");
            Redis.KeyDelete("key2");
            Redis.KeyDelete("key3");

        }
    }
}
