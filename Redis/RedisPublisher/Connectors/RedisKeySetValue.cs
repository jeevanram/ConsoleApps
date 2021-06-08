using StackExchange.Redis;
using System;
using System.Linq;

namespace RedisPublisher
{
    class RedisKeySetValue : RedisConnect
    {
        public override void PromptInputConsole()
        {
            Console.WriteLine("Redis Set DataType example");
            string doContinue = "Y";
            while(doContinue.ToUpper().Equals("Y"))
            {
                Console.WriteLine("Choose the publish option");
                Console.WriteLine("Enter ADD - Add value to the set");
                Console.WriteLine("Enter UNIONANDSTORE - Union of two sets and store it in new set");
                Console.WriteLine("Enter INTERSECTANDSTORE - Intersect of two sets and store it in new set");
                Console.WriteLine("Enter DIFFERENCEANDSTORE - Difference of two sets and store it in new set");
                Console.WriteLine("Enter REMOVE - Remove entries from the list");
                string command = Console.ReadLine();
                string key, value, key1, key2, newSet;
                switch (command)
                {
                    case "ADD":
                        Console.WriteLine("Enter key name:");
                        key = $"set-{Console.ReadLine()}";
                        Console.WriteLine($"Enter value for key-{key}");
                        value = Console.ReadLine();
                        Redis.SetAdd(key, value);
                        break;
                    case "UNION":
                        Console.WriteLine("Enter set key1");
                        key1 = $"set-{Console.ReadLine()}";
                        Console.WriteLine("Enter set key2");
                        key2 = $"set-{Console.ReadLine()}";
                        Console.WriteLine(string.Join("-",Redis.SetCombine(SetOperation.Union, key1, key2)));
                        Console.WriteLine(string.Join("-", Redis.SetCombine(SetOperation.Union, new RedisKey[] { key1, key2 })));
                        break;
                    case "INTERSECT":
                        Console.WriteLine("Enter set key1");
                        key1 = $"set-{Console.ReadLine()}";
                        Console.WriteLine("Enter set key2");
                        key2 = $"set-{Console.ReadLine()}";
                        Console.WriteLine(string.Join("-", Redis.SetCombine(SetOperation.Intersect, key1, key2)));
                        Console.WriteLine(string.Join("-", Redis.SetCombine(SetOperation.Intersect, new RedisKey[] { key1, key2 })));
                        break;
                    case "DIFFERENCE":
                        Console.WriteLine("Enter set key1");
                        key1 = $"set-{Console.ReadLine()}";
                        Console.WriteLine("Enter set key2");
                        key2 = $"set-{Console.ReadLine()}";
                        Console.WriteLine(string.Join("-", Redis.SetCombine(SetOperation.Difference, key1, key2)));
                        Console.WriteLine(string.Join("-", Redis.SetCombine(SetOperation.Difference, new RedisKey[] { key1, key2 })));
                        break;
                    case "UNIONANDSTORE":
                        Console.WriteLine("Enter set key1");
                        key1 = $"set-{Console.ReadLine()}";
                        Console.WriteLine("Enter set key2");
                        key2 = $"set-{Console.ReadLine()}";
                        Console.WriteLine("Enter new set name to store");
                        newSet = $"set-{Console.ReadLine()}";
                        Redis.SetCombineAndStore(SetOperation.Union,newSet, key1, key2);
                        break;
                    case "INTERSECTANDSTORE":
                        Console.WriteLine("Enter set key1");
                        key1 = $"set-{Console.ReadLine()}";
                        Console.WriteLine("Enter set key2");
                        key2 = $"set-{Console.ReadLine()}";
                        Console.WriteLine("Enter new set name to store");
                        newSet = $"set-{Console.ReadLine()}";
                        Redis.SetCombineAndStore(SetOperation.Intersect, newSet, key1, key2);
                        break;
                    case "DIFFERENCEANDSTORE":
                        Console.WriteLine("Enter set key1");
                        key1 = $"set-{Console.ReadLine()}";
                        Console.WriteLine("Enter set key2");
                        key2 = $"set-{Console.ReadLine()}";
                        Console.WriteLine("Enter new set name to store");
                        newSet = $"set-{Console.ReadLine()}";
                        Redis.SetCombineAndStore(SetOperation.Difference, newSet, key1, key2);
                        break;
                    case "REMOVE":
                        Console.WriteLine("Enter key name:");
                        key = $"set-{Console.ReadLine()}";
                        Redis.SetRemove(key, Redis.SetMembers(key));
                        break;
                    case "MOVE":
                        Console.WriteLine("Enter set key1");
                        key1 = $"set-{Console.ReadLine()}";
                        Console.WriteLine("Enter set key2");
                        key2 = $"set-{Console.ReadLine()}";
                        Console.WriteLine("Enter the value to move");
                        value = Console.ReadLine();
                        Redis.SetMove(key1, key2, value);
                        break;
                };

                Console.WriteLine("Do you want to continue and perform other actions on the list ? (Y/N)");
                doContinue = Console.ReadLine();
            }
        }

