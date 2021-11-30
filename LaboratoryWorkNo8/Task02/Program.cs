using System;
using static System.Console;

namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Введите текст, с которым будет производиться работа:");
            var text = ReadLine();

            var encodedText = ReverseWordSpelling(text);

            WriteLine("\nЗашифрованный текст:");
            WriteLine(encodedText);

            var decodedText = ReverseWordSpelling(encodedText); ;

            WriteLine("\nРасшифрованный текст:");
            WriteLine(decodedText);
        }

        static bool IsWordCharacter(char character)
        {
            var isEnglishCharacter = 
                (character >= 'a' && character <= 'z') 
                || (character >= 'A' && character <= 'Z');

            var isRussianCharacter =
                (character >= 'а' && character <= 'я')
                || (character >= 'А' && character <= 'Я')
                || (character == 'ё') || (character == 'Ё');

            return isEnglishCharacter || isRussianCharacter;
        }

        static string ReverseWordSpelling(string text)
        {
            var characters = text.ToCharArray();

            int startIndex = 0;
            int endIndex = 0;

            for (int i = 0; i < characters.Length; i++)
            {
                if (!IsWordCharacter(characters[i]))
                {
                    endIndex = i;
                    int length = endIndex - startIndex;

                    for (int k = 0; k < length / 2; k++)
                    {
                        char temp = characters[startIndex + k];
                        characters[startIndex + k] = characters[endIndex - 1 - k];
                        characters[endIndex - 1 - k] = temp;
                    }

                    startIndex = endIndex + 1;
                }
            } 

            return new string(characters);
        }
    }
}
