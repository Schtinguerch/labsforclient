using System;
using static System.Console;

namespace L3_task12
{
    class Program
    {
        static void Main(string[] args)
        {
            const int count = 12;
            double[] array = new double[count] { 6, 9, -2, 0, 1, 19, 7 -6, -1, 9, 4, 3, 11 };

            WriteLine("Входной массив:");
            for (int i = 0; i < count; i++)
                WriteLine($"[{i}] = {array[i]}");

            array = Array.FindAll(array, x => x >= 0);

            WriteLine("Массив без отриц. чисел:");
            for (int i = 0; i < array.Length; i++)
                WriteLine($"[{i}] = {array[i]}");
        }
    }
}
