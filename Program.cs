using System;
using System.Diagnostics.CodeAnalysis;

namespace ConsoleApp
{
    internal class Program
    {
        class numberIsZero : Exception
        {
            public numberIsZero(string message) : base(message) { }
        }
        class numberLessZero : Exception
        {
            public numberLessZero(string message) : base(message) { }
        }
        static bool firstProgram()
        {
            long number;
            int powerNum;

            while (true)
            {
                Console.Write("Введите число: ");
                try
                {
                    number = Convert.ToInt64(Console.ReadLine());
                    if (number == 0)
                    {
                        throw new numberIsZero("Число должно быть не равно 0");
                    }
                    break;
                }
                catch (numberIsZero e)
                {
                    Console.WriteLine($"Ошибка! {e.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка! Попробуйте ввести целое число \n{ex.Message}");
                }
            }

            while (true)
            {
                Console.Write("Введите степень возводимого числа: ");
                try
                {
                    powerNum = Convert.ToInt32(Console.ReadLine());
                    if (powerNum <= 0)
                    {
                        throw new numberLessZero("Число должно быть больше нуля");
                    }
                    break;
                }
                catch (numberLessZero e)
                {
                    Console.WriteLine($"Ошибка! {e.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка! Попробуйте ввести целое число \n{ex.Message}");
                }
            }

            Console.WriteLine($"Вывод: {number}^{powerNum} = {MultipleNumber(number, powerNum)}");
            return true;
        }

        static long MultipleNumber(long number, int powerNum)
        {
            long fixNumber = number;
            for (int indexNum = 1; indexNum < powerNum; ++indexNum)
            {
                number *= fixNumber;
            }
            return number;
        }

        static void Main(string[] args)
        {
            firstProgram();
        }
    }
}
