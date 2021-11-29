using System;
using static System.Console;

namespace L2_task03
{
    class Program
    {
        struct JumpSportsmen
        {
            public string Surname;

            public int[] AllJumpResults;

            public JumpSportsmen(string surname, int[] allJumps)
            {
                Surname = surname;
                AllJumpResults = allJumps;
            }

            public int BestResult()
            {
                int bestResult = AllJumpResults[0];

                for (int i = 0; i < AllJumpResults.Length; i++)
                {
                    if (AllJumpResults[i] > bestResult)
                    {
                        bestResult = AllJumpResults[i];
                    }
                }

                return bestResult;
            }

            public string Info()
            {
                var info = $"{Surname}: л. р. = {BestResult()}м; Все прыжки: ";
                info += AllJumpResults[0];

                for (int i = 1; i < AllJumpResults.Length; i++)
                {
                    info += $", {AllJumpResults[i]}";
                }

                return info;
            }
        }

        static string[] _surnames = new string[]
        {
            "Мордвинов",
            "Банникова",
            "Быстрых  ",
            "Бородач  ",
            "Тимошенко",
            "Мельников",
            "Тимофеева",
        };

        static Random _random = new Random();

        static int MinValue = 10;
        static int MaxValue = 25;

        static void Main(string[] args)
        {
            var sportsmens = RandomUserJumpSportsmens();
            PrintJumpSportsmens(sportsmens, "Изначальный список спортсменов:");

            SortByBestJump(ref sportsmens);
            PrintJumpSportsmens(sportsmens, "\nПротокол соревнований: Таблица лидеров:");
        }

        static void SortByBestJump(ref JumpSportsmen[] sportsmens)
        {
            for (int i = 0; i < sportsmens.Length; i++)
            {
                for (int j = 0; j < sportsmens.Length - 1; j++)
                {
                    if (sportsmens[j].BestResult() < sportsmens[j + 1].BestResult())
                    {
                        var temp = sportsmens[j + 1];
                        sportsmens[j + 1] = sportsmens[j];
                        sportsmens[j] = temp;
                    }
                }
            }
        }

        static JumpSportsmen[] RandomUserJumpSportsmens()
        {
            Write("Введите кол-во спортсменов: ");
            int studentCount = int.Parse(ReadLine());

            var sportsmens = new JumpSportsmen[studentCount];

            for (int i = 0; i < studentCount; i++)
            {
                sportsmens[i] = RandomJumpSportsmen(3);
            }

            return sportsmens;
        }

        static JumpSportsmen RandomJumpSportsmen(int jumpCount)
        {
            var name = _surnames[_random.Next(_surnames.Length)];
            var jumps = new int[jumpCount];

            for (int i = 0; i < jumps.Length; i++)
            {
                jumps[i] = _random.Next(MinValue, MaxValue);
            }

            return new JumpSportsmen(name, jumps);
        }

        static void PrintJumpSportsmens(JumpSportsmen[] sportsmens, string message = "")
        {
            if (message != "")
            {
                WriteLine(message);
            }

            if (sportsmens.Length == 0)
            {
                WriteLine("* Массив пуст *");
                return;
            }

            WriteLine($"Всего {sportsmens.Length} спортсменов:");

            for (int i = 0; i < sportsmens.Length; i++)
            {
                WriteLine($"{i + 1}-й спортсмен: {sportsmens[i].Info()}");
            }
        }
    }
}
