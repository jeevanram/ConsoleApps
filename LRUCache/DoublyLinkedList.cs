using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRUCache
{
    public class DoublyLinkedListNode
    {
        public int value;
        public int key;
        public DoublyLinkedListNode leftNode;
        public DoublyLinkedListNode rightNode;

        public DoublyLinkedListNode(int key,int value)
        {
            this.key = key;
            this.value = value;
            this.leftNode = null;
            this.rightNode = null;
        }
    }

    public class DoubleLinkedList
    {
        public DoublyLinkedListNode head;
        public DoublyLinkedListNode tail;

        public void AddNode(DoublyLinkedListNode node)
        {
            if(head == null && tail == null)
            {
                head = node;
                tail = node;
            }
            else
            {
                tail.rightNode = node;
                node.leftNode = tail;
                tail = node;
            }
        }

        public DoublyLinkedListNode RemoveNode()
        {
            DoublyLinkedListNode returnNode = null;
            if(head != null)
            {
                returnNode = head;
                head = head.rightNode;
                if(head != null)
                    head.leftNode = null;
                else
                {
                    head = null;
                    tail = null;
                }
                returnNode.rightNode = null;
            }
            return returnNode;
        }

        public void MoveNodeToTop(DoublyLinkedListNode node)
        {
            if (tail == node)
                return;


            if(node.leftNode != null && node.rightNode != null)
            {
                node.leftNode.rightNode = node.rightNode;
                node.rightNode.leftNode = node.leftNode;
                node.leftNode = null;
                node.rightNode = null;

            }
            else if(node.leftNode != null)
            {
                node.leftNode.rightNode = node.rightNode;
                node.leftNode = null;
            }
            else if (node.rightNode != null)
            {
                node.rightNode.leftNode = node.leftNode;
                if(head == node)
                {
                    head = node.rightNode;
                }
                node.rightNode = null;
            }

            this.AddNode(node);
        }

    }
}
