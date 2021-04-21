using System;

namespace Algoritms1
{
    class Program
        //Задание 1. Проверка на простое/не простое число
    {   //Реализация тестирования
        public class TestCase
        {
            public int a { get; set; }
            public string Answer { get; set; }
            public Exception ExpectedException { get; set; }
        }

        static void Test(TestCase testCase)
        {
            try
            {
                string actual = SimpleNumber(testCase.a);
                if (actual == testCase.Answer)
                {
                    Console.WriteLine("Тест пройден!");
                }
                else
                {
                    Console.WriteLine("Тест не пройден!");
                }
            }
            catch (Exception ex)
            {
                if (testCase.ExpectedException != null)
                {
                    Console.WriteLine("Тест пройден!");
                }
                else
                {
                    Console.WriteLine("Тест не пройден!");
                }

            }
            
        }
        // метод нахождения простого/не простого числа
        static string SimpleNumber(int a)
        {
            int i = 2;
            int d = 0;
            while (i < a)
            {
                if (a % i == 0)
                    d++;
                i++;
            }
            if (d == 0)
                return "Число простое!";
            else
                return "Число не простое!";
        }



        //Задание 2 Вычисление асимптотической сложности функции
        public static int StrangeSum(int[] inputArray)
        {
            int sum = 0;                                            // О(1)

            for (int i = 0; i < inputArray.Length; i++)             // О(Length)
            {
                for (int j = 0; j < inputArray.Length; j++)         // О(Length)
                {
                    for(int k = 0; k < inputArray.Length; k++)      // О(Length)
                    {
                int y = 0;                                          // О(1)

                if (j != 0)                                         // О(1)
                        {
                    y = k / j;
                }
                sum += inputArray[i] + i + k + j + y;               // О(1)
                    }
        }
        }
            return sum;
            }

        // O(1) + (О(Length)*О(Length)*О(Length)*3O(1)) = O(1) + O(Length^3)*3O(1);
        //Согласно правилу 3 - постоянными величинами можно пренебречь, таким образом:
        //O(Length^3)*3O(1);
        //Согласно правилу 5 - постоянными множителями(константами) можно принебречь, таким образом:
        //асимптотическая сложность функции - O(Length^3);

        //Задание 3 Реализация функции вычисления числа Фибоначчи.
        //Реализация тестирования
        public class TestCaseFib
        {
            public int f { get; set; }
            public long rightF { get; set; }
            public Exception ExpectedException { get; set; }
        }
        static void TestFibRec(TestCaseFib testCase)
        {
            
                long actual = FibonacciRec(testCase.f);
                if (actual == testCase.rightF)
                {
                    Console.WriteLine("Тест пройден!");
                }
                else
                {
                    Console.WriteLine("Тест не пройден!");
                }
        }
            
        //Метод поиска Фибоначчи через рекурсию
        public static long FibonacciRec(int f)
        {
            if (f == 0 || f == 1)
                return f;
            else
                return FibonacciRec(f - 1) + FibonacciRec(f - 2);
        }

        static void TestFibFor(TestCaseFib testCase)
        {

            long actual = FibonacciFor(testCase.f);
            if (actual == testCase.rightF)
            {
                Console.WriteLine("Тест пройден!");
            }
            else
            {
                Console.WriteLine("Тест не пройден!");
            }
        }
        //Метод поиска Фибоначчи через цикл
        public static long FibonacciFor(int f)
        {
            int a = 1;
            int b = 0;
            int sum = 0;
            for(int i = 1; i<=f;i++)
            {
                sum = a + b;
                a = b;
                b = sum;
            }
            return sum;
        }
        static void Main(string[] args)
            
        {//Для задания 1:
            
            Console.WriteLine("Введите число, чтобы проверить является ли оно простым или нет:");
            int input = int.Parse(Console.ReadLine());
            Console.WriteLine(SimpleNumber(input));
            Console.ReadKey();
            Console.Clear();

            //Реализация тестирования

            var testCase1 = new TestCase()
            {
                a = 97,
                Answer = "Число простое!",
                ExpectedException = new Exception()
            };

            var testCase2 = new TestCase()
            {
                a = 67,
                Answer = "Число простое!",
                ExpectedException = new Exception()
            };

            var testCase3 = new TestCase()
            {
                a = 371,
                Answer = "Число не простое!",
                ExpectedException = new Exception()
            };

            var testCase4 = new TestCase()
            {
                a = 26,
                Answer = "Число простое!",
                ExpectedException = new Exception()
            };

            var testCase5 = new TestCase()
            {
                a = 12,
                Answer = "Число простое!",
                ExpectedException = new Exception()
            };
            Test(testCase1);
            Test(testCase2);
            Test(testCase3);
            Test(testCase4);
            Test(testCase5);
            Console.ReadKey();
            Console.Clear();
        

            //Для задания 3
            Console.WriteLine("Введите число для подсчета числа Фибоначчи методом рекурсии:");
            int input1 = int.Parse(Console.ReadLine());
            Console.WriteLine(FibonacciRec(input1));
            Console.ReadKey();
            Console.Clear();

            //Реализация тестирования
            var testCase6 = new TestCaseFib()
            {
                f = 6,
                rightF = 8,
            };

            var testCase7 = new TestCaseFib()
            {
                f = 10,
                rightF = 55,
            };

            var testCase8 = new TestCaseFib()
            {
                f = 17,
                rightF = 1597,
            };

            var testCase9 = new TestCaseFib()
            {
                f = 5,
                rightF = 8,
            };

            var testCase10 = new TestCaseFib()
            {
                f = 7,
                rightF = 21,
            };

            TestFibRec(testCase6);
            TestFibRec(testCase7);
            TestFibRec(testCase8);
            TestFibRec(testCase9);
            TestFibRec(testCase10);

            Console.ReadKey();
            Console.Clear();
            
            Console.WriteLine("Введите число для подсчета числа Фибоначчи методом цикла:");
            int input2 = int.Parse(Console.ReadLine());
            Console.WriteLine(FibonacciFor(input2));
            Console.ReadKey();
            Console.Clear();
            
            var testCase11 = new TestCaseFib()
            {
                f = 6,
                rightF = 8,
            };

            var testCase12 = new TestCaseFib()
            {
                f = 10,
                rightF = 55,
            };

            var testCase13 = new TestCaseFib()
            {
                f = 17,
                rightF = 1597,
            };

            var testCase14 = new TestCaseFib()
            {
                f = 5,
                rightF = 8,
            };

            var testCase15 = new TestCaseFib()
            {
                f = 7,
                rightF = 21,
            };

            TestFibFor(testCase11);
            TestFibFor(testCase12);
            TestFibFor(testCase13);
            TestFibFor(testCase14);
            TestFibFor(testCase15);

            Console.ReadKey();
            Console.Clear();
        }
    }
}
