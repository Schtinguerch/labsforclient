using System;
using static System.Console;

namespace Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Введите текст, с которым будет производиться работа: ");
            var text = ReadLine();

            WriteLine("Текст, поделённый на подстроки");
            SplitIntoSubstrings(text, 10);
        }

        static void SplitIntoSubstrings(string text, int maxLength)
        {
            var allWords = text.Split(' ');
            int length = 0;

            for (int i = 0; i < allWords.Length; i++)
            {
                if (length + allWords[i].Length < maxLength)
                {
                    if (length > 0)
                    {
                        Write(' ');
                        
                    }

                    length += allWords[i].Length;
                    Write(allWords[i]);
                }

                else
                {
                    Write('\n');
                    length = 0;
                }
            }
        }
    }
}
