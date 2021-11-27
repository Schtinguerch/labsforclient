using System;
using static System.Console;

namespace Task15
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("5-й член последовательности: " + FindInOrder(5));
        }

        static string FindInOrder(int n)
        {
            if (n == 1)
                return "1/1";

            int currentNum = 2, currentDen = 1;
            int previousNum = 1, previousDen = 1;

            for (int i = 3; i <= n; i++)
            {
                int newNumerator = currentNum + previousNum;
                int newDenometator = currentDen + previousDen;

                previousNum = currentNum;
                previousDen = currentDen;

                currentNum = newNumerator;
                currentDen = newDenometator;
            }

            return currentNum.ToString() + '/' + currentDen.ToString();
        }
    }
}
