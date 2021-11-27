using System;
using static System.Console;
using static System.Math;

namespace L2_task04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Write("Введите значение X: ");

            double x = double.Parse(ReadLine());
            double epsilon = 0.0001;

            WriteLine("s = " + FunctionValue(x, epsilon) + ", при eplison = " + epsilon.ToString());
        }

        static double FunctionValue(double x, double epsilon)
        {
            double currentValue = 1, result = currentValue;

            while (Abs(currentValue) >= epsilon)
            {
                currentValue *= x * x;
                result += currentValue;
            }

            return result;
        }
    }
}
