using System;
using static System.Console;
using static System.Math;

namespace L2_task06
{
    class Program
    {
        static void Main(string[] args)
        {
            const int count = 10;
            double[] numbers = new double[count] { 1, 6, 8, 3, 5, 7, 2, 1, 9, 0 };

            for (int i = 0; i < count - 1; i++)
                WriteLine($"[{i}] = {numbers[i]}");

            Write("Введите число P, которое необходимо вставить в массив: ");
            double p = double.Parse(ReadLine());

            double elementSum = 0;
            for (int i = 0; i < numbers.Length; i++)
                elementSum += numbers[i];

            double averageValue = elementSum / numbers.Length;
            int nearestToAverageIndex = 0;
            int offset = 1;

            for (int i = 0; i < numbers.Length; i++)
                if (Abs(numbers[i] - averageValue) < Abs(numbers[nearestToAverageIndex] - averageValue))
                    nearestToAverageIndex = i;

            for (int i = count -1; i >= 0; i--)
            {
                if (i == nearestToAverageIndex + 1)
                {
                    offset--;
                    numbers[i] = p;
                    continue;
                }
                    
                numbers[i] = numbers[i - offset];
            }

            WriteLine("\nМассив с вставленным P:");
            for (int i = 0; i < count; i++)
                WriteLine($"[{i}] = {numbers[i]}");
        }
    }
}
