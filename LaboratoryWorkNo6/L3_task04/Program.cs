using System;
using static System.Console;

namespace L3_task04
{
    class Program
    {
        struct MatchResult
        {
            public string FirstTeam;
            public string SecondTeam;

            public int FirstTeamGoals;
            public int SecondTeamGoals;

            public MatchResult(string firstTeam, string secondTeam, int firstTeamGoals, int secondTeamGoals)
            {
                FirstTeam = firstTeam;
                SecondTeam = secondTeam;

                FirstTeamGoals = firstTeamGoals;
                SecondTeamGoals = secondTeamGoals;
            }

            public string Info()
            {
                return $"{FirstTeam}| {FirstTeamGoals} : {SecondTeamGoals} |{SecondTeam}";
            }
        }

        struct FootballTeam
        {
            public string Name;

            public int EarnedPoints;
            public int GoalsDifference;

            public FootballTeam(string name)
            {
                Name = name;
                EarnedPoints = 0;
                GoalsDifference = 0;
            }

            public bool IsStronger(FootballTeam otherTeam)
            {
                if (EarnedPoints == otherTeam.EarnedPoints)
                {
                    return GoalsDifference > otherTeam.GoalsDifference;
                }

                else
                {
                    return EarnedPoints > otherTeam.EarnedPoints;
                }
            }

            public string Info()
            {
                return $"{Name}: Очков = {EarnedPoints}; Г-П = {GoalsDifference}";
            }
        }

        static Random _random = new Random();
        static int MinGoals = 0;
        static int MaxGoals = 10;

        static string[] _teamNames = new string[]
        {
            "Manchester United",
            "Real Madrid      ",
            "Barcelona        ",
            "Uvensus          ",
            "Arsenal          ",
        };

        static void Main(string[] args)
        {
            var teams = DeclareAllTeams();
            CreateRandomTournament(ref teams);

            SortByEarnedPoints(ref teams);
            PrintTeams(teams, "\nИтоговая таблица:");
        }

        static void SortByEarnedPoints(ref FootballTeam[] teams)
        {
            for (int i = 0; i < teams.Length; i++)
            {
                for (int j = 0; j < teams.Length - 1; j++)
                {
                    if (!teams[j].IsStronger(teams[j + 1]))
                    {
                        var temp = teams[j + 1];
                        teams[j + 1] = teams[j];
                        teams[j] = temp;
                    }
                }
            }
        }

        static void CreateRandomTournament(ref FootballTeam[] teams)
        {
            const int matchCount = 16;

            for (int i = 0; i < matchCount; i++)
            {
                int firstTeamGoals = _random.Next(MinGoals, MaxGoals);
                int secondTeamGoals = _random.Next(MinGoals, MaxGoals);

                int firstTeam = _random.Next(_teamNames.Length);
                int secondTeam = _random.Next(_teamNames.Length);

                while (secondTeam == firstTeam)
                {
                    secondTeam = _random.Next(_teamNames.Length);
                }

                WriteLine(new MatchResult(
                    _teamNames[firstTeam],
                    _teamNames[secondTeam],
                    firstTeamGoals,
                    secondTeamGoals).Info());

                teams[firstTeam].GoalsDifference += firstTeamGoals - secondTeamGoals;
                teams[secondTeam].GoalsDifference += secondTeamGoals - firstTeamGoals;

                if (firstTeamGoals > secondTeamGoals)
                {
                    teams[firstTeam].EarnedPoints += 3;
                }

                else if (secondTeamGoals > firstTeamGoals)
                {
                    teams[secondTeam].EarnedPoints += 3;
                }

                else
                {
                    teams[firstTeam].EarnedPoints += 1;
                    teams[secondTeam].EarnedPoints += 1;
                }
            }
        }

        static FootballTeam[] DeclareAllTeams()
        {
            var teams = new FootballTeam[_teamNames.Length];

            for (int i = 0; i < teams.Length; i++)
            {
                teams[i] = new FootballTeam(_teamNames[i]);
            }

            return teams;
        }

        static void PrintTeams(FootballTeam[] teams, string message = "")
        {
            if (message != "")
            {
                WriteLine(message);
            }

            if (teams.Length == 0)
            {
                WriteLine("* Массив пуст *");
            }

            for (int i = 0; i< teams.Length; i++)
            {
                WriteLine($"{i + 1}-е место: " + teams[i].Info());
            }
        }
    }
}
