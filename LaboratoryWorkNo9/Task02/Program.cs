using System;
using System.Diagnostics;
using System.IO;

using static System.Console;

namespace Task02
{
    class Program
    {
        class MatchResult
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
                return $" {FirstTeam}\t| {FirstTeamGoals} : {SecondTeamGoals} |\t{SecondTeam} ";
            }
        }

        class Team
        {
            public string Name;
            public string CodeName;
        }

        class FootballTeam : Team
        {
            public int EarnedPoints;
            public int GoalsDifference;

            public FootballTeam(string name, string codeName)
            {
                Name = name;
                CodeName = codeName;

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
                return $"{Name} ({CodeName}): Очков = {EarnedPoints}; Г-П = {GoalsDifference}";
            }
        }

        static Random _random = new Random();
        static int MinGoals = 0;
        static int MaxGoals = 10;

        static string[] _teamNames = new string[]
        {
            "Manchester",
            "Real Madrid",
            "Barcelona",
            "Uvensus",
            "Arsenal",
        };

        static void Main(string[] args)
        {
            var teams = ReadNewMatchFromFile("input.txt");

            SortByEarnedPoints(ref teams);

            PrintTeams(teams, "\nИтоговая таблица:");
            WriteTeams(teams, "output.txt");

            Process.Start("input.txt");
            Process.Start("output.txt");
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
                teams[i] = new FootballTeam(_teamNames[i], _random.Next(0, 100).ToString("0000"));
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

            for (int i = 0; i < teams.Length; i++)
            {
                WriteLine($"{i + 1}-е место: " + teams[i].Info());
            }
        }

        static FootballTeam[] ReadNewMatchFromFile(string filename)
        {
            var reader = new StreamReader(filename);
            var line = reader.ReadLine();

            int teamCount = int.Parse(line.Split('=')[1]);
            var teams = new FootballTeam[teamCount];

            reader.ReadLine();

            for (int i = 0; i < teamCount; i++)
            {
                line = reader.ReadLine();
                var tokens = line.Split('=');

                var name = tokens[0];
                var code = tokens[1];

                teams[i] = new FootballTeam(name, code);
            }

            reader.ReadLine();
            line = reader.ReadLine();

            int matchCount = int.Parse(line.Split('=')[1]);

            reader.ReadLine();

            for (int i = 0; i < matchCount; i++)
            {
                line = reader.ReadLine();
                var tokens = line.Split('|');
                var goals = tokens[1].Split(':');

                int firstTeamGoals = int.Parse(goals[0].Trim());
                int secondTeamGoals = int.Parse(goals[1].Trim());

                int firstTeam = IndexByName(teams, tokens[0].Trim());
                int secondTeam = IndexByName(teams, tokens[2].Trim());

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

            return teams;
        }

        static void WriteTeams(FootballTeam[] teams, string fileName)
        {
            var writer = new StreamWriter(fileName, false);

            if (teams.Length == 0)
            {
                writer.WriteLine("* Массив пуст *");
            }

            for (int i = 0; i < teams.Length; i++)
            {
                writer.WriteLine($"{i + 1}-е место: " + teams[i].Info());
            }

            writer.Close();
        }

        static int IndexByName(FootballTeam[] teams, string name)
        {
            for (int i = 0; i < teams.Length; i++)
            {
                if (name == teams[i].Name)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}