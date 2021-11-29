using System;
using static System.Console;

namespace L1_task01
{
    class Program
    {
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

                double averageMark = (double) markSum / Marks.Length;
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
            var studends = RandomUserStudents();
            PrintStudents(studends, "Сформированный массив студентов:");

            var goodStudents = FindAllGoodStudents(studends);
            PrintStudents(goodStudents, "Студенты, чей средный балл не менее 4:");

            SortByAverageMark(ref goodStudents);
            PrintStudents(goodStudents, "Упорядоченный список студентов по убыванию:");
        }

        static void SortByAverageMark(ref Student[] students)
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

        static Student[] FindAllGoodStudents(Student[] allStudents)
        {
            int goodStudentCount = 0;

            for (int i = 0; i < allStudents.Length; i++)
            {
                if (allStudents[i].AverageMark() >= 4)
                {
                    goodStudentCount++;
                }
            }

            var goodStudents = new Student[goodStudentCount];
            int index = -1;

            for (int i= 0; i< allStudents.Length; i++)
            {
                if (allStudents[i].AverageMark() >= 4)
                {
                    index++;
                    goodStudents[index] = allStudents[i];
                }
            }

            return goodStudents;
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

        static void PrintStudents(Student[] students, string message = "")
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

            WriteLine($"Всего {students.Length} студентов:");

            for (int i = 0; i < students.Length; i++)
            {
                WriteLine($"{i + 1}-й студент: {students[i].Info()}");
            }
        }
    }
}
