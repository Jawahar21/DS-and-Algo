using System;
using System.Collections.Generic;
using System.Text;

namespace DS_and_Algo.problems
{
    // assumption that next() is valid, it wont be called on empty tree
    public class BSTIterator
    {
        private Stack<TreeNode> stack;
        public BSTIterator(TreeNode root)
        {
            stack = new Stack<TreeNode>();
            stack.Push(root);
            TreeNode curr = root;
            while(curr.left != null)
            {
                curr = curr.left;
                stack.Push(curr);
            }
        }

        public int Next()
        {
            TreeNode node = stack.Pop();
            TreeNode curr = node;
            if(curr.right != null)
            {
                curr = curr.right;
                stack.Push(curr);
                while(curr.left != null)
                {
                    curr = curr.left;
                    stack.Push(curr);
                }
            }
            return node.val;
        }

        public bool HasNext()
        {
            if (stack.Count > 0) return true;
            return false;
        } 
    }
}
