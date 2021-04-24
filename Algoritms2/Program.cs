using System;
using System.Collections.Generic;
using System.Collections;

namespace Algoritms2
{
    public class Node : ILikedList
    {
        public int Value { get; set; }
        public Node NextNode { get; set; }
        public Node PrevNode { get; set; }

        public Node head; //первый элемент списка
        public Node tail; //последний элемент списка
        public int count; //колличество элементов в списке

        public void AddNode()
        {
            Node node = new Node();
            if (head == null)
                head = node;
            else
            {
                tail.NextNode = node;
                node.PrevNode = tail;
            }
            tail = node;
            count++;
        }

        public void AddNodeAfter(Node node, int value)
        {
            // Запутался в процессе реализации: 
            // Есть понимание как можно вставить элемент после первого элемента, до и после последнего.
            // Не могу сообразить, как реализовать метод для вставки элемента после любого другого.

        }

        public Node FindNode(int searchValue)
        {
            var currentNode = head;
            while(currentNode != null)
            {
                if (currentNode.Value == searchValue)
                    return currentNode;
                currentNode = currentNode.NextNode;
            }
            return null;
        }

        public int GetCount()
        {
            return count;
           
        }

        public void RemoveNode(int index)
        {
            //не смог реализовать
        }

        public void RemoveNode(Node node)
        {//Сделано по аналогии с односвязным списком, но метод не рабочий.
            if (node.NextNode == null)
                return;
            var nextNode = node.NextNode.NextNode;
            node.NextNode = nextNode;
        }
    }

    public interface ILikedList
    {

        int GetCount();
        void AddNode();
        void AddNodeAfter(Node node, int value);
        void RemoveNode(int index);
        void RemoveNode(Node node);
        Node FindNode(int searchValue);

    }
    class Program
    { // Задание 2: Проверка функции бинарного поиска, определения асимптотической сложности
        static void Main(string[] args)
        {
            int a = 85;
            int[] arrayNumber = { 5, 15, 85, 1, 9, 7, 25, 64};
            Array.Sort(arrayNumber); // Я ведь правильно понимаю, что данный метод, сортирует элементы массива по возрастанию {1, 5, 7, 9, 15, 25, 64, 85}?
            int result = BinarySearch(arrayNumber, a);
            Console.WriteLine(result); //6 элемент, хотя в неотсортированном массиве он 2 элемент
        }

        
        static int BinarySearch(int[] array, int value)
        {
            int min = 0;        //О(1)
            int max = array.Length - 1; //О(1)

            while (min <= max)
            {
                int mid = (min + max) / 2; // Т.к. в заданном массиве 9 элементов, а метод бинарного поиска в отсортированном массиве делит кол-во элементов на 2 части, 
                if (value == array[mid])    //и так до момента нахождения требуемого значения. В данном случае процедура повторяется 3 раза.
                    return mid;             //соответственно для получения изначального числа элементов, нужно 2^3 = 8
                                            // Можно представить как: 3 = log2 8 или О(log2 N)
                else if (value < array[mid])
                    max = mid - 1;
                else
                    min = mid + 1;

            }
            return -1;              //О(1)
        }
        //Асимптотическая сложность:3 + log2 N
        //Применяя правила 3 и 5, можем отбросить постоянную величину 3 и и константу 2 в основании логарифма
        //Таким образом Асимптотическая сложность О(logN)
    }
}
