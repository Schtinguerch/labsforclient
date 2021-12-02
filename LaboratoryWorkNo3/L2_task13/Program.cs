using System;
using static System.Console;

namespace L2_task13
{
    class Program
    {
        static void Main(string[] args)
        {
            const int count = 10;
            double[] array = new double[count] { 4, 8, 6, 7, 5, 99, 23, 3, 4, 9 };

            WriteLine("Входной массив:");
            for (int i = 0; i < count; i++)
                WriteLine($"[{i}] = {array[i]}");

            int maxIndex = 0;
            for (int i = 0; i < array.Length; i += 2)
                if (array[i] > array[maxIndex]) maxIndex = i;

            array[maxIndex] = maxIndex;

            WriteLine("Итоговый массив:");
            for (int i = 0; i < count; i++)
                WriteLine($"[{i}] = {array[i]}");
        }
    }
}
