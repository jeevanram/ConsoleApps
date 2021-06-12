using FastMember;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;

namespace RedisSubscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            string doContinue = "Y";
            Console.WriteLine("Welcome to the subscriber console");
            while (doContinue.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("Choose one of the option below");
                Console.WriteLine("1. To connect redis and read key-value, choose 'keyvalue'");
                Console.WriteLine("2. To connect redis and read hash-key-value, choose 'hashkeyvalue'");
                Console.WriteLine("3. To connect redis as a subscriber for a pub/sub model, choose 'pubsub'");
                Console.WriteLine("4. To connect redis as a publish key-list-value, choose 'keylistvalue'");
                Console.WriteLine("5. To connect redis as a publish key-set-value, choose 'keysetvalue'");

                string option = Console.ReadLine();
                RedisConnect connect = GetRedisConnect(option);

                connect.PrintValues();

                Console.WriteLine("Do you wish to continue read ? : Press 'Y' to continue and anything else to exit !");
                doContinue = Console.ReadLine();
            }
        }

        public static RedisConnect GetRedisConnect(string option)
        {
            switch(option)
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
                    return new RedisSub();
            }
        }
    }
}
