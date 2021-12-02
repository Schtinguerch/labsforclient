using System;
using static System.Console;

namespace L3_task08
{
    class Program
    {
        static void Main(string[] args)
        {
            const int count = 10;
            double[] array = new double[count] { 3, -1, 3, -2, -7, -7, 3, -5, -4, 3 };

            WriteLine("Входной массив:");
            for (int i = 0; i < count; i++)
                WriteLine($"[{i}] = {array[i]}");

            int negativeNumberCount = 0;
            for (int i = 0; i < array.Length; i++)
                if (array[i] < 0) negativeNumberCount++;

            int[] negativeNumberIndexes = new int[negativeNumberCount];
            int index = -1;

            for (int i = 0; i < array.Length; i++) 
                if (array[i] < 0) negativeNumberIndexes[++index] = i;

            for (int i = 0; i < negativeNumberIndexes.Length; i += 1)
                for (int j = 0; j < negativeNumberIndexes.Length - 1; j += 1)
                    if (array[negativeNumberIndexes[j]] > array[negativeNumberIndexes[j + 1]])
                    {
                        double temp = array[negativeNumberIndexes[j + 1]];
                        array[negativeNumberIndexes[j + 1]] = array[negativeNumberIndexes[j]];
                        array[negativeNumberIndexes[j]] = temp;
                    }

            WriteLine("Упорядоченный массив:");
            for (int i = 0; i < count; i++)
                WriteLine($"[{i}] = {array[i]}");
        }
    }
}
