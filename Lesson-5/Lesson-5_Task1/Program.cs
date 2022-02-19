using System;
using System.IO;

namespace Lesson_5_Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter some text: ");

            string sourceString = Console.ReadLine();

            if (String.IsNullOrEmpty(sourceString))
            {
                Console.WriteLine();
                Console.WriteLine("No text data entered!");
            }
            else
            {
                File.WriteAllText("text.txt", sourceString);
                Console.WriteLine("File added successfully.");
            }

            Console.ReadLine();
        }
    }
}
