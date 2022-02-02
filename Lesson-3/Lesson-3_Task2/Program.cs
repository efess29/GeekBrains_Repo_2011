using System;

namespace Lesson_3_Task2
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

        // Представляет метод для работы с меню
        public static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Use existing 2d array");
            Console.WriteLine("2. Fill 2d array with specified values");
            Console.WriteLine("3. Exit");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    {
                        Console.WriteLine();
                        PrintDefaultArray();
                        return true;
                    }
                case "2":
                    {
                        string[,] phonebook = GenerateArray();
                        PrintGeneratedArray(phonebook);
                        return true;
                    }
                case "3":
                    return false;
                default:
                    return true;
            }
        }

        // Представляет метод вывода заранее созданного и наполненного массива
        public static void PrintDefaultArray()
        {
            string[,] defaultPhonebook = new string[5, 2]
            {
                { "Andrew", "8-800-555-34-35" },
                { "Peter", "8-495-000-12-32" },
                { "Alex", "9-800-323-21-78" },
                { "Oleg", "7-456-453-00-12" },
                { "Ivan", "8-800-766-87-32" }
            };

            for (int i = 0; i < defaultPhonebook.GetLength(0); i++)
            {
                for (int j = 0; j < defaultPhonebook.GetLength(1); j++)
                {
                    Console.Write(defaultPhonebook[i, j] + "\t");
                }

                Console.WriteLine();
            }

            Console.ReadLine();
        }

        // Представляет метод создания массива размеров 5 * 2 путем ввода значений в консоли
        public static string[,] GenerateArray()
        {
            string[,] customPhonebook = new string[5, 2];

            for (int i = 0; i < customPhonebook.GetLength(0); i++)
            {
                for (int j = 0; j < customPhonebook.GetLength(1); j++)
                {
                    Console.WriteLine($"Enter contact name: {i}, contact info: {j}");
                    customPhonebook[i, j] = Console.ReadLine();
                }
            }

            Console.WriteLine();

            return customPhonebook;
        }

        // Представляет метод вывода созданного вручную массива
        public static void PrintGeneratedArray(string[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write($"{arr[i, j] + " "}");
                }

                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
