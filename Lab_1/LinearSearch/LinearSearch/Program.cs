//Для самых маленьких.
//Реализовать быструю сортировку, сортировку пузырьком и линейный поиск , 
//бинарный поиск. Протестировать скорость работы алгоритмов, определить сложность алгоритмов (8 баллов).
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinerSearch

{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество элементов массива: ");
            string str = Console.ReadLine();
            int number = Int32.Parse(str);
            Console.Write(" \n");

            int[] arr = new int[number];
            Random rnd = new Random();
            for (int i = 0; i < number; i++)
            {
                arr[i] = rnd.Next(-100, 100);
                Console.Write(arr[i] + " ");
            }
            Console.Write(" \n");

            Console.Write("\nВведите элемент, который хотите найти: ");
            string str_guess = Console.ReadLine();
            int count = 0;
            int guess = Int32.Parse(str_guess);
            for (int i = 0; i < number; i++)
            {
                if (arr[i] == guess)
                {
                    Console.Write("\nЭлементы {0} находится в массиве под номером {1}\n", guess, i + 1);
                }
                else
                {
                    count++;
                }

            }
            if(count == number)
            {
                Console.Write("\nЭлемент не найден");
            }
            DateTime startTime = DateTime.Now;
            Console.WriteLine("\nTotal Time: {0}\n", DateTime.Now - startTime);
            Console.ReadLine();
        }
    }
}