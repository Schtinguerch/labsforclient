using System;
using static System.Console;
using static System.Math;

namespace L3_task01
{
    internal class Program
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
                    "  y = " + Cos(x).ToString() + 
                    "  s = " + FunctionValue(x, 0.0001).ToString());
            }
        }

        static double FunctionValue(double x, double epsilon)
        {
            double result = 0, currentValue = 1, i = 0;

            while (Abs(currentValue) >= epsilon)
            {
                result += currentValue;
                currentValue *= -1 * x * x / ++i / ++i;
            }

            return result;
        }
    }
}
