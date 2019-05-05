using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace Rextester
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Введите строку: ");
            var str = Console.ReadLine();

            // удаление пробелов
            str = str.Replace(" ", string.Empty);

            char[] array = str.ToCharArray();
            var columnCount = 5;

            // проверка на целостность строк
            double number = (double)array.Length / (double)columnCount;
            bool check_integer = unchecked(number == (int)number);


            if (check_integer == false)
            {
                Console.WriteLine("Точно ключ 5?");
                return;
            }
            else
            {
                int rowCount = (int)number;
                //var invertedArr = new char[columnCount, rowCount];
                //var count = 0;

                // создание стандартной матрицы
                // вывод стандартной матрицы в консоль
                /*Console.WriteLine("\nПервоначал матрица: \n");
                for (var r = 0; r < columnCount; r++)
                {
                    for (var w = 0; w < rowCount; w++)
                    {
                        invertedArr[r, w] = array[count++];
                        Console.Write(invertedArr[r, w] + " ");
                    }
                    Console.WriteLine();
                }*/

                // создание матрицы шифра
                var invertedArray = new char[rowCount, columnCount];
                var counter = 0;
                for (var i = 0; i < columnCount; i++)
                {
                    for (var j = 0; j < rowCount; j++)
                    {
                        invertedArray[j, i] = array[counter++];
                    }
                }

                // вывод матрицы шифра
                Console.WriteLine("\nПолученная матрица: \n");
                for (var j = 0; j < rowCount; j++)
                {
                    for (var i = 0; i < columnCount; i++)
                    {
                        Console.Write(invertedArray[j, i] + " ");

                    }
                    Console.WriteLine();
                }
                Console.WriteLine();

                Console.Write("Зашифрованная строка: ");
                for (var k = 0; k < rowCount; k++)
                {
                    for (var h = 0; h < columnCount; h++)
                    {
                        Console.Write(invertedArray[k, h]);
                    }
                }
                Console.WriteLine("\n");
            }
        }
    }
}