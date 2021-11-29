using System;
using static System.Console;

namespace L3_task01
{
    class Program
    {
        struct StudentGroup
        {
            public string CodeName;

            public Student[] Students;

            public StudentGroup(string name, Student[] students)
            {
                CodeName = name;
                Students = students;
            }

            public double AverageMark()
            {
                double markSum = 0;

                for (int i = 0; i < Students.Length; i++)
                {
                    markSum += Students[i].AverageMark();
                }

                double average = markSum / Students.Length;
                return average;
            }

            public string Info()
            {
                var info = $"Группа {CodeName}: Ср. балл = {AverageMark()}\n";

                for (int i = 0; i < Students.Length; i++)
                {
                    info += $"Студент №{i + 1}: {Students[i].Info()}\n";
                }

                return info;
            }
        }

        struct Student
        {
            public string Name;

            public int[] Marks;

            public Student(string name, int[] marks)
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

            public string Info()
            {
                var info = $"{Name}: ср. оц. = {AverageMark()}; все оценки: ";
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

        static int MinValue = 1;
        static int MaxValue = 5 + 1; //Random.Next не включает последее число

        static void Main(string[] args)
        {
            var studentGroups = UserGroups(3);

            SortByAverageMark(ref studentGroups);
            PrintGroups(studentGroups, "\n\nГруппы, упорядоченные по успеваемости");
        }

        static void SortByAverageMark(ref StudentGroup[] groups)
        {
            for (int i = 0; i < groups.Length; i++)
            {
                for (int j = 0; j < groups.Length - 1; j++)
                {
                    if (groups[j].AverageMark() < groups[j + 1].AverageMark())
                    {
                        var temp = groups[j + 1];
                        groups[j + 1] = groups[j];
                        groups[j] = temp;
                    }
                }
            }
        }

        static StudentGroup[] UserGroups(int count)
        {
            var groups = new StudentGroup[count];

            for (int i = 0; i < count; i++)
            {
                WriteLine($"Группа №{i + 1}:");

                Write($"Название группы: ");
                var groupName = ReadLine();
                var students = RandomUserStudents();

                groups[i] = new StudentGroup(groupName, students);
            }

            return groups;
        }

        static Student[] RandomUserStudents()
        {
            Write("Введите кол-во студентов: ");
            int studentCount = int.Parse(ReadLine());

            var students = new Student[studentCount];

            for (int i = 0; i < studentCount; i++)
            {
                students[i] = RandomStudent();
            }

            return students;
        }

        static Student RandomStudent()
        {
            var name = _names[_random.Next(_names.Length)];
            var marks = new int[4];

            for (int i = 0; i < marks.Length; i++)
            {
                marks[i] = _random.Next(MinValue, MaxValue);
            }

            return new Student(name, marks);
        }

        static void PrintGroups(StudentGroup[] groups, string message = "")
        {
            if (message != "")
            {
                WriteLine(message);
            }

            if (groups.Length == 0)
            {
                WriteLine("* Массив пуст *");
                return;
            }

            for (int i = 0; i < groups.Length; i++)
            {
                WriteLine($"{i + 1}: {groups[i].Info()}");
            }
        }
    }
}
