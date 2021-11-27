using System;
using static System.Console;

namespace L2_task02
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Наибольшее значение сомножителя для L = 30000:   " + GetMaxSubmultipler(30000).ToString());
        }

        static int GetMaxSubmultipler(int L)
        {
            int result = 1, multiper = 1, previousResult = 1;

            while (result < L)
            {
                previousResult = result;
                multiper += 3;

                result *= multiper;
            }

            return previousResult;
        }
    }
}
