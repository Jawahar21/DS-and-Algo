using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
            while (l1 != null && l2 != null)
            {

                if (l1.val < l2.val)
                {
                    curr.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    curr.next = l2;
                    l2 = l2.next;
                }
                curr = curr.next;
            }
            if (l1 == null) curr.next = l2;
            if (l2 == null) curr.next = l1;
            return first.next;
        }

        public static ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null) return head;
            ListNode curr = head;
            while (curr.next != null)
            {
                if (curr.val == curr.next.val)
                {
                    curr.next = curr.next.next;
                }
                else
                {
                    curr = curr.next;
                }
            }
            return head;
        }

        /*
         * You are given two non-empty linked lists representing two non-negative integers. 
         * The digits are stored in reverse order, and each of their nodes contains a single digit. 
         * Add the two numbers and return the sum as a linked list.
         * You may assume the two numbers do not contain any leading zero, except the number 0 itself.
         * Input: l1 = [2,4,3], l2 = [5,6,4]
           Output: [7,0,8]
           Explanation: 342 + 465 = 807.

           Input: l1 = [9,9,9,9,9,9,9], l2 = [9,9,9,9]
           Output: [8,9,9,9,0,0,0,1]
         */
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode head = new ListNode(0);
            ListNode curr = head;
            int x, y, carry = 0, sum;
            while (l1 != null || l2 != null)
            {
                if (l1 != null)
                {
                    x = l1.val;
                    l1 = l1.next;
                }
                else
                    x = 0;
                if (l2 != null)
                {
                    y = l2.val;
                    l2 = l2.next;
                }
                else
                    y = 0;

                sum = carry + x + y;
                carry = sum / 10;
                curr.next = new ListNode(sum % 10);
                curr = curr.next;
            }

            if (carry != 0) curr.next = new ListNode(1);
            return head.next;
        }

        /**
         * Given head, the head of a linked list, determine if the linked list has a cycle in it.
         * There is a cycle in a linked list if there is some node in the list that can be reached again by continuously following the next pointer. Internally, pos is used to denote the index of the node that tail's next pointer is connected to. 
         * Note that pos is not passed as a parameter.
         * Return true if there is a cycle in the linked list. Otherwise, return false
         * 
         * Input: head = [3,2,0,-4], pos = 1
         * Output: true
         * Explanation: There is a cycle in the linked list, where the tail connects to the 1st node (0-indexed).
         * 
         * Input: head = [1,2], pos = 0
         * Output: true
         * Explanation: There is a cycle in the linked list, where the tail connects to the 0th node.
         * **/
        public static bool HasCycle(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;

            while (fast != null && fast.next != null)
            {
                if (fast == slow)
                {
                    return true;
                }
                slow = slow.next;
                fast = fast.next.next;
            }
            return false;
        }

        /**
         * Given the head of a linked list, remove the nth node from the end of the list and return its head.
         * Input: head = [1,2,3,4,5], n = 2
         * Output: [1,2,3,5]
         */
        public static ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            if (head == null) return head;
            int length = backTraversal(head, n);
            if (length == n) head = head.next;
            return head;

        }
        private static int backTraversal(ListNode curr, int n)
        {
            if (curr == null) return 0;
            int index = backTraversal(curr.next, n) + 1;
            if (index == n + 1)
            {
                curr.next = curr.next.next;
            }
            return index;
        }

        /*
         * Given a linked list, swap every two adjacent nodes and return its head.
         * You may not modify the values in the list's nodes. Only nodes itself may be changed.
         * 
         * Input: head = [1,2,3,4]
         * Output: [2,1,4,3]
         * **/
        public static ListNode SwapPairs(ListNode head)
        {
            if (head == null || head.next == null) return head;
            ListNode nextNode = head.next;
            head.next = SwapPairs(head.next.next);
            nextNode.next = head;
            return nextNode;
        }

        /*
         * Given a linked list, rotate the list to the right by k places, where k is non-negative.

            Example 1:
            
            Input: 1->2->3->4->5->NULL, k = 2
            Output: 4->5->1->2->3->NULL
            Explanation:
            rotate 1 steps to the right: 5->1->2->3->4->NULL
            rotate 2 steps to the right: 4->5->1->2->3->NULL
         * **/
        public static ListNode RotateRight(ListNode head, int k)
        {
            if (head == null || head.next == null) return head;
            if (k == 0) return head;
            int length = GetLength(head);
            int newListEndIndex;
            if (k < length)
            {
                newListEndIndex = length - k;
            }
            else if (length == k)
            {
                return head;
            }
            else
            {
                newListEndIndex = length - (k % length);
            }

            if (length == newListEndIndex) return head;

            ListNode curr = head;
            while (newListEndIndex > 1)
            {
                curr = curr.next;
                newListEndIndex--;
            }

            ListNode newHead = curr.next;
            curr.next = null;
            curr = newHead;
            while (curr.next != null)
            {
                curr = curr.next;
            }
            curr.next = head;
            return newHead;
        }

        private static int GetLength(ListNode head)
        {
            if (head == null) return 0;
            if (head.next == null) return 1;
            return 1 + GetLength(head.next);
        }


        /*
         * Given a sorted linked list, delete all nodes that have duplicate numbers, leaving only distinct numbers from the original list.
         * Return the linked list sorted as well.
         * Example 1:
         * Input: 1->2->3->3->4->4->5
         * Output: 1->2->5
         */
        public static ListNode DeleteDuplicates2(ListNode head)
        {
            if (head == null || head.next == null) return head;
            ListNode distinctList = new ListNode(0);
            while (head != null || head.next != null)
            {
                if (head.val != head.next.val)
                {
                    distinctList.next = head;
                    head = head.next;
                    distinctList = distinctList.next;
                }
                else
                {
                    while (head.val != head.next.val)
                    {
                        head = head.next;
                    }
                    head = head.next;
                }
            }
            return distinctList.next;
        }

        /*
         * Given a linked list, return the node where the cycle begins. If there is no cycle, return null.

            There is a cycle in a linked list if there is some node in the list that can be reached again by continuously following the next pointer. Internally, pos is used to denote the index of the node that tail's next pointer is connected to. Note that pos is not passed as a parameter.
            Notice that you should not modify the linked list.
            Follow up:
            Can you solve it using O(1) (i.e. constant) memory?
         */
        public static ListNode DetectCycle(ListNode head)
        {
            if (head == null || head.next == null) return null;
            ListNode start = head, slow = head, fast = head;
            while(fast!= null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if(slow == fast)
                {
                    while(slow!=start)
                    {
                        start = start.next;
                        slow = slow.next;
                    }
                    return start;
                }
            }
            return null;
        }

        /*
         * Given a linked list and a value x, partition it such that all nodes less than x come before nodes greater than or equal to x.
         * You should preserve the original relative order of the nodes in each of the two partitions.
         * Example:
         * Input: head = 1->4->3->2->5->2, x = 3
         * Output: 1->2->2->4->3->5
         * **/
        public static ListNode Partition(ListNode head, int x)
        {
            ListNode listLessThanX = new ListNode(0);
            ListNode resultList = listLessThanX;
            ListNode listGreaterOrEqualToX = new ListNode(0);
            ListNode greaterListHead = listGreaterOrEqualToX;
            while (head!= null)
            {
                if(head.val < x)
                {
                    listLessThanX.next = head;
                    listLessThanX = listLessThanX.next;
                }
                else
                {
                    listGreaterOrEqualToX.next = head;
                    listGreaterOrEqualToX = listGreaterOrEqualToX.next;
                }
                head = head.next;
            }
            listLessThanX.next = greaterListHead.next;
            return resultList.next;
        }

        /*
         * Reverse a singly linked list.
            
            Example:
            Input: 1->2->3->4->5->NULL
            Output: 5->4->3->2->1->NULL
         */
        public static ListNode ReverseList(ListNode head)
        {
            ListNode newList = null;
            while (head != null) {
                ListNode next = head.next;
                head.next = newList;
                newList = head;
                head = next;
            }
            return newList;
        }

        public static ListNode ReverseListRecursively(ListNode head)
        {
            return ReverseRecursively(head, null);
        }

        private static ListNode ReverseRecursively(ListNode head, ListNode newHead)
        {
            if (head == null) return newHead;
            ListNode next = head.next;
            head.next = newHead;
            newHead = ReverseRecursively(next, head);
            return newHead;
        }
    }
}
