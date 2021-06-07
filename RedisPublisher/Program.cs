using FastMember;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;

namespace RedisPublisher
{
    class Program
    {
        static void Main(string[] args)
        {
            var redis = RedisServer.Redis;

            //create a publisher
            var pub = redis.Multiplexer.GetSubscriber();

            //pubish to test channel a message
            string doContinue = "Y";
            Console.WriteLine("Welcome to the publisher console");
            while (doContinue.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("Choose one of the option below");
                Console.WriteLine("1. To connect redis and publish key-value, choose 'keyvalue'");
                Console.WriteLine("2. To connect redis and publish hash-key-value, choose 'hashkeyvalue'");
                Console.WriteLine("3. To connect redis as a publisher for a pub/sub model, choose 'pubsub'");
                Console.WriteLine("4. To connect redis as a publish key-list-value, choose 'keylistvalue'");
                Console.WriteLine("5. To connect redis as a publish key-set-value, choose 'keysetvalue'");
                string option = Console.ReadLine();
                RedisConnect connector = GetRedisConnect(option);
                //connector.PromptInputConsole();
                connector.WalkthroughFunctionalities();

                Console.WriteLine("Do you wish to continue publish ? : Press 'Y' to continue and anything else to exit !");
                doContinue = Console.ReadLine();
            }
        }

        public static RedisConnect GetRedisConnect(string option)
        {
            switch (option)
            {
                case "keyvalue":
                    return new RedisKeyValue();
                case "hashkeyvalue":
                    return new RedisHashKey();
                case "keylistvalue":
                    return new RedisKeyListValue();
                case "keysetvalue":
                    return new RedisKeySetValue();
                case "pubsub":
                default:
                    return new RedisPub();
            }
        }
    }
}
