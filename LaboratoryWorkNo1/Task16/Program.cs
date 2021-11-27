using System;
using static System.Console;

namespace Task16
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Чтобы покрыть доску понадобится:");
            double totalGramms = GrammsInChessField();

            WriteLine(totalGramms.ToString("N20") + " граммов зерна");
            WriteLine(InKilograms(totalGramms).ToString("N20") + " килограммов зерна");
            WriteLine(InTonns(totalGramms).ToString("N20") + " тонн зерна");

            WriteLine("\nТочность для типа double = " + double.Epsilon);
        }

        static double GrammsInChessField()
        {
            double gramsInRoot = 1d / 15d;

            for (int i = 1; i < 64; i++)
                gramsInRoot *= 2;

            return gramsInRoot;
        }

        static double InKilograms(double gramms)
        {
            return gramms / 1000d;
        }

        static double InTonns(double gramms)
        {
            return gramms / 1000000d;
        }
    }
}
