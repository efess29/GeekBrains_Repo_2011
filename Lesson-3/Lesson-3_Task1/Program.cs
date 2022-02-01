using System;

namespace Lesson_3_Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Specify matrix size (n * n): ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("\n");

            int[,] matrix = CreateArray(n);
            PrintArray(matrix);
            PrintDiagonal(matrix);

            Console.ReadKey();
        }

        // Представляет метод создания двумерного массива (матрицы) размером n * n
        public static int[,] CreateArray(int n)
        {
            Random randomValues = new Random();
            int[,] matrix = new int[n, n];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = randomValues.Next(1, 10);
                }
            }

            return matrix;
        }

        // Представляет метод вывода двумерного массива
        private static void PrintArray(int[,] matrix)
        {
            Console.WriteLine("Initialized matrix: ");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j] + " "}");
                }

                Console.WriteLine();
            }

            Console.WriteLine("\n");
        }

        // Представляет метод вывода элементов двумерного массива по диагонали (главная диагональ)
        private static void PrintDiagonal(int[,] matrix)
        {
            Console.WriteLine("Diagonal elements: ");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.Write($"{matrix[i, i] + " "}");
            }
        }

    }
}
