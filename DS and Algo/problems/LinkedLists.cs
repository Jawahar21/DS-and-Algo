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

    public class Node
    {
        public int val;
        public Node next;
        public Node random;

        public Node(int _val)
        {
            val = _val;
            next = null;
            random = null;
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
            int length = GetLength(head);
            if (k == length) return head;
            if (k > length)
            {
                k = k % length;
            }
            if (k == 0) return head;

            ListNode curr = head;
            int noOfPosToMove = length - k - 1;
            while (noOfPosToMove-- > 0)
            {
                curr = curr.next;
            }
            ListNode newListHead = curr.next;
            curr.next = null;
            curr = newListHead;
            while(curr.next != null)
            {
                curr = curr.next;
            }
            curr.next = head;
            return newListHead;
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
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast)
                {
                    while (slow != start)
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
            while (head != null)
            {
                if (head.val < x)
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
            while (head != null)
            {
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


        /*
         * Reverse a linked list from position m to n. Do it in one-pass.
           Note: 1 ≤ m ≤ n ≤ length of list.
      
           Example:
      
           Input: 1->2->3->4->5->NULL, m = 2, n = 4
           Output: 1->4->3->2->5->NULL
         ***/
        public static ListNode ReverseBetween(ListNode head, int m, int n)
        {
            if (head == null || head.next == null)
            {
                return head;
            }
            ListNode curr = head;
            ListNode reverseListHead = null;
            ListNode mainListEnd = null;
            int index = 1;
            while (curr != null)
            {
                if (index == m - 1)
                {
                    mainListEnd = curr;
                }

                if (index == m)
                {
                    ListNode reverseListEnd = curr;
                    while (index <= n)
                    {
                        ListNode next = curr.next;
                        curr.next = reverseListHead;
                        reverseListHead = curr;
                        curr = next;
                        index++;
                    }
                    reverseListEnd.next = curr;
                }
                else
                {
                    index++;
                    curr = curr.next;
                }
            }

            if (m == 1)
            {
                return reverseListHead;
            }
            else
            {
                mainListEnd.next = reverseListHead;
                return head;
            }
        }

        public static ListNode CreateLinkedList(List<int> numbers)
        {
            ListNode head = new ListNode(0);
            ListNode curr = head;
            foreach (int num in numbers)
            {
                curr.next = new ListNode(num);
                curr = curr.next;
            }
            return head.next;
        }

        /*
         * A linked list is given such that each node contains an additional random pointer which could point to any node in the list or null.
         * Return a deep copy of the list.
         * The Linked List is represented in the input/output as a list of n nodes. Each node is represented as a pair of [val, random_index] where:
         * val: an integer representing Node.val
         * random_index: the index of the node (range from 0 to n-1) where random pointer points to, or null if it does not point to any node.
         * Refer linkedlist list medium problem
         * **/
        public static Node CopyRandomListHashingSolution(Node head)
        {
            if (head == null) return null;
            Node copiedList = new Node(0);
            Node oldNodeCurr = head;
            Dictionary<Node, Node> oldNewMap = new Dictionary<Node, Node>();
            while(oldNodeCurr!=null)
            {
                copiedList.next = new Node(oldNodeCurr.val);
                copiedList = copiedList.next;
                oldNewMap.Add(oldNodeCurr, copiedList);
                oldNodeCurr = oldNodeCurr.next;
            }

            oldNodeCurr = head;
            while (oldNodeCurr !=null)
            {
                if(oldNodeCurr.random == null)
                {
                    oldNewMap[oldNodeCurr].random = null;
                }
                else
                {
                    oldNewMap[oldNodeCurr].random = oldNewMap[oldNodeCurr.random];
                }
                oldNodeCurr = oldNodeCurr.next;
            }

            return oldNewMap[head];
        }

        /*
         * We are given a linked list with head as the first node.  
         * Let's number the nodes in the list: node_1, node_2, node_3, ... etc.
         * Each node may have a next larger value: for node_i, next_larger(node_i) is the node_j.val 
         * such that j > i, node_j.val > node_i.val, and j is the smallest possible choice.  
         * If such a j does not exist, the next larger value is 0.
         * Return an array of integers answer, where answer[i] = next_larger(node_{i+1}).
         * Note that in the example inputs (not outputs) below, arrays such as [2,1,5]
         * represent the serialization of a linked list with a head node value of 2, second node value of 1, and third node value of 5.
         * 
         * Example 1:
         * Input: [2,1,5]
         * Output: [5,5,0]
         * 
         * Input: [2,7,4,3,5]
         * Output: [7,0,5,5,0]
         * **/
        public static int[] NextLargerNodes(ListNode head)
        {
            List<int> numbers = new List<int>();
            Stack<int> indexesStack = new Stack<int>();
            int index = 0;
            while (head != null)
            {
                while (indexesStack.Count != 0 && numbers[indexesStack.Peek()] < head.val)
                {
                    numbers[indexesStack.Peek()] = head.val;
                    indexesStack.Pop();
                }

                indexesStack.Push(index);
                numbers.Add(head.val);
                head = head.next;
                index++;
            }

            while (indexesStack.Count != 0)
            {
                numbers[indexesStack.Pop()] = 0;
            }

            return numbers.ToArray();
        }

        /// <summary>
        /// Given a singly linked list L: L0→L1→…→Ln-1→Ln,
        /// reorder it to: L0→Ln→L1→Ln-1→L2→Ln-2→…
        /// You may not modify the values in the list's nodes, only nodes itself may be changed.
        /// Example 1:
        /// Given 1->2->3->4, reorder it to 1->4->2->3.
        /// 
        /// Example 2:
        /// Given 1->2->3->4->5, reorder it to 1->5->2->4->3.
        /// </summary>
        /// <param name="head"></param>
        public static void ReorderList(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;
            ListNode prev = head;
            while (fast != null && fast.next != null)
            {
                prev = slow;
                slow = slow.next;
                fast = fast.next.next;
            }

            prev.next = null;

            ListNode secondHalfHead = null;
            while (slow != null)
            {
                ListNode next = slow.next;
                slow.next = secondHalfHead;
                secondHalfHead = slow;
                slow = next;
            }

            while (head != null)
            {
                ListNode n1 = head.next, n2 = secondHalfHead.next;
                head.next = secondHalfHead;

                if (n1 == null)
                    break;

                secondHalfHead.next = n1;
                head = n1;
                secondHalfHead = n2;
            }
        }

        /// <summary>
        /// Given a singly linked list, group all odd nodes together followed by the even nodes. Please note here we are talking about the node number and not the value in the nodes.
        /// You should try to do it in place.The program should run in O(1) space complexity and O(nodes) time complexity.
        /// Example 1:
        /// Input: 1->2->3->4->5->NULL
        /// Output: 1->3->5->2->4->NULL
        /// Example 2:
        /// Input: 2->1->3->5->6->4->7->NULL
        /// Output: 2->3->6->7->1->5->4->NULL
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static ListNode OddEvenList(ListNode head)
        {
            if (head == null || head.next == null || head.next.next == null) { return head; }

            ListNode oddListHead = new ListNode(0);
            ListNode evenListHead = new ListNode(0);
            ListNode oddListIter = oddListHead;
            ListNode evenListIter = evenListHead;

            int index = 1;
            while (head != null)
            {
                if (index % 2 == 0)
                {
                    evenListIter.next = head;
                    evenListIter = evenListIter.next;
                }
                else
                {
                    oddListIter.next = head;
                    oddListIter = oddListIter.next;
                }
                head = head.next;
                index++;
            }
            evenListIter.next = null;
            oddListIter.next = evenListHead.next;
            return oddListHead.next;
        }

        /// <summary>
        /// Given a (singly) linked list with head node root, write a function to split the linked list into k consecutive linked list "parts".
        /// The length of each part should be as equal as possible: no two parts should have a size differing by more than 1. This may lead to some parts being null.
        /// The parts should be in order of occurrence in the input list, and parts occurring earlier should always have a size greater than or equal parts occurring later.
        /// Return a List of ListNode's representing the linked list parts that are formed.
        /// Examples 1->2->3->4, k = 5 // 5 equal parts [ [1], [2], [3], [4], null ]
        /// Example 1:
        /// Input:
        /// root = [1, 2, 3], k = 5
        /// Output: [[1],[2],[3],[],[]]
        /// Explanation:
        /// The input and each element of the output are ListNodes, not arrays.
        /// For example, the input root has root.val = 1, root.next.val = 2, \root.next.next.val = 3, and root.next.next.next = null.
        /// The first element output[0] has output[0].val = 1, output[0].next = null.
        /// The last element output[4] is null, but it's string representation as a ListNode is [].
        /// </summary>
        /// <param name="root"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static ListNode[] SplitListToParts(ListNode root, int k)
        {
            int length = 0;
            ListNode iter = root;
            while (iter != null)
            {
                iter = iter.next;
                length++;
            }

            int noOfItemsPerList = length / k;
            int remainders = length % k;
            ListNode[] resLists = new ListNode[k];
            for (int i = 0; i < k; i++)
            {
                ListNode subListHead = new ListNode(0);
                ListNode subListIter = subListHead;
                for (int j = 0; j < noOfItemsPerList && root != null; j++)
                {
                    subListIter.next = root;
                    root = root.next;
                    subListIter = subListIter.next;
                }

                if (root != null && remainders > 0)
                {
                    subListIter.next = root;
                    root = root.next;
                    subListIter = subListIter.next;
                    remainders--;
                }
                subListIter.next = null;
                resLists[i] = subListHead.next;
            }

            return resLists;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="headA"></param>
        /// <param name="headB"></param>
        public static ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            int aLen = GetLength(headA);
            int bLen = GetLength(headB);
            int diff = Math.Abs(aLen - bLen);

            ListNode aCurr = headA;
            ListNode bCurr = headB;
            if (aLen > bLen)
            {
                while (diff > 0)
                {
                    aCurr = aCurr.next;
                    diff--;
                }
            }
            else if (aLen < bLen)
            {
                while (diff > 0)
                {
                    bCurr = bCurr.next;
                    diff--;
                }
            }

            while (aCurr != null && bCurr != null)
            {
                if (aCurr == bCurr) break;
                aCurr = aCurr.next;
                bCurr = bCurr.next;
            }
            return aCurr;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="head"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static ListNode RemoveElements(ListNode head, int val)
        {
            if (head == null) return null;
            ListNode newList = new ListNode();
            ListNode curr = newList;
            while (head != null)
            {
                if (head.val != val)
                {
                    curr.next = head;
                    curr = curr.next;
                }
                head = head.next;
            }
            curr.next = null;
            return newList.next;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static bool IsPalindrome(ListNode head)
        {
            int length = GetLength(head);
            if (length == 0 || length == 1) return false;
            int mid = length / 2;
            ListNode secondHalfList = null;
            ListNode curr = head;
            while (mid-1 > 0)
            {
                curr = curr.next;
                mid--;
            }
            if (length % 2 == 0)
            {
                secondHalfList = curr.next;
                curr.next = null;
            }
            else
            {
                secondHalfList = curr.next.next;
                curr.next = null;
            }

            secondHalfList = ReverseList(secondHalfList);
            while (secondHalfList != null)
            {
                if (head.val != secondHalfList.val)
                {
                    return false;
                }
                head = head.next;
                secondHalfList = secondHalfList.next;
            }
            return true;
        }
    }
}
