using System;
using static System.Console;


namespace Task09
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("s = " + FunctionValue().ToString());
        }

        static double FunctionValue()
        {
            int firstGrade = -1;
            int secondGrade = 5;
            int factorial = 1;

            double numerator = (double) firstGrade * secondGrade;
            double result = numerator / factorial;

            for (int i = 2; i < 7; i++)
            {
                firstGrade *= -1;
                secondGrade *= 5;
                factorial *= i;

                numerator = (double) firstGrade * secondGrade;
                result += numerator / factorial;
            }

            return result;
        }
    }
}
