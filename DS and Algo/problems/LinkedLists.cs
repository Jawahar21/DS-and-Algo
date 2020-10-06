using System;
using System.Collections.Generic;
using System.Text;

namespace DS_and_Algo.problems
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public static class LinkedLists
    {
        public static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode first = new ListNode(0);
            ListNode curr = first;
            while (l1 != null && l2 != null) {
                
                if (l1.val < l2.val)
                {
                    curr.next = l1;
                    l1 = l1.next;
                }
                else {
                    curr.next = l2;
                    l2 = l2.next;
                }
                curr = curr.next;
            }
            if (l1 == null) curr.next = l2;
            if (l2 == null) curr.next = l1;
            return first.next;
        }
    }
}
