//Для самых маленьких.
//Реализовать быструю сортировку, сортировку пузырьком и линейный поиск , 
//бинарный поиск. Протестировать скорость работы алгоритмов, определить сложность алгоритмов (8 баллов).
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSort
{
    class Program
    {
        static int[] BubbleSort(int[] array)
        {
            int temp;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
            return array;
        }
        static void Main(string[] args)
        {
            Console.Write("Введите количество элементов массива: ");
            int max = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nСгенерированный массив: ");
            Console.Write("\n");
            int[] array = new int[max];
            Random rnd = new Random();
            for (int i = 0; i < max; i++)
            {
                array[i] = rnd.Next(-1000, 1000);
                Console.Write(array[i] + " ");
            }
            Console.Write(" \n");

            BubbleSort(array);
            Console.WriteLine("\n\nОтсортированный массив: ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");

            }
            DateTime startTime = DateTime.Now;
            Console.WriteLine("\nTotal Time: {0}\n", DateTime.Now - startTime);
            Console.ReadLine();
        }
    }
}
