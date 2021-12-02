using System;
using static System.Console;
using static System.Math;

namespace L3_task09
{
    class Program
    {
        static void Main(string[] args)
        {
            const int count = 10;
            double[] array = new double[count] { 4, 8, 2, 3, 0, 7, 8, 9, 1, 3 };

            WriteLine("Входной массив:");
            for (int i = 0; i < count; i++)
                WriteLine($"[{i}] = {array[i]}");

            int orderLength = 1, maxOrderLength = 1;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] >= array[i - 1])
                {
                    orderLength++;
                }

                else
                {
                    maxOrderLength = Max(orderLength, maxOrderLength);
                    orderLength = 1;
                }
            }

            maxOrderLength = Max(orderLength, maxOrderLength);
            WriteLine($"Длина самой длинной упор. последовательности = {maxOrderLength}");
        }
    }
}
