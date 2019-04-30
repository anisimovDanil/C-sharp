//Для самых маленьких.
//Реализовать быструю сортировку, сортировку пузырьком и линейный поиск , 
//бинарный поиск. Протестировать скорость работы алгоритмов, определить сложность алгоритмов (8 баллов).
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("Введите количество элементов массива: ");
            string str = Console.ReadLine();
            int number = Int32.Parse(str);
            if (number > 1000 * 1000)
            {
                Console.WriteLine("Значения массива превышают диапазон значений!");
                return;
            }
            else
                Console.Write(" \n");

            int[] arr = new int[number];
            int i = 0;
            do
            {
                Random random = new Random();
                int randomNumber = random.Next(-1000, 1000);

                if (Array.IndexOf(arr, randomNumber) == -1)
                {
                    arr[i] = randomNumber;
                    i++;
                }
            } while (i < number);

            for (var k = 0; k < number - 1; k++)
            {
                Console.Write(arr[k] + " ");
            }

            Console.Write(arr[number - 1]);

            Array.Sort(arr);

            Console.WriteLine("\n\nОтсортированный массив: \n");
            Array.ForEach(arr, x =>
            {
                Console.Write(x + " ");
            });

            Console.Write("\n\nНайти: ");
            int key = int.Parse(Console.ReadLine());
            int j = BinarySearch(arr, key, 0, arr.Length);
            if (j < arr.Length && j > 0)
                Console.WriteLine("\nИндекс искомого элемента: {0}", j + 1);
            else
                Console.WriteLine("\nЭлемент не найден\n");
            DateTime startTime = DateTime.Now;
            Console.WriteLine("Total Time: {0}\n", DateTime.Now - startTime);
            Console.ReadKey(true);
        }

        static int BinarySearch(int[] arr, int key, int left, int right)
        {
            var middle = (left + right) / 2;
            if (left >= right)
                return -(1 + left);

            if (arr[middle] == key)
                return middle;

            else if (arr[middle] > key)
                return BinarySearch(arr, key, left, middle);
            else
                return BinarySearch(arr, key, middle + 1, right);
        }
    }
}
