using System;

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

    public class Node
    {
        public int val;
        public IList<Node> children;

        public Node() { }

        public Node(int _val)
        {
            val = _val;
        }

        public Node(int _val, IList<Node> _children)
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
        public static int MaxDepth(Node root)
        {
            if (root == null) return 0;
            int maxDepth = 0;
            foreach(Node childNode in root.children)
            {
                maxDepth = Math.Max(maxDepth, MaxDepth(childNode));
            }
            maxDepth++;
            return maxDepth;
        }
    }
}
