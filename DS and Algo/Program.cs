using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using DS_and_Algo.problems;
using problems;

namespace DS_and_Algo
{
    class Program
    {
        // Just to vaidate output
        static void Main(string[] args)
        {
            /*int[] arr = new int[] { 4, 3, 3, 2, 5};
            var x = Arrays.FindDisappearedNumbers(arr);
            foreach (int num in x)
            {
                Console.Write(num + " ");
            }*/
            // Console.WriteLine(x);

            var x = Trees.InorderTraversalIterative(GenerateTree());
            Console.WriteLine(x);
        }

        private static TreeNode GenerateTree()
        {
            TreeNode root = new TreeNode(1);
            TreeNode two = new TreeNode(2);
            TreeNode three = new TreeNode(3);
            TreeNode three2 = new TreeNode(3);
            TreeNode four1 = new TreeNode(3);
            TreeNode four2 = new TreeNode(3);
            root.right = two;
            two.left = three;
            return root;
        }
    }
}
