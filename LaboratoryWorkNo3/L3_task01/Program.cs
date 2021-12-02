using System;
using static System.Console;

namespace L3_task01
{
    class Program
    {
        static void Main(string[] args)
        {
            const int count = 10;
            double[] array = new double[count] { 1, 2, 99, 5, 8, 99, 99, 3, 7, 11 };

            WriteLine("Входной массив:");
            for (int i = 0; i < count; i++)
                WriteLine($"[{i}] = {array[i]}");

            double maxValue = array[0];
            int maxCount = 1;
            for (int i = 1; i < count; i++)
            {
                if (array[i] == maxValue) maxCount++;
                if (array[i] > maxValue) { maxValue = array[i]; maxCount = 1; }
            }

            int[] maxIndexArray = new int[maxCount];
            int index = -1;

            for (int i = 0; i < count; i++)
                if (array[i] == maxValue) maxIndexArray[++index] = i;

            WriteLine("\nМассив индексов с макс. числом:");
            for (int i = 0; i < maxCount; i++)
                WriteLine($"[{i}] = {maxIndexArray[i]}");
        }
    }
}
