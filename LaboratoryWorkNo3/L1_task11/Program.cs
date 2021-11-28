using System;
using static System.Console;

namespace L1_task11
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] allNumbers = new double[10] { 3, 4, 91, -7, 0, 18, 11, -99, 19, 0 };
            double[] positiveNumbers = FindPositive(allNumbers);

            WriteLine("Сформированный массив из положительных чисел:");
            PrintArray(positiveNumbers);
        }

        static double[] FindPositive(double[] numbers)
        {
            int count = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > 0)
                {
                    count++;
                }
            }

            double[] positiveNumbers = new double[count];
            int index = -1;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > 0)
                {
                    index++;
                    positiveNumbers[index] = numbers[i];
                }
            }

            return positiveNumbers;
        }

        static void PrintArray(double[] array)
        {
            if (array.Length == 0)
            {
                WriteLine("* Массив пустой *");
            }

            else
            {
                WriteLine($"Массив из {array.Length} элементов:");

                for (int i = 0; i < array.Length; i++)
                {
                    WriteLine($"{i + 1}-й элемент = {array[i]}");
                }
            }
        }
    }
}
