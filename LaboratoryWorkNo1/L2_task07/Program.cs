using System;
using static System.Console;

namespace L2_task07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ShowSportsmenStats(10, 10);
        }

        static void ShowSportsmenStats(double baseRunRange, double upPercentage)
        {
            double days = 1;
            double currentDayRange = baseRunRange;
            double runnedRange = baseRunRange;

            bool aSolved = false, bSolved = false, cSolved = false;

            while (!aSolved || !bSolved || !cSolved)
            {
                days++;
                currentDayRange = currentDayRange * (1 + upPercentage / 100d);
                runnedRange += currentDayRange;

                if (days == 7 && !aSolved)
                {
                    WriteLine("a) Суммарный путь за 7 дней = " + runnedRange.ToString() + " км.");
                    aSolved = true;
                }

                if (runnedRange >= 100 && !bSolved)
                {
                    WriteLine("б) 100 км. спортсмен пробежал за " + days.ToString() + " дней");
                    bSolved = true;
                }

                if (currentDayRange > 20 && !cSolved)
                {
                    WriteLine("в) Больше 20 км. в день спортсмен будет пробегать через " + days + " дней");
                    cSolved = true;
                }
            }
        }
    }
}
