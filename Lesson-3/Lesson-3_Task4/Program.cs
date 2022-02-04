using System;
using static System.Console;

namespace Lesson_3_Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintHeader();
            PrintMainField();

            ReadLine();
        }

        /// <summary>
        /// Представляет метод вывода заголовка по оси X
        /// </summary>
        static void PrintHeader()
        {
            ForegroundColor = ConsoleColor.DarkYellow;
            Write("[ ]");
            for (int i = 1; i < 11; i++)
                Write("[" + i + "]");
        }

        /// <summary>
        /// Представляет метод вывода основного игрового поля
        /// </summary>
        static void PrintMainField()
        {
            WriteLine();

            char row = 'A';
            try
            {
                for (int y = 1; y < 11; y++)
                {
                    for (int x = 1; x < 11; x++)
                    {
                        bool keepGoing = true;

                        if (x == 1)
                        {
                            ForegroundColor = ConsoleColor.DarkYellow;
                            Write("[" + row + "]");
                            row++;
                        }

                        if (
                            (y == 4 && x == 3) ||
                            (y == 4 && x == 2) ||
                            (y == 4 && x == 1) ||
                            (y == 2 && x == 7) ||
                            (y == 1 && x == 7) ||
                            (y == 3 && x == 7) ||
                            (y == 9 && x == 5) ||
                            (y == 9 && x == 6) ||
                            (y == 9 && x == 7) ||
                            (y == 9 && x == 8) ||
                            (y == 6 && x == 6) ||
                            (y == 5 && x == 10) ||
                            (y == 6 && x == 10)
                            )
                        {
                            ForegroundColor = ConsoleColor.DarkGreen;
                            Write("[X]");
                            keepGoing = false;
                        }

                        if (keepGoing)
                        {
                            ForegroundColor = ConsoleColor.Blue;
                            Write("[O]");
                        }
                    }

                    WriteLine();
                }

            }
            catch (Exception e)
            {
                string error = e.Message.ToString();
            }
        }
    }
}
