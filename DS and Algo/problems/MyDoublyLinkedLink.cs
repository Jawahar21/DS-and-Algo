using System;
using System.Collections.Generic;
using System.Text;

namespace DS_and_Algo.problems
{
    public class DLNode
    {
        public int val;
        public DLNode prev;
        public DLNode next;

        public DLNode(int val)
        {
            this.val = val;
        }
    }

    public class MyDoublyLinkedLink
    {
        private DLNode head;
        private DLNode last;
        int lastNodeIndex;

        /** Initialize your data structure here. */
        public MyDoublyLinkedLink()
        {
            head = null;
            last = null;
            lastNodeIndex = -1;
        }

        /** Get the value of the index-th node in the linked list. If the index is invalid, return -1. */
        public int Get(int index)
        {
            if (index < 0 || index > lastNodeIndex) return -1;
            DLNode curr = head;
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
            DLNode newNode = new DLNode(val);
            newNode.prev = null;
            newNode.next = head;
            head = newNode;
            lastNodeIndex++;
            // if this is the first node added to the list then this will be last node as well.
            if (lastNodeIndex == 0)
            {
                last = head;
            }
            else
            {
                head.prev = newNode;
            }
        }

        /** Append a node of value val to the last element of the linked list. */
        public void AddAtTail(int val)
        {
            DLNode newNode = new DLNode(val);
            newNode.next = null;
            newNode.prev = last;
            if (lastNodeIndex < 0)
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

            DLNode newNode = new DLNode(val);
            DLNode curr = head;
            DLNode prev = null;
            while (index > 0)
            {
                prev = curr;
                curr = curr.next;
                index--;
            }
            newNode.prev = prev;
            newNode.next = curr;
            prev.next = newNode;
            curr.prev = newNode;
            lastNodeIndex++;
        }

        /** Delete the index-th node in the linked list, if the index is valid. */
        public void DeleteAtIndex(int index)
        {
            if (index < 0 || index > lastNodeIndex) return;
            DLNode curr = head;
            DLNode prev = null;
            while (index > 0)
            {
                prev = curr;
                curr = curr.next;
                index--;
            }

            if (curr == head)
            {
                head = head.next;
                
                if(head != null)
                {
                    // if there exists only 1 element and we removed the head
                    head.prev = null;
                }
                lastNodeIndex--;
                return;
            }
            if (curr == last)
            {
                last = prev;
            }
            prev.next = curr.next;

            if(curr.next != null)
            {
                // if last element is removed it won't have a prev to set
                curr.next.prev = prev;
            }
            lastNodeIndex--;
        }
    }
}
