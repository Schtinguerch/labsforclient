using System;
using static System.Console;

namespace L1_task13
{
    class Program
    {
        static void Main(string[] args)
        {
            //Индекс соответствует значению
            double[] baseArray = new double[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            for (int i = 0; i < baseArray.Length; i++)
                WriteLine($"[{i}] элемент = {baseArray[i]}");

            double[] evenArray = new double[5];
            double[] oddArray = new double[5];

            for (int i = 1; i < baseArray.Length; i += 2)
            {
                evenArray[i / 2] = baseArray[i - 1];
                oddArray[i / 2] = baseArray[i];
            }

            WriteLine("\nМассив чётных индексов:");
            for (int i = 0; i < evenArray.Length; i++)
                WriteLine($"[{i}] элемент = {evenArray[i]}");

            WriteLine("\nМассив НЕчётных индексов:");
            for (int i = 0; i < oddArray.Length; i++)
                WriteLine($"[{i}] элемент = {oddArray[i]}");
        }
    }
}
