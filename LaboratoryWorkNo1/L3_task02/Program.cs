using System;
using static System.Console;
using static System.Math;

namespace L3_task02
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowFunctionValues(0.1, 1, 0.1);
        }

        static void ShowFunctionValues(double start, double end, double delta)
        {
            for (double x = start; x <= end; x += delta)
            {
                WriteLine(
                "  x = " + x.ToString() + ":" +
                "  y = " + BaseFunctionValue(x).ToString() +
                "  s = " + FunctionValue(x, 0.0001).ToString());
            }
        }

        static double BaseFunctionValue(double x)
        {
            double numerator = x * Sin(PI / 4d);
            double denominator = 1 - 2 * x * Cos(PI / 4d) + x * x;

            return numerator / denominator;
        }

        static double FunctionValue(double x, double epsilon)
        {
            double result = 0, multipler = x, i = 1;

            while (Abs(multipler) >= epsilon)
            {
                result += multipler * Sin(i * PI / 4d);

                multipler *= x;
                i++;
            }

            return result;
        }
    }
}
