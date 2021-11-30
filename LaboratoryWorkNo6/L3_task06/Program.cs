using System;
using static System.Console;
using static System.Math;

namespace L3_task06
{

    class Program
    {
        struct AnswerTable
        {
            public Answers[] AllAnswers;
            
            public AnswerTable(Answers[] allAnswers)
            {
                AllAnswers = allAnswers;
            }

            public string AllAnswersInfo()
            {
                var info = "\n| Животное |  Черта х.  |    Вещь    |\n";
                info      += "======================================\n";

                for (int i = 0;i < AllAnswers.Length; i++)
                {
                    info += $"|{AllAnswers[i].JapanAndAnimal}|{AllAnswers[i].JapanAndPersonCharacter}|{AllAnswers[i].JapanAndThing}|\n";
                }

                info      += "======================================\n";
                return info;
            }

            public string[] GetMostPopularAnimalsAndPercentage(int count)
            {
                var allAnimals = new string[AllAnswers.Length];

                for (int i = 0; i < AllAnswers.Length; i++)
                {
                    allAnimals[i] = AllAnswers[i].JapanAndAnimal;
                }

                var animalsCounts = new int[7];

                for (int i = 0; i < allAnimals.Length; i++)
                {
                    for (int j = 0; j < animalsCounts.Length; j++)
                    {
                        if (allAnimals[i] == _animalAnswers[j])
                        {
                            animalsCounts[j]++;
                        }
                    }
                }

                Array.Sort(animalsCounts, _animalAnswers);
                Array.Sort(animalsCounts);

                var mostPopularAnimals = new string[count];
                for (int i = 0; i < mostPopularAnimals.Length; i++)
                {
                    double percentage = (double) animalsCounts[i] / AllAnswers.Length * 100d;
                    mostPopularAnimals[mostPopularAnimals.Length - 1 - i] = $" {_animalAnswers[i]}, {percentage:N1}% ";
                }

                return mostPopularAnimals;
            }

            public string[] GetMostPopularCharactersAndPercentage(int count)
            {
                var allCharacters = new string[AllAnswers.Length];

                for (int i = 0; i < AllAnswers.Length; i++)
                {
                    allCharacters[i] = AllAnswers[i].JapanAndPersonCharacter;
                }

                var charactersCounts = new int[7];

                for (int i = 0; i < allCharacters.Length; i++)
                {
                    for (int j = 0; j < charactersCounts.Length; j++)
                    {
                        if (allCharacters[i] == _characterAnswers[j])
                        {
                            charactersCounts[j]++;
                        }
                    }
                }

                Array.Sort(charactersCounts, _characterAnswers);
                Array.Sort(charactersCounts);

                var mostPopularCharacters = new string[count];
                for (int i = 0; i < mostPopularCharacters.Length; i++)
                {
                    double percentage = (double)charactersCounts[i] / AllAnswers.Length * 100d;
                    mostPopularCharacters[mostPopularCharacters.Length - 1 - i] = $" {_characterAnswers[i]}, {percentage:N1}% ";
                }

                return mostPopularCharacters;
            }

            public string[] GetMostPopularThingsAndPercentage(int count)
            {
                var allThings = new string[AllAnswers.Length];

                for (int i = 0; i < AllAnswers.Length; i++)
                {
                    allThings[i] = AllAnswers[i].JapanAndThing;
                }

                var thingsCounts = new int[7];

                for (int i = 0; i < allThings.Length; i++)
                {
                    for (int j = 0; j < thingsCounts.Length; j++)
                    {
                        if (allThings[i] == _thingAnwers[j])
                        {
                            thingsCounts[j]++;
                        }
                    }
                }

                Array.Sort(thingsCounts, _thingAnwers);
                Array.Sort(thingsCounts);

                var mostPopularThings = new string[count];
                for (int i = 0; i < mostPopularThings.Length; i++)
                {
                    double percentage = (double)thingsCounts[i] / AllAnswers.Length * 100d;
                    mostPopularThings[mostPopularThings.Length - 1 - i] = $" {_thingAnwers[i]}, {percentage:N1}% ";
                }

                return mostPopularThings;
            }
        }

        struct Answers
        {
            public string JapanAndAnimal;
            public string JapanAndPersonCharacter;
            public string JapanAndThing;

            public Answers(string japanAndAnimal, string japanAndPersonCharacter, string japanAndThing)
            {
                JapanAndAnimal = japanAndAnimal;
                JapanAndPersonCharacter = japanAndPersonCharacter;
                JapanAndThing = japanAndThing;
            }
        }

        static string[] _animalAnswers =
        {
            " Журавль  ",
            " Выдра    ",
            " Шиба Ину ",
            " Лисица   ",
            " Заяц     ",
            " Барсук   ",
            " -------- "
        };

        static string[] _characterAnswers =
        {
            " Трудолюбие ",
            " Уважение   ",
            " Честность  ",
            " Синтоизм   ",
            " Традиции   ",
            " Скромность ",
            " ---------- "
        };

        static string[] _thingAnwers =
        {
            " Катана     ",
            " Панасоник  ",
            " Рикша      ",
            " Магнитофон ",
            " Сюрикен    ",
            " Манга      ",
            " ---------- "
        };

        static Random _random = new Random();
        static int MaxIndex = _characterAnswers.Length;

        static void Main(string[] args)
        {
            var table = new AnswerTable(RandomAnswers(20));

            WriteLine("Все сгенерированные ответы:");
            WriteLine(table.AllAnswersInfo());

            WriteLine("5 самых популярных ответов:");
            PrintMostPopularAnswers(
                table.GetMostPopularAnimalsAndPercentage(5),
                table.GetMostPopularCharactersAndPercentage(5),
                table.GetMostPopularThingsAndPercentage(5));
        }

        static Answers[] RandomAnswers(int count)
        {
            var answers = new Answers[count];

            for (int i = 0; i < count; i++)
            {
                answers[i] = new Answers(
                    _animalAnswers[_random.Next(MaxIndex)],
                    _characterAnswers[_random.Next(MaxIndex)],
                    _thingAnwers[_random.Next(MaxIndex)]);
            }

            return answers;
        }

        static void PrintMostPopularAnswers(string[] animals, string[] characters, string[] things)
        {
            var length = animals.Length;

            var info = "| СП животные           | СП черты хар.         | СП вещи               |\n";
            info    += "=========================================================================\n";

            for (int i = 0; i < length; i++)
            {
                info += $"|{animals[i]}\t|{characters[i]}\t|{things[i]}\t|\n";
            }

            info    += "=========================================================================\n";
            WriteLine($"\n{info}\n");
        }
    }
}
