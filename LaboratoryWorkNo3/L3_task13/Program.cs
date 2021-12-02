using System;
using System.Linq;
using static System.Console;

namespace L3_task13
{
    class Program
    {
        static void Main(string[] args)
        {
            const int count = 12;
            double[] array = new double[count] { 6, 9, 2, 0, 1, 9, 7 - 6, 1, 9, 4, 9, 11 };

            WriteLine("Входной массив:");
            for (int i = 0; i < count; i++)
                WriteLine($"[{i}] = {array[i]}");

            array = array.Distinct().ToArray();

            WriteLine("Массив дубликатов:");
            for (int i = 0; i < array.Length; i++)
                WriteLine($"[{i}] = {array[i]}");
        }
    }
}
