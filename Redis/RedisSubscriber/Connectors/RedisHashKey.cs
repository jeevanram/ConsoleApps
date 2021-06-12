﻿using FastMember;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedisSubscriber
{
    class RedisHashKey : RedisConnect
    {
        public RedisHashKey(string keysPattern = "hash-*") : base(keysPattern)
        {

        }

        public override void PrintValues(bool deleteKeys = false)
        {
            foreach (RedisKey redisKey in RedisKeys)
            {
                Message msg = new Message();
                ObjectAccessor objectAccessor = ObjectAccessor.Create(msg);

                HashEntry[] hashEntries = Redis.HashGetAll(redisKey);
                foreach (HashEntry hashEntry in hashEntries)
                {
                    FastMemberExtensions.AssignValueToProperty(objectAccessor, hashEntry.Name, hashEntry.Value);
                }
                if(deleteKeys)
                    Redis.KeyDelete(redisKey);

                Console.WriteLine("Got hash notification");
                Console.WriteLine($"Message Title : {msg.MessageTitle}");
                Console.WriteLine($"Message Description : {msg.MessageDescription}");
                Console.WriteLine($"Message Generated By : {msg.MessageGeneratedBy}");
                Console.WriteLine($"Message Generated At : {msg.MessageGeneratedAt}");
            }
        }
    }
}