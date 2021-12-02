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

            for (int i = 0; i < vector.Length; i++)
                WriteLine($"{i + 1}-й элемент = {vector[i]}");

            double sum = 0;
            for (int i = 0; i < vector.Length; i++)
                sum += vector[i] * vector[i];

            double length = Sqrt(sum);
            WriteLine($"L = {length}");
        }
    }
}
