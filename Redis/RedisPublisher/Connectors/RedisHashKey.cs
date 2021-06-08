using FastMember;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedisPublisher
{
    class RedisHashKey : RedisConnect
    {

        public override void PromptInputConsole()
        {
            Console.WriteLine("Key-json example");
            Console.WriteLine("Enter Key:");
            string hashkey = Console.ReadLine();
            Message hashItemValue = new Message()
            {
                MessageGeneratedAt = DateTime.UtcNow
            };
            Console.WriteLine("Enter Json Value Title");
            hashItemValue.MessageTitle = Console.ReadLine();
            Console.WriteLine("Enter Json Value Description");
            hashItemValue.MessageDescription = Console.ReadLine();
            Console.WriteLine("Enter Json Value Sent By");
            hashItemValue.MessageGeneratedBy = Console.ReadLine();

            TypeAccessor typeAccessor = TypeAccessor.Create(hashItemValue.GetType());
            MemberSet memberSet = typeAccessor.GetMembers();
            List<HashEntry> entryList = new List<HashEntry>();
            for(int i = 0; i < memberSet.Count; i++)
            {
                entryList.Add(new HashEntry(memberSet[i].Name, typeAccessor[hashItemValue, memberSet[i].Name].ToString()));
            }
            Redis.HashSet($"hash-{hashkey}", entryList.ToArray());
        }

        public override void WalkthroughFunctionalities()
        {
            //Delete the key hashexample-key1 if exist
            Redis.KeyDelete("hashexample-key1");
            //Add entry
            Redis.HashSet("hashexample-key1", new HashEntry[]{
                new HashEntry("name1","value1"),
                new HashEntry("name2","value2"),
                new HashEntry("name3","value3"),
                new HashEntry("name4_integer",1)
            });

            //Retrieve the value in name1 hashentry of the key hashexample-key1
            //output : value1
            Console.WriteLine(Redis.HashGet("hashexample-key1", "name1"));

            //Retrieve all the values of hashentries of the key hashexample-key1
            //output : value1-value2-value3
            Console.WriteLine(string.Join("-",Redis.HashGet("hashexample-key1",new RedisValue[] { "name1", "name2", "name3" })));

            //Retrieve all the name-values of hash entries of the key hashexample-key1
            //output : name1:value1,name2:value2,name3:value3
            Console.WriteLine(string.Join(",",Redis.HashGetAll("hashexample-key1").Select(entry => $"{entry.Name}:{entry.Value}")));

            //Retrieve the value in name1 hashentry of the key hashexample-key1
            //output : value1
            Console.WriteLine(Redis.HashGetLease("hashexample-key1", "name1").DecodeString());

            //Retrieve the value in name3_integer hashentry of the key hashexample-key1 and increment the value by 2
            //output : 3
            Redis.HashIncrement("hashexample-key1", "name4_integer",2);
            Console.WriteLine(Redis.HashGet("hashexample-key1", "name4_integer"));

            //Retrieve the value in name3_integer hashentry of the key hashexample-key1 and decrement the value by 2
            //output : 1
            Redis.HashDecrement("hashexample-key1", "name4_integer", 2);
            Console.WriteLine(Redis.HashGet("hashexample-key1", "name4_integer"));

            //Retrieve all the fieldnames of the key hashexample-key1
            //output : name1,name2,name3,name4_integer
            Console.WriteLine(string.Join(",", Redis.HashKeys("hashexample-key1")));

            //Retrieve all the name-values of hash entries of the key hashexample-key1
            //Pattern * scans all the fields of the key hashexample-key1
            //output : name1: value1,name2: value2,name3: value3y,name4_integer: 3
            Console.WriteLine(string.Join(",", Redis.HashScan("hashexample-key1", "*")));

            //Retrieve the length of value in name1 hashentry of the key hashexample-key1
            //output : length of name1 : 5
            //Console.WriteLine(Redis.HashStringLength("hashexample-key1", "name1"));

            //Retrieve all the values of the key hashexample-key1
            //output : value1,value2,value3,1
            Console.WriteLine(string.Join(",", Redis.HashValues("hashexample-key1")));

            //Verify whether the fieldname exists in the key hashexample-key1
            //output : true
            Console.WriteLine(string.Join(",", Redis.HashExists("hashexample-key1","name1")));
            //output : false
            Console.WriteLine(string.Join(",", Redis.HashExists("hashexample-key1", "name6")));

            //Retrieve the number of fields in the key hashexample-key1
            //output: 4
            Console.WriteLine($"Number of fields : {Redis.HashLength("hashexample-key1")}");

            //Delete field name4_integer from hashexample-key1
            Redis.HashDelete("hashexample-key1", "name4_integer");
            //output: 3
            Console.WriteLine($"Number of fields : {Redis.HashLength("hashexample-key1")}");
            //Delete all fields from hashexample-key1
            Redis.HashDelete("hashexample-key1", Redis.HashKeys("hashexample-key1"));
            //output: 0
            Console.WriteLine($"Number of fields : {Redis.HashLength("hashexample-key1")}");
        }
    }
}
