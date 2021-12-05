using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharactersAndStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            Third();
            Fourth();
        }


        static void First()
        {
            Console.WriteLine("Введите число в римской нумерации: ");
            // 1. Составить программу преобразования натуральных чисел, записанных в римской нумерации, в десятичную систему счисления.
            while (true)
            {
                string input = Console.ReadLine();
                if (IsRomanNumber(input))
                    Console.WriteLine($"Число в десятичной системе счисления: {RomanToArabic(input)}");
                else
                    Console.WriteLine("Повторите ввод.");
            }
        }
        static bool IsRomanNumber(string s)
        {
            foreach (char c in s)
            {
                if (!(c == 'I' || c == 'V' || c == 'X' || c == 'L' || c == 'C' || c == 'M'))
                    return false;
            }
            return true;
        }
        static int RomanToArabic(string roman)
        {
            Dictionary<char, int> romanDigits = new Dictionary<char, int>
            {
                { 'I', 1 },
                { 'V', 5 },
                { 'X', 10 },
                { 'L', 50 },
                { 'C', 100 },
                { 'D', 500 },
                { 'M', 1000 }
            };

            int arabic = 0;

            int previous = 0;
            foreach (char romanDigit in roman.Reverse())
            {
                int current = romanDigits[romanDigit];
                if (current >= previous)
                    arabic += current;
                else
                    arabic -= current;

                previous = current;
            }

            return arabic;
        }



        static void Second()
        {
            string[] pupils =
            {
                "Рассомахин А. Б.",
                "Бондарь А. В.",
                "Толстой Л. Н.",
                "Радченко О. С.",
                "Радченко С. В.",
                "Войтенко О. Н.",
                "Райтман Н. И.",
                "Толстой А. К.",
                "Радченко А. А."
            };

            foreach (string pupil in pupils)
            {
                string surname = pupil.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0];
                int namesakes = 0;
                foreach (string otherPupil in pupils)
                {
                    string otherPupilSurname = otherPupil.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0];
                    if (surname == otherPupilSurname && pupil != otherPupil)
                        namesakes++;
                }
                Console.WriteLine($"Ученик '{pupil}' имеет {namesakes} однофамильцев.");
            }
        }



        static void Third()
        {
            Console.WriteLine("Введите двоичное число: ");
            while (true)
            {
                string input = Console.ReadLine();
                if (IsBinaryNumber(input))
                    Console.WriteLine($"Число в десятичной системе счисления: {BinaryToDecimal(input)}");
                else
                    Console.WriteLine("Повторите ввод.");
            }
        }
        static bool IsBinaryNumber(string s)
        {
            foreach (char digit in s)
            {
                if (!(digit == '0' || digit == '1'))
                    return false;
            }
            return true;
        }
        static int BinaryToDecimal(string binary)
        {
            char[] binaryDigits = binary.ToCharArray();
            Array.Reverse(binaryDigits);

            int decimalNumber = 0;
            for (int i = 0; i < binaryDigits.Length; i++)
            {
                char digit = binaryDigits[i];
                if (digit == '1')
                    decimalNumber += (int)Math.Pow(2, i);
            }
            return decimalNumber;
        }



        static void Fourth()
        {
            Console.WriteLine("Введите любую строку: ");
            while (true)
            {
                string input = Console.ReadLine();
                Console.WriteLine($"Самая длинная последовательность не-буквенных символов: {LongestNonAlphabetSequence(input)}");
            }
        }
        static bool IsAlphabetCharacter(char c)
        {
            return (c >= 'a' && c <= 'z')
                || (c >= 'A' && c <= 'Z')
                || (c >= 'а' && c <= 'я')
                || (c >= 'А' && c <= 'Я');
        }
        static int LongestNonAlphabetSequence(string s)
        {
            int maxLength = 0;
            int length = 0;
            foreach (char c in s)
            {
                if (!IsAlphabetCharacter(c))
                {
                    length++;
                } else
                {
                    if (length > maxLength)
                        maxLength = length;
                    length = 0;
                }
            }
            if (length > maxLength)
                maxLength = length;
            return maxLength;
        }
    }
}
