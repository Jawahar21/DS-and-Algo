﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace DS_and_Algo.problems
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class NTreeNode
    {
        public int val;
        public IList<NTreeNode> children;

        public NTreeNode() { }

        public NTreeNode(int _val)
        {
            val = _val;
        }

        public NTreeNode(int _val, IList<NTreeNode> _children)
        {
            val = _val;
            children = _children;
        }
    }

    public class Trees
    {
        /// <summary>
        /// Given two binary trees, write a function to check if they are the same or not.
        /// Two binary trees are considered the same if they are structurally identical and the nodes have the same value.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public static bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null) return true;
            if (p?.val == q?.val)
            {
                return (IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right));
            }
            return false;
        }

        /// <summary>
        /// Given a binary tree, check whether it is a mirror of itself (ie, symmetric around its center).
        /// For example, this binary tree[1, 2, 2, 3, 4, 4, 3] is symmetric:
        ///     1
        ///    / \
        ///   2   2
        ///  / \ / \
        /// 3  4 4  3
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static bool IsSymmetric(TreeNode root)
        {
            if (root == null) return true;

            return IsMirror(root.left, root.right);
        }

        private static bool IsMirror(TreeNode left, TreeNode right)
        {
            if (left == null && right == null) return true;
            if (left?.val != right?.val) return false;
            return IsMirror(left.left, right.right) && IsMirror(left.right, right.left);
        }

        /// <summary>
        /// Given a binary tree, find its maximum depth.
        ///The maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.
        /// Note: A leaf is a node with no children.
        /// 
        /// Given binary tree [3,9,20,null,null,15,7],
        ///     3
        ///    / \
        ///   9  20
        ///  /  \
        /// 15   7
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static int MaxDepth(TreeNode root)
        {
            if (root == null) return 0;
            return 1 + Math.Max(MaxDepth(root.left), MaxDepth(root.right));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static int MaxDepth(NTreeNode root)
        {
            if (root == null) return 0;
            int maxDepth = 0;
            foreach (NTreeNode childNode in root.children)
            {
                maxDepth = Math.Max(maxDepth, MaxDepth(childNode));
            }
            maxDepth++;
            return maxDepth;
        }

        /// <summary>
        /// Given an array where elements are sorted in ascending order, convert it to a height balanced BST.
        /// For this problem, a height-balanced binary tree is defined as a binary tree in which the depth of the two subtrees of every node never differ by more than 1.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static TreeNode SortedArrayToBST(int[] nums)
        {
            if (nums.Length == 0) return null;
            TreeNode res = RecursiveTreeFormationHelper(nums, 0, nums.Length - 1);
            return res;
        }

        private static TreeNode RecursiveTreeFormationHelper(int[] nums, int low, int high)
        {
            if (low > high) return null;

            int mid = low + (high - low) / 2;

            TreeNode root = new TreeNode(nums[mid]);
            root.left = RecursiveTreeFormationHelper(nums, low, mid - 1);
            root.right = RecursiveTreeFormationHelper(nums, mid + 1, high);
            return root;
        }

        /// <summary>
        /// Given a binary tree, find its minimum depth.
        /// The minimum depth is the number of nodes along the shortest path from the root node down to the nearest leaf node.
        /// Note: A leaf is a node with no children.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static int MinDepth(TreeNode root)
        {
            if (root == null) return int.MaxValue;
            if (root.left == null || root.right == null) return 1;

            return 1 + Math.Min(MinDepth(root.left), MinDepth(root.right));
        }

        public IList<int> PreorderTraversal(TreeNode root)
        {
            IList<int> values = new List<int>();
            PreorderTraversalRecursive(root, values);
            return values;
        }

        private void PreorderTraversalRecursive(TreeNode root, IList<int> values)
        {
            if (root == null) return;
            values.Add(root.val);
            PreorderTraversalRecursive(root.left, values);
            PreorderTraversalRecursive(root.right, values);
        }

        public IList<int> PreorderTraversalIterative(TreeNode root)
        {
            if (root == null) return new List<int>();
            IList<int> values = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                TreeNode curr = stack.Pop();
                values.Add(curr.val);
                if (curr.right != null) stack.Push(curr.right);
                if (curr.left != null) stack.Push(curr.left);
            }
            return values;
        }

        public static IList<int> InorderTraversalIterative(TreeNode root)
        {
            if (root == null) return new List<int>();
            IList<int> values = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            TreeNode curr = root;
            while (stack.Count > 0)
            {
                while (curr != null && curr.left != null)
                {
                    curr = curr.left;
                    stack.Push(curr);
                }

                TreeNode elem = stack.Pop();
                values.Add(elem.val);
                curr = elem.right;
                if (curr != null)
                {
                    stack.Push(curr);
                }
            }
            return values;
        }

        public static IList<int> PostorderTraversalIterative(TreeNode root)
        {
            if (root == null) return new List<int>();
            IList<int> values = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            Stack<TreeNode> stack2 = new Stack<TreeNode>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                TreeNode curr = stack.Pop();
                stack2.Push(curr);
                if (curr.left != null) stack.Push(curr.left);
                if (curr.right != null) stack.Push(curr.right);
            }
            while (stack2.Count > 0)
            {
                values.Add(stack2.Pop().val);
            }
            return values;
        }

        public IList<int> InorderTraversal(TreeNode root)
        {
            IList<int> values = new List<int>();
            InorderTraversalRecursive(root, values);
            return values;
        }

        private void InorderTraversalRecursive(TreeNode root, IList<int> values)
        {
            if (root == null) return;
            InorderTraversalRecursive(root.left, values);
            values.Add(root.val);
            InorderTraversalRecursive(root.right, values);
        }

        public IList<int> PostorderTraversal(TreeNode root)
        {
            IList<int> values = new List<int>();
            PostorderTraversalRecursive(root, values);
            return values;
        }

        private void PostorderTraversalRecursive(TreeNode root, IList<int> values)
        {
            if (root == null) return;
            PostorderTraversalRecursive(root.left, values);
            PostorderTraversalRecursive(root.right, values);
            values.Add(root.val);
        }
    }
}
