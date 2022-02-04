using System;
using System.Linq;

namespace Lesson_3_Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }

        /// <summary>
        /// Представляет метод для работы с меню
        /// </summary>
        public static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Reverse string with WHILE loop");
            Console.WriteLine("2. Reverse string with FOR loop");
            Console.WriteLine("3. Reverse string with LINQ");
            Console.WriteLine("4. Exit");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Enter a string: \t");
                        string sourceStringWhile = Console.ReadLine();

                        Console.WriteLine();
                        string targetStringWhile = ReverseStringWhile(sourceStringWhile);
                        Console.WriteLine($"Source string: {sourceStringWhile}. Reversed string: {targetStringWhile}.");
                        
                        Console.ReadLine();
                        
                        return true;
                    }
                case "2":
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Enter a string: \t");
                        string sourceStringFor = Console.ReadLine();

                        Console.WriteLine();
                        string targetStringFor = ReverseStringFor(sourceStringFor);
                        Console.WriteLine($"Source string: {sourceStringFor}. Reversed string: {targetStringFor}.");

                        Console.ReadLine();

                        return true;
                    }
                case "3":
                    Console.WriteLine("");
                    Console.WriteLine("Enter a string: \t");
                    string sourceStringLinq = Console.ReadLine();

                    Console.WriteLine();
                    string targetStringLinq = ReverseStringLinq(sourceStringLinq);
                    Console.WriteLine($"Source string: {sourceStringLinq}. Reversed string: {targetStringLinq}.");

                    Console.ReadLine();

                    return true;
                case "4":
                    return false;
                default:
                    Console.WriteLine("Enter valid option!");
                    Console.ReadLine();
                    return true;
            }
        }

        /// <summary>
        /// Представляет метод для вывода строки в обратном порядке с помощью WHILE
        /// </summary>
        public static string ReverseStringWhile(string sourceString)
        {
            string toReverseString = "";
            int length = sourceString.Length - 1;

            while (length >= 0)
            {
                toReverseString = toReverseString + sourceString[length];
                length--;
            }

            return toReverseString;
        }

        /// <summary>
        /// Представляет метод для вывода строки в обратном порядке с помощью FOR
        /// </summary>
        public static string ReverseStringFor(string sourceString)
        {
            char[] charString = sourceString.ToCharArray();
            string toReverseString = String.Empty;

            for (int i = charString.Length - 1; i >= 0 ; i--)
            {
                toReverseString += charString[i];
            }

            return toReverseString;
        }

        /// <summary>
        /// Представляет метод для вывода строки в обратном порядке с помощью Linq
        /// </summary>
        static string ReverseStringLinq(string sourceString)
        {
            string toReverseString = new string(sourceString.ToCharArray().Reverse().ToArray());

            return toReverseString;
        }

    }
}
