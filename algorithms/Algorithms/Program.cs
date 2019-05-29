using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Program
    {
        public static string str;
        public static int number, i;
        public static int[] arr;
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Введите количество элементов массива: ");

                str = Console.ReadLine();
                number = Int32.Parse(str);
                if (number > 1000 * 1000)
                {
                    Console.WriteLine("Значения массива превышают диапазон значений!\n");
                    continue;
                }
                else if (number == 0)
                {
                    Console.WriteLine("Пустой массив\n");
                    continue;
                }
                else if (number < 0)
                {
                    Console.WriteLine("Введите положительное число\n");
                    continue;
                }
                else
                    Console.Write(" \n");

                Console.WriteLine("Исходный массив: ");
                arr = new int[number];
                Random random = new Random();
                i = 0;
                do
                 {
                    //int randomNumber = random.Next(-1000, 1000);
                    int randomNumber = random.Next(0, 10);
                    arr[i] = randomNumber;
                    i++;
                    /*if (Array.IndexOf(arr, randomNumber) == -1)
                     {
                         arr[i] = randomNumber;
                         i++;
                     }*/
            } while (i < number);

                for (var k = 0; k < number - 1; k++)
                {
                    Console.Write(arr[k] + " ");
                }

                Console.Write(arr[number - 1]);
                Console.WriteLine(' ');
                Console.WriteLine("\n1 - Быстрая сортировка \n2 - Сортировка пузырьком\n3 - Линейный поиск\n4 - Двоичный поиск\n5 - Выход ");
                Console.Write("\nВыберите пункт меню: ");
                string buf = Console.ReadLine();
                //Check(buf);
                switch (buf)
                {
                    case "1":
                        QuickSort(arr);
                        void DoSort(int[] items, int fst, int lst)
                        {
                            if (fst >= lst)
                            {
                                return;
                            }
                            int p = fst;
                            int j = lst;
                            int x = items[(fst + lst) / 2];

                            while (p < j)
                            {
                                while (items[p] < x) p++;
                                while (items[j] > x) j--;
                                if (p <= j)
                                {
                                    int tmp = items[p];
                                    items[p] = items[j];
                                    items[j] = tmp;
                                    p++;
                                    j--;
                                }
                            }
                            DoSort(items, fst, j);
                            DoSort(items, p, lst);
                        }

                        int[] Sort(int[] arr)
                        {
                            var items = new int[arr.Length];
                            arr.CopyTo(items, 0);
                            DoSort(items, 0, items.Length - 1);
                            return items;
                        }

                        void QuickSort(int[] arr)
                        {
                                var sortItems = Sort(arr);
                                
                                Console.WriteLine("\nОтсортированный массив: ");
                                for (i = 0; i < arr.Length; i++)
                                {
                                    Console.Write(sortItems[i] + " ");
                                }
                                Console.Write(" \n");
                                DateTime startTime = DateTime.Now;
                                Console.WriteLine("Total Time: {0}\n", DateTime.Now - startTime);
                                Console.ReadLine();
                        }
                        break;
                    case "2":
                        BubbleSort(arr);
                        int[] DoSort_1(int[] arr)
                        {
                            int temp;
                            for (int i = 0; i < arr.Length; i++)
                            {
                                for (int j = i + 1; j < arr.Length; j++)
                                {
                                    if (arr[i] > arr[j])
                                    {
                                        temp = arr[i];
                                        arr[i] = arr[j];
                                        arr[j] = temp;
                                    }
                                }
                            }
                            return arr;
                        }
                        void BubbleSort(int[] arr)
                        {
                            DoSort_1(arr);
                            Console.WriteLine("\n\nОтсортированный массив: ");
                            for (int i = 0; i < arr.Length; i++)
                            {
                                Console.Write(arr[i] + " ");

                            }
                            DateTime startTime = DateTime.Now;
                            Console.WriteLine("\nTotal Time: {0}\n", DateTime.Now - startTime);
                            Console.ReadLine();
                        }
                        break;
                    case "3":
                        LinearSearch(arr);
                        void LinearSearch(int[] arr)
                        {
                            Console.Write("\nВведите элемент, который хотите найти: ");
                            string str_guess = Console.ReadLine();
                            int count = 0;
                            int guess = Int32.Parse(str_guess);
                            for (int i = 0; i < number; i++)
                            {
                                if (arr[i] == guess)
                                {
                                    Console.Write("\nЭлемент {0} находится в массиве под номером {1}\n", guess, i);
                                }
                                else
                                {
                                    count++;
                                }
                            }
                            if (count == number)
                            {
                                Console.Write("\nЭлемент не найден");
                            }
                            DateTime startTime = DateTime.Now;
                            Console.WriteLine("\nTotal Time: {0}\n", DateTime.Now - startTime);
                            Console.ReadLine();
                        }
                        break;
                    case "4":
                        BinarySearch(arr);
                        void BinarySearch(int[] arr)
                        {
                            Array.Sort(arr);
                            Console.WriteLine("\n\nОтсортированный массив: \n");
                            Array.ForEach(arr, x =>
                            {
                                Console.Write(x + " ");
                            });
                            Console.Write("\n\nНайти: ");
                            int key = int.Parse(Console.ReadLine());
                            int j = DoSearch(arr, key, 0, arr.Length);
                            int count = 0;
                            for (int i = 0; i < arr.Length; i++)
                            {
                                if (j < arr.Length && j >= 0 && arr[i] == key)
                                    Console.Write("\nЭлемент {0} находится в массиве под номером {1}\n", key, i);
                                else
                                    count++;
                            }
                            if(count == arr.Length)
                            Console.WriteLine("\nЭлемент не найден\n");
                            DateTime startTime = DateTime.Now;
                            Console.WriteLine("Total Time: {0}\n", DateTime.Now - startTime);
                            Console.ReadKey(true);
                        }

                        int DoSearch(int[] arr, int key, int left, int right)
                        {
                            var middle = (left + right) / 2;
                            if (left >= right)
                                return -(1 + left);

                            if (arr[middle] == key)
                                return middle;

                            else if (arr[middle] > key)
                                return DoSearch(arr, key, left, middle);
                            else
                                return DoSearch(arr, key, middle + 1, right);
                        }
                        break;
                    case "5":
                        return;
                }
            }
        }
    }
}
