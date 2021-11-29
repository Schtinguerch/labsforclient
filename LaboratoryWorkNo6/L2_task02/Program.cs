using System;
using static System.Console;

namespace L2_task02
{
    class Program
    {
        struct Preparatoriest
        {
            public string Name;

            public int[] Marks;

            public Preparatoriest(string name, int[] marks)
            {
                Name = name;
                Marks = marks;
            }

            public double AverageMark()
            {
                int markSum = 0;

                for (int i = 0; i < Marks.Length; i++)
                {
                    markSum += Marks[i];
                }

                double averageMark = (double)markSum / Marks.Length;
                return averageMark;
            }

            public int LowestMark()
            {
                int lowestMark = Marks[0];

                for (int i = 0; i < Marks.Length; i++)
                {
                    if (lowestMark > Marks[i])
                    {
                        lowestMark = Marks[i];
                    }
                }

                return lowestMark;
            }

            public string Info()
            {
                var info = $"{Name}: ср. оц. = {AverageMark().ToString("N")}; все оценки: ";
                info += Marks[0].ToString();

                for (int i = 1; i < Marks.Length; i++)
                {
                    info += $", {Marks[i]}";
                }

                return info;
            }
        }

        static string[] _names = new string[]
        {
            "Михаил  ",
            "Татьяна ",
            "Алексей ",
            "Виктория",
            "Виталий ",
            "Азамат  ",
            "Любава  ",
        };

        static Random _random = new Random();

        static int MinValue = 2;
        static int MaxValue = 5 + 1; //Random.Next не включает последее число

        static void Main(string[] args)
        {
            var studends = RandomUserPreparatoriests();
            PrintPreparatoriests(studends, "Сформированный массив учащихся:");

            var goodStudents = FindAllSuccessPreparatoriests(studends);
            PrintPreparatoriests(goodStudents, "Ученики успешно сдавшие экзамены:");

            SortByAverageMark(ref goodStudents);
            PrintPreparatoriests(goodStudents, "Упорядоченный список учеников по убыванию:");
        }

        static void SortByAverageMark(ref Preparatoriest[] students)
        {
            for (int i = 0; i < students.Length; i++)
            {
                for (int j = 0; j < students.Length - 1; j++)
                {
                    if (students[j].AverageMark() < students[j + 1].AverageMark())
                    {
                        var temp = students[j + 1];
                        students[j + 1] = students[j];
                        students[j] = temp;
                    }
                }
            }
        }

        static Preparatoriest[] FindAllSuccessPreparatoriests(Preparatoriest[] allPreparatoriests)
        {
            int successPreparatoriestCount = 0;

            for (int i = 0; i < allPreparatoriests.Length; i++)
            {

                if (allPreparatoriests[i].LowestMark() > 2)
                {
                    successPreparatoriestCount++;
                }
            }

            var goodPreparatoriests = new Preparatoriest[successPreparatoriestCount];
            int index = -1;

            for (int i = 0; i < allPreparatoriests.Length; i++)
            {
                if (allPreparatoriests[i].LowestMark() > 2)
                {
                    index++;
                    goodPreparatoriests[index] = allPreparatoriests[i];
                }
            }

            return goodPreparatoriests;
        }

        static Preparatoriest[] RandomUserPreparatoriests()
        {
            Write("Введите кол-во учащихся: ");
            int studentCount = int.Parse(ReadLine());

            var students = new Preparatoriest[studentCount];

            for (int i = 0; i < studentCount; i++)
            {
                students[i] = RandomPreparatoriest(3);
            }

            return students;
        }

        static Preparatoriest RandomPreparatoriest(int markCount)
        {
            var name = _names[_random.Next(_names.Length)];
            var marks = new int[markCount];

            for (int i = 0; i < marks.Length; i++)
            {
                marks[i] = _random.Next(MinValue, MaxValue);
            }

            return new Preparatoriest(name, marks);
        }

        static void PrintPreparatoriests(Preparatoriest[] students, string message = "")
        {
            if (message != "")
            {
                WriteLine(message);
            }

            if (students.Length == 0)
            {
                WriteLine("* Массив пуст *");
                return;
            }

            WriteLine($"Всего {students.Length} учеников:");

            for (int i = 0; i < students.Length; i++)
            {
                WriteLine($"{i + 1}-й ученик: {students[i].Info()}");
            }
        }
    }
}
