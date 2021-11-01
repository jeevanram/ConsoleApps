# Design a data structure that follows the constraints of a Least Recently Used (LRU) cache.

Implement the LRUCache class:

LRUCache(int capacity) Initialize the LRU cache with positive size capacity.

int get(int key) Return the value of the key if the key exists, otherwise return -1.

void put(int key, int value) Update the value of the key if the key exists. Otherwise, add the key-value pair to the cache. If the number of keys exceeds the capacity from this operation, evict the least recently used key.

The functions get and put must each run in O(1) average time complexity.

# Sample Input
LRU Cache Size : 3
Operation : PUT - [1, 1]

Operation : PUT - [2, 2]

Operation : PUT - [3, 3]

Operation : GET - [1] `GET Method should output :  1`

Operation : PUT - [4, 4]

Operation : GET - [2] `GET Method should output : -1`

Operation : PUT - [5, 5]

Operation : GET - [3] `GET Method should output : -1`

Operation : GET - [1] `GET Method should output :  1`

Operation : GET - [4] `GET Method should output :  4`

Operation : GET - [5] `GET Method should output :  5`

Operation : PUT - [6, 6]

Operation : GET - [6] `GET Method should output :  6`
              
# Logic
LRUCache lRUCache = new LRUCache(3);

lRUCache.put(1, 1); 
 ```sh
LRU CACHE --> [1=1]
```
lRUCache.put(2, 2); 
 ```sh
LRU CACHE --> [1=1, 2=2]
```
lRUCache.put(3, 3); 
 ```sh
LRU CACHE --> [1=1, 2=2, 3=3]
```
lRUCache.get(1);    `PRINT 1`

lRUCache.put(4, 4);
 ```sh
Remove 2 which is LRU key in the cache, LRU CACHE --> [3=3, 1=1, 4=4]
```

lRUCache.get(2);    `PRINT -1 (Not in cache)`

lRUCache.put(5,5);
 ```sh
Remove 3 which is LRU key in the cache, LRU CACHE -->  [1=1, 4=4, 5=5]
```

lRUCache.get(3);    `PRINT -1 (Not in cache)`

lRUCache.get(1);    `PRINT 1`

lRUCache.get(4);    `PRINT 4`

lRUCache.get(5);    `PRINT 5`

lRUCache.put(6,6); 
 ```sh
Remove 1 which is LRU key in the cache, LRU CACHE --> [4=4, 5=5, 6=6]
```

lRUCache.get(1);    `PRINT -1 (Not in cache)`

lRUCache.get(6);    `PRINT 6`
