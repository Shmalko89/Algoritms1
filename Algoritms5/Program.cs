using System;

using System.Collections.Generic;

namespace Algoritms5
{
    public class TreeNode
    {
        public int Value { get; set; }
        public TreeNode LeftSide { get; set; }
        public TreeNode RightSide { get; set; }
        public TreeNode Root { get; set; }

        public void AddItem(int value)
        {
            if(Root == null)
            {
                var node = new TreeNode();
                node.Value = value;
                Root = node;
                return;

            }
            AddItemRecursion(Root, value);

        }
        public void AddItemRecursion(TreeNode Root, int value)
        {


            if (value < Root.Value)
            {
                if (Root.LeftSide == null)
                    Root.LeftSide = new TreeNode() { Value = value };
                else
                    AddItemRecursion(Root.LeftSide, value);
            }
            else
            {
                if (Root.RightSide == null)
                    Root.RightSide = new TreeNode() { Value = value };
                else
                    AddItemRecursion(Root.RightSide, value);
            }

        }
        public List<TreeNode> BFS()
        {
            List<TreeNode> myTree = new List<TreeNode>();
            Queue<TreeNode> queueTree = new Queue<TreeNode>();

            queueTree.Enqueue(Root);

            if(queueTree.Count == 0)
            {
                return myTree;
            }

            while (queueTree.Count > 0)
            {
                var selected = queueTree.Dequeue();

                if (selected.LeftSide != null)
                    queueTree.Enqueue(selected.LeftSide);
                    

                if (selected.RightSide != null)
                    queueTree.Enqueue(selected.RightSide);

            }
            return myTree;

        }

        public List<TreeNode> DFS()
        {
            List<TreeNode> myTree = new List<TreeNode>();
            Stack<TreeNode> stackTree = new Stack<TreeNode>();

            stackTree.Push(Root);

            if (stackTree.Count == 0)
            {
                return myTree;
            }

            while (stackTree.Count > 0)
            {
                var selected = stackTree.Pop();


                if (selected.LeftSide != null)
                    stackTree.Push(selected.LeftSide);
                

                if (selected.RightSide != null)
                    stackTree.Push(selected.RightSide);
            }
            return myTree;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 2, 4, 7, 9, 15, 8};
            TreeNode tree = new TreeNode();

            foreach (int num in numbers)
            {
                tree.AddItem(num);
            }

            var sample1 = tree.BFS();
            var sample2 = tree.DFS();
        }
    }
}
