﻿using System;
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
        public static bool HasCycle(ListNode head) {
            ListNode slow = head;
            ListNode fast = head;

            while (fast != null && fast.next != null) {
                if (fast == slow) {
                    return true;
                }
                slow = slow.next;
                fast = fast.next.next;
            }
            return false;
        }
    }
}
