using System;

namespace DS_and_Algo.problems
{
    public class MyLinkedList
    {
        private Node head;
        private Node last;
        int lastNodeIndex;

        /** Initialize your data structure here. */
        public MyLinkedList()
        {
            head = null;
            last = null;
            lastNodeIndex = -1;
        }

        /** Get the value of the index-th node in the linked list. If the index is invalid, return -1. */
        public int Get(int index)
        {
            if (index < 0 || index > lastNodeIndex) return -1;
            Node curr = head;
            while (index > 0 && curr != null)
            {
                curr = curr.next;
                index--;
            }
            return curr.val;
        }

        /** Add a node of value val before the first element of the linked list. After the insertion, the new node will be the first node of the linked list. */
        public void AddAtHead(int val)
        {
            Node newNode = new Node(val);
            newNode.next = head;
            head = newNode;
            lastNodeIndex++;
            // if this is the first node added to the list then this will be last node as well.
            if(lastNodeIndex == 0)
            {
                last = head;
            }
        }

        /** Append a node of value val to the last element of the linked list. */
        public void AddAtTail(int val)
        {
            Node newNode = new Node(val);

            if(lastNodeIndex < 0)
            {
                AddAtHead(val);
                return;
            }

            last.next = newNode;
            last = newNode;
            lastNodeIndex++;
        }

        /** Add a node of value val before the index-th node in the linked list. If index equals to the length of linked list, the node will be appended to the end of linked list. If index is greater than the length, the node will not be inserted. */
        public void AddAtIndex(int index, int val)
        {
            if (index > lastNodeIndex + 1 || index < 0) return;
            if (index == lastNodeIndex + 1) { AddAtTail(val); return; }
            if (index == 0) { AddAtHead(val); return; }

            Node newNode = new Node(val);
            Node curr = head;
            Node prev = null;
            while (index > 0)
            {
                prev = curr;
                curr = curr.next;
                index--;
            }
            newNode.next = curr;
            prev.next = newNode;
            lastNodeIndex++;
        }

        /** Delete the index-th node in the linked list, if the index is valid. */
        public void DeleteAtIndex(int index)
        {
            if (index < 0 || index > lastNodeIndex) return;
            Node curr = head;
            Node prev = null;
            while(index > 0)
            {
                prev = curr;
                curr = curr.next;
                index--;
            }

            if(curr == head)
            {
                head = head.next;
                lastNodeIndex--;
                return;
            }
            if (curr == last)
            {
                last = prev;
            }
            prev.next = curr.next;
            lastNodeIndex--;
            
        }

        public void printAllNodes ()
        {
            Node curr = head;
            while(curr != null)
            {
                Console.Write(curr.val + " ");
                curr = curr.next;
            }
            Console.WriteLine(" ");
        }
    }
}
