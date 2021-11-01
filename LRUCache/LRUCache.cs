using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRUCache
{
    public class LRUCache
    {
        public int Capacity { get; set; }
        public DoubleLinkedList DoubleLinkedList { get; set; }
        public Dictionary<int,DoublyLinkedListNode> Dict { get; set; }

        public LRUCache(int Capacity)
        {
            this.Capacity = Capacity;
            this.DoubleLinkedList = new DoubleLinkedList();
            this.Dict = new Dictionary<int, DoublyLinkedListNode>();
        }

        public void Put(int key, int value)
        {
            if (Dict.ContainsKey(key))
            {
                DoublyLinkedListNode node = Dict[key];
                node.value = value;
                DoubleLinkedList.MoveNodeToTop(node);
            }
            else
            {
                DoublyLinkedListNode node = new DoublyLinkedListNode(key, value);
                if (Dict.Count >= this.Capacity)
                {
                    DoublyLinkedListNode removeNode = DoubleLinkedList.RemoveNode();
                    Dict.Remove(removeNode.key);
                    DoubleLinkedList.AddNode(node);
                    Dict[key] = node;
                }
                else
                {
                    DoubleLinkedList.AddNode(node);
                    Dict[key] = node;
                }
            }
        }

        public int Get(int key)
        {
            if (Dict.ContainsKey(key))
            {
                DoublyLinkedListNode node = Dict[key];
                DoubleLinkedList.MoveNodeToTop(node);

                return node.value;
            }
            else
            {
                return -1;
            }
        }
    }
}
