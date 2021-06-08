using System;

namespace RedisPublisher
{
    class RedisKeyListValue : RedisConnect
    {
        public override void PromptInputConsole()
        {
            Console.WriteLine("Redis List DataType example");
            Console.WriteLine("Enter key name:");
            string key = $"list-{Console.ReadLine()}";
            string doContinue = "Y";
            while(doContinue.ToUpper().Equals("Y"))
            {
                Console.WriteLine("Choose the publish option");
                Console.WriteLine("Enter LEFT - to push element to the left of the list");
                Console.WriteLine("Enter RIGHT - to push element to the right of the list");
                Console.WriteLine("Enter RPOLPU - to pop element from right and push it to the left of the list");
                Console.WriteLine("Enter INSRECAFTR - Insert records after a pivot to the list");
                Console.WriteLine("Enter INSRECBFR - Insert records before a pivot to the list");
                Console.WriteLine("Enter SETINDAFTR - Insert records after an index to the list");
                Console.WriteLine("Enter REMOVE - Remove entries from the list");
                Console.WriteLine("Enter TRIM - Trim entries from the list");
                string command = Console.ReadLine();
                string value;
                switch (command)
                {
                    case "LEFT":
                        Console.WriteLine($"Enter value for key-{key}");
                        value = Console.ReadLine();
                        Redis.ListLeftPush(key, value);
                        break;
                    case "RIGHT":
                    default:
                        Console.WriteLine($"Enter value for key-{key}");
                        value = Console.ReadLine();
                        Redis.ListRightPush(key, value);
                        break;
                    case "RPOLPU":
                        Console.WriteLine($"Enter the destination key  - To pop the element from the right of the key-{key} to the left of the destination key list");
                        value = Console.ReadLine();
                        Redis.ListRightPopLeftPush(key, value);
                        break;
                    case "INSRECAFTR":
                        Console.WriteLine($"Enter the pivot after which the value to be entered");
                        string pivotAfter = Console.ReadLine();
                        Console.WriteLine($"Enter value for key-{key}");
                        value = Console.ReadLine();
                        Redis.ListInsertAfter(key, pivotAfter, value);
                        break;
                    case "INSRECBFR":
                        Console.WriteLine($"Enter the pivot before which the value to be entered");
                        string pivotBefore = Console.ReadLine();
                        Console.WriteLine($"Enter value for key-{key}");
                        value = Console.ReadLine();
                        Redis.ListInsertBefore(key, pivotBefore, value);
                        break;
                    case "SETINDAFTR":
                        Console.WriteLine($"Enter value for key-{key}");
                        value = Console.ReadLine();
                        Console.WriteLine($"Enter index - value range from 0 to {Redis.ListLength(key)-1}");
                        int index = int.Parse(Console.ReadLine());
                        Redis.ListSetByIndex(key, index, value);
                        break;
                    case "REMOVE":
                        Console.WriteLine($"Enter value for key-{key}");
                        value = Console.ReadLine();
                        Redis.ListRemove(key, value, 4);
                        break;
                    case "TRIM":
                        Console.WriteLine($"Enter start and end index - value range from 0 to {Redis.ListLength(key) - 1}");
                        Console.WriteLine("Enter start index");
                        int startIndex = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter end index");
                        int endIndex = int.Parse(Console.ReadLine());
                        Redis.ListTrim(key, startIndex, endIndex);
                        break;
                };

                Console.WriteLine("Do you want to continue and perform other actions on the list ? (Y/N)");
                doContinue = Console.ReadLine();
            }
        }

        public override void WalkthroughFunctionalities()
        {

            //Delete listexample-key1 if exist
            Redis.KeyDelete("listexample-key1");
            //Add element to the left of the list
            //listexample-key1 : value2
            Redis.ListLeftPush("listexample-key1", "value2");

            //Add elements to the list
            //listexample-key1 : value1
            Redis.ListSetByIndex("listexample-key1", 0, "value1");

            //Add element to the left of the list
            //listexample-key1 : value2,value1
            Redis.ListLeftPush("listexample-key1", "value2");

            //Add element to the right of the list
            //listexample-key1 : value2, value1, value3
            Redis.ListRightPush("listexample-key1", "value3");

            //Add element after value3 of the list
            //listexample-key1 : value2, value1, value3, value4
            Redis.ListInsertAfter("listexample-key1", "value3","value4");

            //Add element before value3 of the list
            //listexample-key1 : value2, value1, value5, value3, value4
            Redis.ListInsertBefore("listexample-key1", "value3", "value5");

            //Length of the list
            //output: 5
            Console.WriteLine(Redis.ListLength("listexample-key1"));

            //print the values of the list
            //output: value2, value1, value5, value3, value4
            Console.WriteLine(string.Join(", ",Redis.ListRange("listexample-key1", 0, -1)));

            //print the values of the list from start to end-3 
            //output: value2, value1, value5
            Console.WriteLine(string.Join(", ",Redis.ListRange("listexample-key1", 0, -3)));

            //Pop the element from the left of the list
            //output: value2
            //listexample-key1 : value1, value5, value3, value4
            string leftPopElement = Redis.ListLeftPop("listexample-key1");
            Console.WriteLine(leftPopElement);

            //Push theleft popped element again to the list
            //listexample-key1 : value2, value1, value5, value3, value4
            Redis.ListLeftPush("listexample-key1", leftPopElement);

            //print the element from the right of the list
            //output: value4
            //listexample-key1 : value1, value5, value3, value4
            string rightPopElement = Redis.ListRightPop("listexample-key1");
            Console.WriteLine(rightPopElement);

            //Push the right popped element again to the list
            //listexample-key1 : value2, value1, value5, value3, value4
            Redis.ListRightPush("listexample-key1", rightPopElement);

            //print the values of the index 0 of the list
            //output: value1
            Console.WriteLine(Redis.ListGetByIndex("listexample-key1", 0));

            //Remove all the occurences of value1 from the list of the key listexample-key1
            //count = 0 - All the occurrences of value1 to be removed from the list
            //count > 0 - Remove count occurrences of value1 from the start to be removed from the list
            Redis.ListRemove("listexample-key1", "value1", 0);
            //output: value2,value5, value3, value4
            Console.WriteLine(string.Join(", ", Redis.ListRange("listexample-key1", 0, -1)));

            //Trim the list - Entries from startIndex 1 to penultimate number
            Redis.ListTrim("listexample-key1", 1, -2);
            //output: value5,value3
            Console.WriteLine(string.Join(", ", Redis.ListRange("listexample-key1", 0, -1)));
        }
    }
}
