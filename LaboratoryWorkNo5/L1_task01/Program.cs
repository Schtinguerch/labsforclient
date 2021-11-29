using System;
using static System.Console;

namespace L1_task01
{
    class Program
    {
        static void Main(string[] args)
        {
            int teamCount = 5;

            WriteLine("Отобразить команду из 5-ти человек можно следующее кол-во раз:");
            WriteLine($"Из 8-ти кандидатов: {CombinationCount(teamCount, 8)}");
            WriteLine($"Из 10-ти кандидатов: {CombinationCount(teamCount, 10)}");
            WriteLine($"Из 11-ти кандидатов: {CombinationCount(teamCount, 11)}");
        }

        static int CombinationCount(int k, int n)
        {
            return Factorial(n) / (Factorial(k) * Factorial(n - k));
        }

        static int Factorial(int n)
        {
            int factorial = 1;

            for (int i = 2; i <= n; i++)
                factorial *= i;

            return factorial;
        }
    }
}
