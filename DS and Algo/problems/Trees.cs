using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DS_and_Algo.problems
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode next;

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

        public static bool IsSymmetricIterative(TreeNode root)
        {
            if (root == null) return true;
            Queue<TreeNode> leftQueue = new Queue<TreeNode>();
            Queue<TreeNode> rightQueue = new Queue<TreeNode>();
            leftQueue.Enqueue(root.left);
            rightQueue.Enqueue(root.right);

            while (leftQueue.Count > 0 && rightQueue.Count > 0)
            {
                TreeNode left = leftQueue.Dequeue();
                TreeNode right = rightQueue.Dequeue();
                if (left?.val != right?.val)
                {
                    return false;
                }
                if (left != null)
                {
                    leftQueue.Enqueue(left.left);
                    leftQueue.Enqueue(left.right);
                }
                if (right != null)
                {
                    rightQueue.Enqueue(right.right);
                    rightQueue.Enqueue(right.left);
                }
            }

            if (leftQueue.Count == 0 && rightQueue.Count == 0) return true;
            return false;
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

        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (root == null) return result;

            GetLevelOrder(result, root, 0);
            return result;
        }

        private void GetLevelOrder(IList<IList<int>> result, TreeNode root, int level)
        {
            if (root == null) return;

            if (result.Count == level) result.Add(new List<int>());

            result[level].Add(root.val);

            GetLevelOrder(result, root.left, level + 1);
            GetLevelOrder(result, root.right, level + 1);
        }

        /// <summary>
        /// Given the root of a binary tree and an integer targetSum, 
        /// return true if the tree has a root-to-leaf path such that adding up all the values along the path equals targetSum.
        /// A leaf is a node with no children.
        /// </summary>
        /// <param name="root"></param>
        /// <param name="targetSum"></param>
        /// <returns></returns>
        public bool HasPathSum(TreeNode root, int targetSum)
        {
            bool hasPathSum = false;
            CalculatePathSum(root, 0, targetSum, ref hasPathSum);
            return hasPathSum;
        }

        public void CalculatePathSum(TreeNode root, int sum, int targetSum, ref bool hasPathSum)
        {
            if (root == null) return;
            sum = sum + root.val;
            if (root.left == null && root.right == null && sum == targetSum) { hasPathSum = true; return; }
            CalculatePathSum(root.left, sum, targetSum, ref hasPathSum);
            CalculatePathSum(root.right, sum, targetSum, ref hasPathSum);
        }

        /// <summary>
        /// You are given a perfect binary tree where all leaves are on the same level, and every parent has two children.
        /// The binary tree has the following definition:
        /// struct Node {
        ///     int val;
        ///     Node* left;
        ///     Node* right;
        ///     Node* next;
        /// }
        /// Populate each next pointer to point to its next right node. If there is no next right node, the next pointer should be set to NULL.
        /// Initially, all next pointers are set to NULL.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode Connect(TreeNode root)
        {
            if (root == null) return root;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            if (root.left != null) queue.Enqueue(root.left);
            if (root.right != null) queue.Enqueue(root.right);
            while (queue.Count > 0)
            {
                int noOfElemToBeRemoved = queue.Count - 1;
                while (noOfElemToBeRemoved-- > 0)
                {
                    TreeNode curr = queue.Dequeue();
                    curr.next = queue.Peek();

                    if (curr.left != null) queue.Enqueue(curr.left);
                    if (curr.right != null) queue.Enqueue(curr.right);
                }

                TreeNode end = queue.Dequeue();
                if (end.left != null) queue.Enqueue(end.left);
                if (end.right != null) queue.Enqueue(end.right);
            }
            return root;
        }

        public TreeNode ConnectWithoutQueue(TreeNode root)
        {
            if (root == null) return root;
            TreeNode levelStart = root;
            while (levelStart != null)
            {
                TreeNode curr = levelStart;
                while (curr != null)
                {
                    if (curr.left != null) curr.left.next = curr.right;
                    if (curr.right != null && curr.next != null) curr.right.next = curr.next.left;

                    curr = curr.next;
                }
                levelStart = levelStart.left;
            }
            return root;
        }

        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            List<TreeNode> pTreePath = new List<TreeNode>();
            List<TreeNode> qTreePath = new List<TreeNode>();

            findNode(root, pTreePath, p.val);
            findNode(root, qTreePath, p.val);

            List<TreeNode> intersectionList = pTreePath.Intersect<TreeNode>(qTreePath).ToList();
            return intersectionList[intersectionList.Count - 1];
        }

        private bool findNode(TreeNode root, List<TreeNode> pathNodes, int requiredVal)
        {
            if (root == null) return false;
            if (root.val == requiredVal) return true;

            bool isNodeFound = findNode(root.left, pathNodes, requiredVal) || findNode(root.next, pathNodes, requiredVal);
            if (isNodeFound)
            {
                pathNodes.Add(root);
            }
            return isNodeFound;
        }


        // Encodes a tree to a single string.
        public static string Serialize(TreeNode root)
        {
            if (root == null) return "";
            StringBuilder sb = new StringBuilder();

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                TreeNode curr = queue.Dequeue();
                sb.Append("," + curr?.val ?? " ");

                if (curr != null)
                {
                    queue.Enqueue(curr.left);
                    queue.Enqueue(curr.right);
                }
            }
            return sb.Remove(0, 1).ToString();
        }

        // Decodes your encoded data to tree.
        public static TreeNode Deserialize(string data)
        {
            List<string> nodes = data.Split(',').ToList();
            if (nodes.Count == 1 && string.IsNullOrEmpty(nodes[0])) return null;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            TreeNode root = new TreeNode(int.Parse(nodes[0]));
            queue.Enqueue(root);

            int i = 1;
            while (queue.Count > 0)
            {
                TreeNode curr = queue.Dequeue();
                if (curr != null)
                {
                    TreeNode left = null, right = null;
                    if (!string.IsNullOrEmpty(nodes[i]))
                    {
                        left = new TreeNode(int.Parse(nodes[i++]));
                    }
                    else { i++; }

                    if (!string.IsNullOrEmpty(nodes[i]))
                    {
                        right = new TreeNode(int.Parse(nodes[i++]));
                    }
                    else { i++; }

                    curr.left = left;
                    queue.Enqueue(left);


                    curr.right = right;
                    queue.Enqueue(right);
                }
            }
            return root;
        }

        /// <summary>
        /// Check if tree is a BST
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static bool IsValidBST(TreeNode root)
        {
            if (root.left == null && root.right == null) return true;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode prev = null;
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
                if (prev != null && elem.val <= prev.val) return false;
                prev = elem;
                curr = elem.right;
                if (curr != null)
                {
                    stack.Push(curr);
                }
            }
            return true;
        }
    }
}