        public override void WalkthroughFunctionalities()
        {
            //Delete the key setexample-key1 if exist
            Redis.KeyDelete("setexample-key1");
            //Add element to the set
            //setexample-key1 : value1
            Redis.SetAdd("setexample-key1", "value1");
            //setexample-key1 : value2,value1
            Redis.SetAdd("setexample-key1", "value2");

            //Add elements to the list
            //listexample-key2 : value3,value4
            Redis.SetAdd("setexample-key2", new RedisValue[] { "value4","value3" });

            //Union of elements of setexample-key1 (U) setexample-key2
            //setexample-key1 : value2,value1
            //setexample-key2 : value3,value4
            //output : value3,value2,value4,value1
            Console.WriteLine(string.Join(",", Redis.SetCombine(SetOperation.Union, "setexample-key1", "setexample-key2")));

            //Union of elements of setexample-key1 (U) setexample-key2 and store it in the key setexample-key3
            //setexample-key1 : value2,value1
            //setexample-key2 : value3,value4
            //setexample-key3 : value3,value2,value4,value1
            Redis.SetCombineAndStore(SetOperation.Union, "setexample-key3", "setexample-key1", "setexample-key2");

            //Intersection of elements of setexample-key1 (I) setexample-key3
            //setexample-key1 : value2,value1
            //setexample-key3 : value3,value2,value4,value1
            //output : value2,value1
            Console.WriteLine(string.Join(",", Redis.SetCombine(SetOperation.Intersect, "setexample-key1", "setexample-key3")));

            //Intersection of elements of setexample-key1 (U) setexample-key3 and store it in the key setexample-key4
            //setexample-key1 : value2,value1
            //setexample-key3 : value3,value2,value4,value1
            //setexample-key4 : value2,value1
            Redis.SetCombineAndStore(SetOperation.Intersect, "setexample-key4", "setexample-key1", "setexample-key3");

            //Difference of elements of setexample-key3 (D) setexample-key2
            //setexample-key3 : value3,value2,value4,value1
            //setexample-key2 : value3,value4
            //output : value2,value1
            Console.WriteLine(string.Join(",", Redis.SetCombine(SetOperation.Difference, "setexample-key3", "setexample-key2")));

            //Difference of elements of setexample-key3 (D) setexample-key2 and store it in the key setexample-key5
            //setexample-key3 : value3,value2,value4,value1
            //setexample-key2 : value3,value4
            //setexample-key5 : value2,value1
            Redis.SetCombineAndStore(SetOperation.Difference, "setexample-key5", "setexample-key3", "setexample-key2");

            //Check if the element value2 is present in the set of the key setexample-key5
            //setexample-key5 : value2,value1
            //output : true
            Console.WriteLine(Redis.SetContains("setexample-key5", "value2"));

            //Check if the element value5 is present in the set of the key setexample-key5
            //setexample-key5 : value2,value1
            //output : false
            Console.WriteLine(Redis.SetContains("setexample-key5", "value5"));

            //Check the length of the set in the key setexample-key5
            //setexample-key5 : value2,value1
            //output : 2
            Console.WriteLine(Redis.SetLength("setexample-key5"));

            //Print the elements of the set in the key setexample-key3
            //setexample-key3 : value3,value2,value4,value1
            //output: value3,value2,value4,value1
            Console.WriteLine(string.Join(",", Redis.SetMembers("setexample-key3")));

            //Move an element from the setexample-key3 to setexample-key5
            //setexample-key3 : value3,value2,value4,value1
            //setexample-key5 : value2,value1
            //output : value3,value2,value1
            Redis.SetMove("setexample-key3", "setexample-key5", "value3");
            Console.WriteLine(string.Join(",", Redis.SetMembers("setexample-key5")));

            //Pop element from the set of the key setexample-key5
            //output: value3
            //Console.WriteLine(Redis.SetPop("setexample-key5"));

            //Print random element from the set of the key setexample-key3
            Console.WriteLine(Redis.SetRandomMember("setexample-key3"));

            //Print random 3 elements from the set of the key setexample-key3
            Console.WriteLine(string.Join(",", Redis.SetRandomMembers("setexample-key3", 3)));

            //Print random 5 elements from the set of the key setexample-key5, possible the same element is repeated more than once.
            Console.WriteLine(string.Join(",", Redis.SetRandomMembers("setexample-key5", -5)));

            //Remove element "value2" from the set of the key setexample-key5
            //setexample-key5 : value3,value2,value1
            Redis.SetRemove("setexample-key5", "value2");
            //output : value3,value1
            Console.WriteLine(string.Join(",", Redis.SetMembers("setexample-key5")));

            //Remove all the elements from the set of the key setexample-key5 and delete the key.
            Redis.SetRemove("setexample-key5", Redis.SetMembers("setexample-key5"));
            //output : 0
            Console.WriteLine(Redis.SetLength("setexample-key5"));

            //Print all the elements with the pattern "*" from the set of the key setexample-key5
            //setexample-key3 : value3,value2,value4,value1
            //output : value3,value2,value4,value1
            Console.WriteLine(string.Join(",", Redis.SetScan("setexample-key3", "*")));

            //Print all the elements with the pattern "*4" from the set of the key setexample-key5
            //setexample-key3 : value3,value2,value4,value1
            //output : value4
            Console.WriteLine(string.Join(",", Redis.SetScan("setexample-key3", "*4")));

            Redis.KeyDelete("setexample-key4");
            Redis.KeyDelete(new RedisKey[] { "setexample-key1", "setexample-key2" , "setexample-key3" });
        }
    }
}
