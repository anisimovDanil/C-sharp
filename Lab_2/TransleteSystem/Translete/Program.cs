//Для самых маленьких.
//Реализовать программу для перевода из одной системы счисления в другую (8 баллов).
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class GFG
{
    static int value(char c)
    {
        if (c >= '0' && c <= '9')
            return (int)c - '0';
        else
            return (int)c - 'A' + 10;
    }


    static int ChoiceSystem(string str, int system)
    {
        int power = 1;                 
        int num = 0; 
        for (int i = (str.Length) - 1; i >= 0; i--)
        {
            if (value(str[i]) >= system)
            {
                Console.WriteLine("Неправильная система счисления");
                return -1;
            }
            else if (Convert.ToInt32(value(str[i])) == Convert.ToDouble(value(str[i])))
            {
                num += value(str[i]) * power;
                power = power * system;
            }           
        }
        return num;
    }


    public static string TranslateNumber(int translate_system, int num)
    {
        const int BitsInLong = 64;
        const string Digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        if (num == 0)
            return "0";

        int index = BitsInLong - 1;
        long currentNumber = Math.Abs(num);
        char[] charArray = new char[BitsInLong];

        while (currentNumber != 0)
        {
            int remainder = (int)(currentNumber % translate_system);
            charArray[index--] = Digits[remainder];
            currentNumber = currentNumber / translate_system;
        }

        string result = new String(charArray, index + 1, BitsInLong - index - 1);
        if (num < 0)
        {
            result = "-" + result;
        }
        return result;
    }


    public static void Main()
    {
        Console.Write("Введите число: ");
        string str = Console.ReadLine();
        if (str != new string(str.Where(c => Char.IsLetterOrDigit(c) || Char.IsWhiteSpace(c)).ToArray()))
        {
            Console.WriteLine("Не число или дробное число");
        }
        else
        {
            Console.Write("Система счисления числа: ");
            int system = Int32.Parse(Console.ReadLine());
            Console.Write("Перевод в систему счисления: ");
            int translate_system = Int32.Parse(Console.ReadLine());

            str = str.ToUpper();
            int num = ChoiceSystem(str, system);
            Console.WriteLine("Введеное число: " + str + " в " + system + "-й системе, переведённое в " + translate_system + "-ю систему: " 
            	+ TranslateNumber(translate_system, num));
        }
    }
}
