using System;
using System.Collections.Generic;

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
            if(p?.val == q?.val)
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
            foreach(NTreeNode childNode in root.children)
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
            TreeNode res = RecursiveTreeFormationHelper(nums, 0, nums.Length -1 );
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
    }
}
