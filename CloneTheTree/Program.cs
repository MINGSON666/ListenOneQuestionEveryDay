using System;
using System.Collections.Generic;

namespace CloneTheTree
{
    /// <summary>
    /// 克隆一棵高度很大的非空二叉树
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = {1, 2, 3, 4, 5, 6, 7};
            var tree = Utilities.BuildTree(a, 0, a.Length - 1);
            //Utilities.DFS(tree);
            var newTree = Clone(tree);
            Utilities.DFS(newTree);
        }

        static Node Clone(Node root)
        {
            var queue = new Queue<Node>();
            var newRoot = new Node(root.val);
            queue.Enqueue(root);
            queue.Enqueue(newRoot);
            while (queue.Count > 0)
            {
                var original = queue.Dequeue();
                var cloned = queue.Dequeue();
                if (original.left != null)
                {
                    cloned.left = new Node(original.left.val);
                    queue.Enqueue(original.left);
                    queue.Enqueue(cloned.left);
                }

                if (original.right != null)
                {
                    cloned.right = new Node(original.right.val);
                    queue.Enqueue(original.right);
                    queue.Enqueue(cloned.right);
                }
            }

            return newRoot;
        }
    }

    class Node
    {
        public int val;
        public Node left;
        public Node right;
        public Node(int val)
        {
            this.val = val;
        }
    }

    class Utilities
    {
        /// <summary>
        /// 将一个排好序的数组转换为平衡二叉树
        /// </summary>
        /// <param name="a"></param>
        /// <param name="li"></param>
        /// <param name="hi"></param>
        /// <returns></returns>
        public static Node BuildTree(int[] a, int li, int hi)
        {
            if (hi < li)
            {
                return null;
            }

            int mi = li + (hi - li) / 2;
            var node = new Node(a[mi]);
            node.left = BuildTree(a, li, mi - 1);
            node.right = BuildTree(a, mi + 1, hi);
            return node;
        }

        /// <summary>
        /// 广度优先遍历
        /// </summary>
        /// <param name="root"></param>
        public static void DFS(Node root)
        {
            if (root == null)
            {
                return;
            }
            DFS(root.left);
            Console.WriteLine(root.val);
            DFS(root.right);
        }
    }
}
