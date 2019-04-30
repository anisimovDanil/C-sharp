//Для самых маленьких.
//Реализовать быструю сортировку, сортировку пузырьком и линейный поиск , 
//бинарный поиск. Протестировать скорость работы алгоритмов, определить сложность алгоритмов (8 баллов).
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickSort
{
    class Program
    {
        static public void DoSort(int[] items, int fst, int lst)
        {
            if (fst >= lst)
            {
                return;
            }
            int i = fst;
            int j = lst;
            int x = items[(fst + lst) / 2];

            while(i < j)
            {
                while (items[i] < x) i++;
                while (items[j] > x) j--;
                if(i <= j)
                {
                    int tmp = items[i];
                    items[i] = items[j];
                    items[j] = tmp;
                    i++;
                    j--;
                }
            }
            DoSort(items, fst, j);
            DoSort(items, i, lst);
        }

        static public int[] Sort(int[] arr)
        {
            var items = new int[arr.Length];
            arr.CopyTo(items, 0);
            DoSort(items, 0, items.Length - 1);
            return items;
        }

        static void Main(string[] args)
        {
            Console.Write("Введите количество элементов массива: ");
            string str = Console.ReadLine();
            int max = Convert.ToInt32(str);
            if (max == 0)
            {
                Console.WriteLine("Пустой массив");
                return;
            }
            else if(max < 0)
            {
                Console.WriteLine("Некорректное значение");
                return;
            }
            else
            {
                int[] items = new int[max];
                Random rnd = new Random();
                Console.Write("\nСгенерированный массив: ");
                Console.Write("\n");
                for (int i = 0; i < max; i++)
                {
                    items[i] = rnd.Next(-1000, 1000);
                    Console.Write(items[i] + " ");
                }
                Console.Write("\n");

                var sortItems = Sort(items);
                Console.WriteLine("\nОтсортированный массив: ");
                for (var i = 0; i < items.Length; i++)
                {
                    Console.Write(sortItems[i] + " ");
                }
                Console.Write(" \n");
                DateTime startTime = DateTime.Now;
                Console.WriteLine("Total Time: {0}\n", DateTime.Now - startTime);
                Console.ReadLine();
            } 
        }
    }
}
