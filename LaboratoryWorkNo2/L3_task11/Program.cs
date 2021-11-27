using System;
using static System.Console;

namespace L3_task11
{
    class Program
    {
        static void Main(string[] args)
        {
            GetNotCatchStudents();
        }

        static void GetNotCatchStudents()
        {
            Write("Введите кол-во студентов: ");
            int studentCount = int.Parse(ReadLine());

            int notCatchStudentCount = 0;
            int markSum = 0;

            for (int i = 0; i < studentCount; i++)
            {
                WriteLine($"Студент #{i + 1}:");

                Write("Оценка за 1-й экзамен: ");
                int mark1 = int.Parse(ReadLine());

                Write("Оценка за 2-й экзамен: ");
                int mark2 = int.Parse(ReadLine());

                Write("Оценка за 3-й экзамен: ");
                int mark3 = int.Parse(ReadLine());

                Write("Оценка за 4-й экзамен: ");
                int mark4 = int.Parse(ReadLine());

                bool isNotCatch = IsNotCatch(mark1, mark2, mark3, mark4);
                WriteLine($"Данный студент {IntoRussian(isNotCatch)} за программой");

                markSum += mark1 + mark2 + mark3 + mark4;

                if (isNotCatch)
                    notCatchStudentCount++;
            }

            double averageMark = (double) markSum / studentCount / 4d;

            WriteLine($"Кол-во неуспевающих студентов = {notCatchStudentCount}");
            WriteLine($"Средний балл группы = {averageMark}");
        }

        static bool IsNotCatch(int mark1, int mark2, int mark3, int mark4)
        {
            return mark1 <= 2 || mark2 <= 2 || mark3 <= 2 || mark4 <= 2;
        }

        static string IntoRussian(bool isNotCatch)
        {
            if (isNotCatch)
                return "НЕ успевает";
            else
                return "успевает";
        }
    }
}
