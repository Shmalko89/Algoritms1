using System;

namespace Algoritms8
{
    class Program
    {

        static void HeapSort(int[] array, int n)                // Метод сортировки
        {
            for (int i = n / 2 - 1; i >= 0; i--)                // N*LogN (в цикле присутствует деление пополам(логарифм N разбиений для N элементов)
            {
                Heapify(array, n, i);                           
            }
            for (int i = n - 1; i >= 0; i--)
            {
                int temp = array[0];
                array[0] = array[i];                            // O(N)
                array[i] = temp;
                Heapify(array, i, 0);
            }
        }

        // асимптотическая сложность метода: О(N) + N*LogN = О(N + N*LogN)

        static void Heapify(int[] array, int n, int i)          // метод построения дерева (пирамиды)
        {
            int largest = i;                                    // О(1)
            int left = (i * 2) + 1;                             // О(1)
            int right = (i * 2) + 2;                            // О(1)

            if (left < n && array[left] > array[largest])       // О(N)
                largest = left;

            if (right < n && array[right] > array[largest])     // О(N)
                largest = right;

            if (largest != i)                                   // O(N)
            {
                int swap = array[i];
                array[i] = array[largest];
                array[largest] = swap;
                Heapify(array, n, largest);
            }

        }
            // асимптотическая сложность: 3 + 3О(N) = O(N)
            //
        static void Main(string[] args)
        {
            int[] numbers = { 2, 4, 7, 9, 15, 8, 87, 55, 69, 3, 85, 96, 101};
            HeapSort(numbers, 13);

            for (int i = 0; i < numbers.Length; i++)
                Console.WriteLine(numbers[i]);
            
        }
    }
}
