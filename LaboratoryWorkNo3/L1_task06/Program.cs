using System;
using static System.Console;
using static System.Math;

namespace LaboratoryWorkNo3
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] vector = new double[5] { 5, 9, -4, 8, 0 };
            PrintArray(vector);

            ShowClarification(vector);
        }

        static double GetVectorLength(double[] vector)
        {
            double sum = 0;
            for (int i = 0; i < vector.Length; i++)
                sum += vector[i] * vector[i];

            double length = Sqrt(sum);
            return length;
        }

        static void ShowClarification(double[] vector)
        {
            double length = GetVectorLength(vector);

            Write($"L = Sqrt({vector[0]}*{vector[0]}");
            for (int i = 1; i < vector.Length; i++)
                Write($" + {vector[i]}*{vector[i]}");

            WriteLine($") = {length}");
        }

        static void PrintArray(double[] array)
        {
            if (array.Length == 0)
            {
                WriteLine("* Массив пустой *");
            }

            else
            {
                WriteLine($"Массив из {array.Length} элементов:");

                for (int i = 0; i < array.Length; i++)
                {
                    WriteLine($"{i + 1}-й элемент = {array[i]}");
                }
            }
        }
    }
}
