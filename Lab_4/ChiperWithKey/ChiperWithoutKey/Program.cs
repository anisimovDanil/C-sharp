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
            while (true)
            {
                Console.WriteLine("1 - Зашифровать \n2 - Расшифровать\n3 - Выход ");
                Console.Write("\nВыберите пункт меню: ");
                string buf = Console.ReadLine();
                Check(buf);
                switch (buf)
                {
                    case "1":
                        while (true)
                        {
                            Console.Write("Введите ключ: ");
                            string check_key = Console.ReadLine();
                            bool a = isDigits(check_key);
                            if (a == false)
                            {
                                Console.WriteLine("\nВведено некоректное значение\n");
                                continue;
                            }

                            else
                            {
                                int key = Int32.Parse(check_key);
                                Console.Write("Введите строку: ");
                                var line = Console.ReadLine();
                                   
                                line = line.Replace(" ", string.Empty);
                                line = line.ToLower();
                                char[] array = line.ToCharArray();

                                double number = (double)array.Length / (double)key;
                                bool check_integer = unchecked(number == (int)number);

                                if (check_integer == false)
                                {
                                    Console.WriteLine("Невозможно зашифровать строку, так как число строк - не целое число\n");
                                    continue;
                                }
                                else
                                {
                                    int rowCount = (int)number;

                                    var invertedArray = new char[rowCount, key];
                                    var counter = 0;
                                    for (var i = 0; i < key; i++)
                                    {
                                        for (var j = 0; j < rowCount; j++)
                                        {
                                            invertedArray[j, i] = array[counter++];
                                        }
                                    }

                                    Console.WriteLine("\nПолученная матрица: \n");
                                    for (var j = 0; j < rowCount; j++)
                                    {
                                        for (var i = 0; i < key; i++)
                                        {
                                            Console.Write(invertedArray[j, i] + " ");
                                        }
                                        Console.WriteLine();
                                    }
                                    Console.WriteLine();

                                    Console.Write("Зашифрованная строка: ");
                                    for (var k = 0; k < rowCount; k++)
                                    {
                                        for (var h = 0; h < key; h++)
                                        {
                                            Console.Write(invertedArray[k, h]);
                                        }
                                    }
                                    Console.WriteLine("\n");
                                    break;
                                    }
                                }
                            }
                    break;
                    case "2":
                    while (true)
                    {
                        Console.Write("Введите ключ: ");
                        string check_clue = Console.ReadLine();
                        var b = isDigits(check_clue);

                        if (b == false)
                        {
                            Console.WriteLine("\nВведено некоректное значение\n");
                            continue;
                        }

                        else
                        {
                            int clue = Int32.Parse(check_clue);
                            Console.Write("Введите строку: ");
                            var words = Console.ReadLine();

                            words = words.Replace(" ", string.Empty);
                            words = words.ToLower();
                            char[] arr = words.ToCharArray();

                            double num = (double)arr.Length / (double)clue;
                            bool check_int = unchecked(num == (int)num);

                            if (check_int == false)
                            {
                                Console.WriteLine("Невозможно зашифровать строку, так как число строк - не целое число\n");
                                continue;
                            }
                            else
                            {
                                int rowCount = (int)num;
                                var reverseArray = new char[rowCount, clue];
                                var count = 0;
                                for (var i = 0; i < rowCount; i++)
                                {
                                    for (var j = 0; j < clue; j++)
                                    {
                                        reverseArray[i, j] = arr[count++];
                                    }
                                }
                                Console.WriteLine();

                                Console.Write("Расшифрованная строка: ");
                                for (var k = 0; k < clue; k++)
                                {
                                    for (var h = 0; h < rowCount; h++)
                                    {
                                        Console.Write(reverseArray[h, k]);
                                    }
                                }
                                Console.WriteLine("\n");
                                break;
                            }
                        }
                    }
                    break;
                    case "3":
                    return;
                }
            }
        }


        public static void Check(string buf)
        {
            string[] arr = new string[3] { "1", "2", "3" };
            var flag = 0;
            for (var i = 0; i < arr.Length; i++)
            {
                if (arr[i] == buf)
                {
                    flag++;
                }
            }
            if (flag == 0)
            {
                Console.WriteLine("\nВведен неверный пункт\n");
            }
        }

        public static bool isDigits(string check_key)
        {
            if (check_key == null || check_key == "") return false;

            for (int i = 0; i < check_key.Length; i++)
                if ((check_key[i] ^ '0') > 9)
                    return false;

            return true;
        }


    }
}

//===============================
// str -----> line
// columnCount -----> key
//===============================

/* string str = "forty-two";
    char pad = '!';
    Console.WriteLine(str.PadRight(15, pad));
*/
