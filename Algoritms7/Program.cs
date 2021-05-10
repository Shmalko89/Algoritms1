using System;

namespace Algoritms7
{
    class Program
    {
        //Задача на нахождение колличества маршрутов
        const int N = 15;
        const int M = 10;

        static void PrintMatrix(int n, int m, int[,] a)
        {
            int i, j;
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                    Console.WriteLine(a[i, j]);
                Console.Write("\n");
            }
        }

        //Задача на нахождение наибольшей подпоследовательности
        //метод из методички
        static int lcsLengthMet(string a, string b)
        {
            if (a.Length == 0 || b.Length == 0)
                return 0;
            else if (a[0] == b[0])
                return 1 + lcsLengthMet(a.Substring(1), b.Substring(1));
            else
                return Math.Max(lcsLengthMet(a.Substring(1), b), lcsLengthMet(a, b.Substring(1)));
        }
        //метод рассмотренный на вебинаре
        static int lcsLengthWeb(string a, string b, int i, int j)
        {
            if (a.Length == i || b.Length == j)
                return 0;
            else if (a[i] == b[j])
                return 1 + lcsLengthWeb(a, b, i + 1, j + 1);
            else
                return Math.Max(lcsLengthWeb(a, b, i + 1, j), lcsLengthWeb(a, b, i, j + 1));
        }

        static void Main(string[] args)
        {
            int[,] A = new int[N, M];
            int i, j;
            for(j = 0; j < M; j++)
                A[0, j] = 1;
            for(i = 1; i < N; i++)
            {
                A[i, 0] = 1;
                for (j = 1; j < M; j++)
                    A[i, j] = A[i, j - 1] + A[i - 1, j];
            }
            PrintMatrix(N, M, A);
            
            var s1 = "1859862251";
            var s2 = "1595354455825";

            Console.WriteLine(lcsLengthMet(s1, s2));
            Console.WriteLine(lcsLengthWeb(s1,s2, 0, 0));
            //Наибольшая подпоследовательность - 6
        
        
        
        }
    }
}
