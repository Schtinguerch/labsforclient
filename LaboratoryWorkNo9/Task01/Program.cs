using System;
using System.Diagnostics;
using System.IO;

using static System.Console;

namespace Task01
{
    class Program
    {
        class StudentGroup
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

        class Student
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

        class MasterDegreeStudent : Student
        {
            public string GraduationWorkName;

            public MasterDegreeStudent(string name, int[] marks, string graduationWorkName) : base(name, marks)
            {
                GraduationWorkName = graduationWorkName;
            }

            public string Info()
            {
                return base.Info() + $"; Вып. работа: {GraduationWorkName}";
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

        static string[] _works = new string[]
        {
            "Новые методы ввода текста",
            "Ускорение обучения школьников",
            "Сравнительный анализ раскладок",
            "Новое решение тепловых задач",
            "Язык программирования фотонных ВМ",
        };

        static Random _random = new Random();

        static int MinValue = 1;
        static int MaxValue = 5 + 1; //Random.Next не включает последее число

        static void Main(string[] args)
        {
            var studentGroups = ReadGroupsFromFile("input.txt");
            PrintGroups(studentGroups, "\n\nГруппы, извлечённые из файла input.txt:");

            SortByAverageMark(ref studentGroups);

            PrintGroups(studentGroups, "\n\nГруппы, упорядоченные по успеваемости");
            WriteGroupsToFile(studentGroups, "output.txt");

            Process.Start("input.txt");
            Process.Start("output.txt");
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

        static StudentGroup[] ReadGroupsFromFile(string filename)
        {
            var reader = new StreamReader(filename);
            var line = reader.ReadLine();

            int groupCount = int.Parse(line.Split('=')[1]);
            var groups = new StudentGroup[groupCount];
            int index = -1;

            while ((line = reader.ReadLine()) != null)
            {
                if (line == "")
                {
                    index++;
                    continue;
                }

                if (line.Contains("group="))
                {
                    var name = line.Split('=')[1];
                    line = reader.ReadLine();

                    int studentCount = int.Parse(line.Split('=')[1]);
                    var students = new Student[studentCount];

                    for (int i = 0; i < studentCount; i++)
                    {
                        line = reader.ReadLine();

                        var info = line.Split(' ');
                        var marks = new int[info.Length - 1];

                        for (int j = 0; j < marks.Length; j++)
                        {
                            marks[j] = int.Parse(info[j + 1]);
                        }

                        students[i] = new Student(info[0], marks);
                    }

                    groups[index] = new StudentGroup(name, students);
                }
            }

            reader.Close();
            return groups;
        }

        static void WriteGroupsToFile(StudentGroup[] groups, string filename)
        {
            //false - вместо добавления новых данных в старый файл, файл будет перезаписан

            var writer = new StreamWriter(filename, false);
            writer.WriteLine($"count={groups.Length}\n");
            
            for (int i = 0; i < groups.Length; i++)
            {
                writer.WriteLine($"group={groups[i].CodeName}");
                writer.WriteLine($"count={groups[i].Students.Length}");
                
                for (int j = 0; j < groups[i].Students.Length; j++)
                {
                    writer.Write(groups[i].Students[j].Name);

                    for (int k = 0; k < groups[i].Students[j].Marks.Length; k++)
                    {
                        writer.Write($" {groups[i].Students[j].Marks[k]}");
                    }

                    writer.Write('\n');
                }

                

                if (i != groups.Length - 1)
                {
                    writer.Write('\n');
                }
            }

            writer.Close();
        }
    }
}
