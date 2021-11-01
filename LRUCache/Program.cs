using System;
using System.Collections.Generic;

namespace LRUCache
{
    class Program
    {
        static void Main(string[] args)
        {
            /*sample data
             * input
             * LRU Cache Size : 2
             * Operation : PUT - [1, 1]
             * Operation : PUT - [2, 2]
             * Operation : GET - [1] -- GET Method should output :  1
             * Operation : PUT - [3, 3]
             * Operation : GET - [2] -- GET Method should output : -1
             * Operation : PUT - [4, 4]
             * Operation : GET - [1] -- GET Method should output : -1
             * Operation : GET - [3] -- GET Method should output :  3
             * Operation : GET - [4] -- GET Method should output :  4
              
             Explanation
                LRUCache lRUCache = new LRUCache(2);
                lRUCache.put(1, 1); // cache is {1=1}
                lRUCache.put(2, 2); // cache is {1=1, 2=2}
                lRUCache.get(1);    // return 1
                lRUCache.put(3, 3); // LRU key was 2, evicts key 2, cache is {1=1, 3=3}
                lRUCache.get(2);    // returns -1 (not found)
                lRUCache.put(4, 4); // LRU key was 1, evicts key 1, cache is {4=4, 3=3}
                lRUCache.get(1);    // return -1 (not found)
                lRUCache.get(3);    // return 3
                lRUCache.get(4);    // return 4
            */
            LRUCache cache = new LRUCache(2);
            cache.Put(1,1);
            cache.Put(2,2);
            Console.WriteLine(cache.Get(1));
            cache.Put(3,3);
            Console.WriteLine(cache.Get(2));
            cache.Put(4,4);
            Console.WriteLine(cache.Get(1));
            Console.WriteLine(cache.Get(3));
            Console.WriteLine(cache.Get(4));

            DoubleLinkedList d = cache.DoubleLinkedList;
            Dictionary<int,DoublyLinkedListNode> dt = cache.Dict;

            Console.ReadLine();

        }
    }
}
