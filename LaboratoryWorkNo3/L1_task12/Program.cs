using System;
using static System.Console;

namespace L1_task12
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = new double[10] { 7, 8, -90, 25, 9, 12, -6, 11, 24, 0 };
            for (int i = 0; i < numbers.Length; i++)
                WriteLine($"[{i}] = {numbers[i]}");

            int lastNegativeIndex = -1;
            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                if (numbers[i] < 0)
                {
                    lastNegativeIndex = i;
                    break;
                }
            }

            WriteLine($"Индекс последнего отриц. числа = {lastNegativeIndex}");
        }
    }
}
