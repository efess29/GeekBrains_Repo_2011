using System;
using System.IO;
using System.Linq;
using System.Threading;

namespace Lesson_5_Task4
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
        /// <returns></returns>
        public static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Use recursive method");
            Console.WriteLine("2. Use non recursive method");
            Console.WriteLine("3. Exit");
            Console.Write("\r\nSelect an option: ");

            try
            {
                string currentDirectory = Environment.CurrentDirectory; // @"D:\Plugins";
                string fileNameRec = "DirectoriesList_Rec.txt";
                string fileNameNoRec = "DirectoriesList_NoRec.txt";

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("");
                        Console.WriteLine("Searching directories and files with recursive method...");
                        Thread.Sleep(1500);
                        Console.WriteLine($"Creating file \"{fileNameRec}\" ...");
                        Thread.Sleep(1000);
                        Console.WriteLine("");

                        SaveDirectoryRecursion(currentDirectory, fileNameRec);

                        Console.WriteLine($"Directories and files info successfully saved into \"{fileNameRec}\" file!");
                        Console.WriteLine("");

                        ReadFile(fileNameRec);

                        Console.ReadLine();
                        return false;
                    case "2":
                        Console.WriteLine("");
                        Console.WriteLine("Searching directories and files with non-recursive method...");
                        Thread.Sleep(1500);
                        Console.WriteLine($"Creating file \"{fileNameNoRec}\" ...");
                        Thread.Sleep(1000);
                        Console.WriteLine("");

                        SaveDirectoryNoRecursion(currentDirectory, fileNameNoRec);

                        Console.WriteLine($"Directories and files info successfully saved into \"{fileNameNoRec}\" file!");
                        Console.WriteLine("");

                        ReadFile(fileNameNoRec);

                        Console.ReadLine();

                        return false;
                    case "3":
                        return false;
                    default:
                        Console.WriteLine("");
                        Console.WriteLine("Enter valid option!");
                        Console.ReadLine();
                        return true;
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("Exception information: {0}", e.Message);
                Console.ReadLine();
            }

            return true;
        }

        /// <summary>
        /// Представляет метод поиска и записи директорий в файл (с рекурсией)
        /// </summary>
        /// <param name="path">Путь к директории</param>
        /// <param name="file">Файл для записи</param>
        static void SaveDirectoryRecursion(string path, string file)
        {
            if (File.Exists(path + "\\" + file))
            {
                Console.WriteLine($"File \"{file}\" already exists! Deleting file \"{file}\"...");
                Thread.Sleep(2000);
                File.Delete(file);
                Console.WriteLine();
                Console.WriteLine($"File \"{file}\" deleted!");
                Thread.Sleep(1000);
                Console.WriteLine();
                Console.WriteLine($"Creating new file \"{file}\" ...");
                Thread.Sleep(1500);
                Console.WriteLine();
            }

            File.AppendAllLines(file, new[] { "Directory:" });
            File.AppendAllLines(file, new[] { path });
            
            string[] dirs = Directory.EnumerateDirectories(path).ToArray();
            string[] files = Directory.GetFiles(path, "*", SearchOption.TopDirectoryOnly).Select(Path.GetFileName).ToArray();

            SaveFilesRecursion(files, file);

            for (int i = 0; i < dirs.Length; i++)
            {
                SaveDirectoryRecursion(dirs[i], file);
            }
        }

        /// <summary>
        /// Представляет метод поиска и записи файлов текущей директории в файл (с рекурсией)
        /// </summary>
        /// <param name="filesList">Список файлов директории</param>
        /// <param name="targetFile">Файл для записи</param>
        static void SaveFilesRecursion(string[] filesList, string targetFile)
        {
            File.AppendAllLines(targetFile, new [] { "Files:" });
            File.AppendAllLines(targetFile, filesList);
            File.AppendAllLines(targetFile, new[] { "" });
        }

        /// <summary>
        /// Представляет метод поиска и записи директорий и файлов в файл (с рекурсией)
        /// </summary>
        /// <param name="sourcePath">Путь к директории</param>
        /// <param name="targetFile">Файл для записи</param>
        static void SaveDirectoryNoRecursion(string sourcePath, string targetFile)
        {
            if (File.Exists(sourcePath + "\\" + targetFile))
            {
                PrintFileExistsInfo(targetFile);
            }

            File.AppendAllLines(targetFile, new[] { sourcePath });
            
            string[] entries = Directory.GetFileSystemEntries(sourcePath, "*", SearchOption.AllDirectories);
            
            File.AppendAllLines(targetFile, entries);
        }

        /// <summary>
        /// Представляет метод для чтения файла и вывода содержимого на консоль
        /// </summary>
        /// <param name="file"></param>
        static void ReadFile(string file)
        {
            string[] lines = File.ReadAllLines(file);

            foreach (string line in lines)
            {
                Thread.Sleep(100);
                Console.WriteLine(line);
            }
        }

        /// <summary>
        /// Представляет метод вывода инфо в случае, если файл для записи уже существует
        /// </summary>
        /// <param name="file">Файл для записи</param>
        static void PrintFileExistsInfo(string file)
        {
            Console.WriteLine($"File \"{file}\" already exists! Deleting file \"{file}\"...");
            Thread.Sleep(2000);
            File.Delete(file);
            Console.WriteLine();
            Console.WriteLine($"File \"{file}\" deleted!");
            Thread.Sleep(1000);
            Console.WriteLine();
            Console.WriteLine($"Creating new file \"{file}\" ...");
            Thread.Sleep(1500);
            Console.WriteLine();
        }
    }
}
