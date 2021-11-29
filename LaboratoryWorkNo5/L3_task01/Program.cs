using System;
using static System.Console;
using static System.Math;

namespace L3_task01
{
    class Program
    {
        delegate double Function(double x);

        static void Main(string[] args)
        {
            const double A = 0.1;
            const double B = 1;
            const double deltaX = 0.1;

            for (double x = A; x <= B; x += deltaX)
            {
                double y = FunctionValue(StandardFunction, x);
                double s = FunctionValue(TaylorRowFunction, x);

                WriteLine($"x = {x}:   y = {y};   s = {s}");
            }
        }

        static double FunctionValue(Function function, double argument)
        {
            return function(argument);
        }

        static double StandardFunction(double x)
        {
            return Exp(Cos(x)) * Cos(Sin(x));
        }

        static double TaylorRowFunction(double x)
        {
            const double epsilon = 0.0001;

            double sum = 1;
            double rowItemValue = 1;

            int i = 0;
            int denomenator = 1;


            do
            {
                i++;
                denomenator *= i;

                rowItemValue = Cos(i * x) / denomenator;
                sum += rowItemValue;
            }
            while (Abs(rowItemValue) > epsilon);

            return sum;
        }
    }
}
