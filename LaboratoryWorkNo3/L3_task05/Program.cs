using System;
using static System.Console;

namespace L3_task05
{
    class Program
    {
        static void Main(string[] args)
        {
            const int count = 10;
            double[] array = new double[count] { 9, 9, 7, 7, 8, 8, 9, 9, 6, 6 };

            WriteLine("Входной массив:");
            for (int i = 0; i < count; i++)
                WriteLine($"[{i}] = {array[i]}");

            for (int i = 0; i < array.Length; i += 2)
                for (int j = 0; j < array.Length - 2; j += 2)
                    if (((array.Length - j) >= 2) && (array[j] > array[j + 2]))
                    {
                        double temp = array[j + 2];
                        array[j + 2] = array[j];
                        array[j] = temp;
                    }

            WriteLine("Массив с упорядоченными чётными индексами:");
            for (int i = 0; i < count; i++)
                WriteLine($"[{i}] = {array[i]}");
        }
    }
}
