using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

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

        class numberLessOneHundred : Exception
        {
            public numberLessOneHundred(string message) : base(message) { }
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
        static bool secondProgram()
        {
            long numberResult;
            while (true)
            {
                Console.Write("Введите число x (x должно быть >= 100): ");
                try
                {
                    long input = Convert.ToInt64(Console.ReadLine());
                    if (input < 100)
                    {
                        throw new numberLessOneHundred("x должно быть >= 100");
                    }
                    string strInput = input.ToString();
                    char secondDigit = strInput[1];
                    string strMod = strInput.Remove(1, 1);
                    string strResult = strMod + secondDigit;
                    numberResult = long.Parse(strResult);
                    break;
                }
                catch (numberLessOneHundred e)
                {
                    Console.WriteLine($"Ошибка! {e.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка! {ex.Message}");
                }
            }

            Console.WriteLine($"Результат: {numberResult}");
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
            byte menuChoice = byte.MaxValue;
            while (menuChoice != 3)
            {
                Console.WriteLine("[1] Первая программа [2] Вторая программа [3] Выйти");
                Console.Write("Ввод меню: ");
                try
                {
                    menuChoice = Convert.ToByte(Console.ReadLine());
                    if (menuChoice == 0 || menuChoice > 3)
                    {
                        throw new Exception("Введите число от 1 до 3");
                    }
                    switch (menuChoice)
                    {
                        case 1:
                            firstProgram();
                            break;
                        case 2:
                            secondProgram();
                            break;
                        case 3:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка! {ex.Message}");
                }
            }
        }
    }
}
