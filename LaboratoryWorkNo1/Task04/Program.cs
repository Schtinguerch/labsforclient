using System;
using static System.Console;
using static System.Math;

namespace LaboratoryWorkNo1
{
    class Program
    {
        static void Main(string[] args)
        {
            Write("Введите значение X: ");
            double x = double.Parse(ReadLine());

            WriteLine("s = " + FunctionValue(x).ToString());
        }

        static double FunctionValue(double x)
        {
            double argument = x;
            double numerator = Cos(argument);
            double denominator = 1;

            double value = numerator / denominator;

            for (int i = 2; i < 9; i++)
            {
                argument += x;
                denominator *= x;

                value += numerator / denominator;
            }

            return value;
        }
    }
}
