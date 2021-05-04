using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Algoritms4
{
    //Задание 1. Заполнить массив, HashSet случайными строками, Выполнить поиск строки, замерить скорость производительности.
    public class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
    }
    public class BenchMarkClass
    {
        //Столкнулся со следующей проблемой, при установке колличества элементов в массиве, листе хэшлисте даже 5 элементов, проверка в Бенчмарке проходит очень долго и судя по консоли
        //алгоритм проходится больше чем по 5 элементам. И в конце теста, бенчмарк не выводит таблицу результатов, как в дз к 3му уроку. При установке элементов (например в массиве) более 10 000
        //проверка в бенчмарке бесконечна... Прошу навести на мысль, где что не так)
        [Benchmark]
        public void TestSearchArray()
        {
            string search = "c9c77d2a-bec0-4e14-b2b0-2a6b1a5d4a5f";

            string[] myArray = new string[10000];

            for (int i = 0; i < myArray.Length; i++)
            {
                myArray[i] = Guid.NewGuid().ToString();
            }
            foreach (string str in myArray)
            {
                if (str == search)
                    Console.WriteLine("Строка найдена!");
                else
                    Console.WriteLine("Строка не найдена!");
            }
        }

        [Benchmark]
        public void TestSearchHash()
        {
            string search = "c9c77d2a-bec0-4e14-b2b0-2a6b1a5d4a5f";
            int count = 10000;
            HashSet<string> myHash = new HashSet<string>();

            for (int i = 0; i < count; i++)
            {
                myHash.Add(Guid.NewGuid().ToString());
            }
            if (myHash.Contains(search))
                Console.WriteLine("Строка найдена!");
            else
                Console.WriteLine("Строка не найдена!");
        }


        [Benchmark]
        public void TestSearchList()
        {
            string search = "c9c77d2a-bec0-4e14-b2b0-2a6b1a5d4a5f";
            int count = 10000;
            List<string> myList = new List<string>();

            for (int i = 0; i < count; i++)
                myList.Add(Guid.NewGuid().ToString());
            if (myList.Contains(search))
                Console.WriteLine("Строка найдена!");
            else
                Console.WriteLine("Строка не найдена!");
        }

    }

    // Задание 2. Реализовать класс двоичного дерева поиска с операциями вставки, удаления, поиска.
    //Аналогично с дз ко второму уроку. Возникают сложности с описанием метода. Алгоритм представляется, но происходит путаница при написании кода. Отсюда и не могу конкретные вопросы задать(
    public class TreeNode : ITree
    {
        public int Value { get; set; }
        public TreeNode LeftSide { get; set; }
        public TreeNode RightSide { get; set; }
        public TreeNode Root { get; set; }

        public TreeNode Parent { get; set; }
        public override bool Equals(object obj)
        {
            var node = obj as TreeNode;
            if (node == null)
                return false;
            return node.Value == Value;
        }
        public void AddItem(int value)
        {
            if (Root == null)
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
        public TreeNode GetNode()
        {
            return Root;
        }

        public TreeNode GetNodeByValue(int value)
        {
            TreeNode selected = Root;
            while (selected != null && value != selected.Value)
            {
                if (value < selected.Value)
                    selected = selected.LeftSide;
                else
                    selected = selected.RightSide;

            }
            return selected;
        }

        public void PrintTree()
        {


        }

        public void RemoveItem(int value)
        {
            TreeNode selected = Root;
            while (selected != null && value != selected.Value)
            {
                if (value < selected.Value)
                    selected = selected.LeftSide;
                else
                    selected = selected.RightSide;
            }

        }



    }
    public interface ITree
    {
        TreeNode GetNode();
        void AddItem(int value);
        void RemoveItem(int value);
        TreeNode GetNodeByValue(int value);
        void PrintTree();
    }
}


