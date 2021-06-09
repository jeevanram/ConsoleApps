using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedisSubscriber
{
    class RedisKeySetValue : RedisConnect
    {
        public RedisKeySetValue(string keysPattern = "set-*") : base(keysPattern)
        {

        }

        public override void PrintValues(bool deleteKeys = false)
        {
            Console.WriteLine("Enter UNION - Union of two sets");
            Console.WriteLine("Enter INTERSECT - Intersect of two sets");
            Console.WriteLine("Enter DIFFERENCE - Difference of two sets");
            Console.WriteLine("Enter DIFFERENCE - Difference of two sets");
            Console.WriteLine("Enter POP - Pop elements from the set");
            Console.WriteLine("Enter RANDOMMEMBER - RANDOMMEMBER from the set");
            Console.WriteLine("Enter SCAN - SCAN elements from the set using a pattern");
            string command = Console.ReadLine();
            string key1, key2;
            switch (command)
            {
                case "UNION":
                    Console.WriteLine("Enter set key1");
                    key1 = $"set-{Console.ReadLine()}";
                    Console.WriteLine("Enter set key2");
                    key2 = $"set-{Console.ReadLine()}";
                    Console.WriteLine(string.Join("-", Redis.SetCombine(SetOperation.Union, key1, key2)));
                    break;
                case "INTERSECT":
                    Console.WriteLine("Enter set key1");
                    key1 = $"set-{Console.ReadLine()}";
                    Console.WriteLine("Enter set key2");
                    key2 = $"set-{Console.ReadLine()}";
                    Console.WriteLine(string.Join("-", Redis.SetCombine(SetOperation.Intersect, key1, key2)));
                    break;
                case "DIFFERENCE":
                    Console.WriteLine("Enter set key1");
                    key1 = $"set-{Console.ReadLine()}";
                    Console.WriteLine("Enter set key2");
                    key2 = $"set-{Console.ReadLine()}";
                    Console.WriteLine(string.Join("-", Redis.SetCombine(SetOperation.Difference, key1, key2)));
                    break;
                case "POP":
                    foreach (RedisKey redisKey in RedisKeys)
                    {
                        Console.WriteLine(Redis.SetPop(redisKey));
                    }
                    break;
                case "RANDOMMEMBER":
                    foreach (RedisKey redisKey in RedisKeys)
                    {
                        Console.WriteLine($"Key is {redisKey}");
                        Console.WriteLine(Redis.SetRandomMember(redisKey));
                    }
                    break;
                case "SCAN":
                    Console.WriteLine("Enter the pattern");
                    string pattern = Console.ReadLine();
                    foreach (RedisKey redisKey in RedisKeys)
                    {
                        Console.WriteLine($"Key is {redisKey}");
                        Console.WriteLine(string.Join("-",Redis.SetScan(redisKey, pattern)));
                    }
                    break;
            }
        }

    }
}
