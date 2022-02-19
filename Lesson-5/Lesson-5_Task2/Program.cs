using System;
using System.IO;
using System.Linq;

namespace Lesson_5_Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string rootPath = AppDomain.CurrentDomain.BaseDirectory;
                string fileName = "startup.txt";
                string fullPath = Path.Combine(rootPath, fileName);
                string currentTime = DateTime.Now.ToLongTimeString();

                bool isFileExists = CheckFileExists(fullPath);

                Console.WriteLine($"Trying to create \"{fileName}\" file...");

                if (isFileExists)
                {
                    Console.WriteLine();
                    Console.WriteLine($"File \"{fileName}\" already exists in directory \"{rootPath}\"!");
                    Console.WriteLine();
                    Console.WriteLine($"Adding current time to a \"{fileName}\" file...");

                    File.AppendAllText(fullPath, currentTime + "\n");

                    Console.WriteLine();
                    Console.WriteLine($"Current time successfully added to a \"{fileName}\" file!");
                }

                else
                {
                    Console.WriteLine();
                    Console.WriteLine($"File \"{fileName}\" successfully created in directory {rootPath}!");
                    Console.WriteLine();
                    Console.WriteLine($"Adding current time to a \"{fileName}\" file...");

                    File.AppendAllText(fullPath, currentTime + "\n");

                    Console.WriteLine();
                    Console.WriteLine($"Current time successfully added to a \"{fileName}\" file!");
                }

                Console.ReadLine();
            }

            catch (Exception e)
            {
                Console.WriteLine("Exception caught : {0}", e.Message);
            }
        }

        /// <summary>
        /// Представляет метод проверки наличия созданного файла "startup.txt"
        /// </summary>
        /// <param name="fullPath"></param>
        /// <returns></returns>
        static bool CheckFileExists(string fullPath)
        {
            bool ifExists = File.Exists(fullPath) ? true : false;

            return ifExists;
        }
    }
}
