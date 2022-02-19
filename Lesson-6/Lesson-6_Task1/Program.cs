using System;
using System.Diagnostics;
using System.Linq;

namespace Lesson_6_Task1
{
    class Program
    {
        private static string st = "\t\t ";
        private static string xst = "\t\t ";
        private static string name = "Name";
        private static string id = "ID";
        private static string memory = "Memory";

        static void Main(string[] args)
        {
            while (true)
            {
                PrintHeader();
                Console.WriteLine(xst + "[1] View all procesess\n");
                Console.WriteLine(xst + "[2] Kill process\n");
                Console.WriteLine(xst + "[3] Exit\n");
                PrintFooter();

                Console.Write(st + "Choose an option: ");
                int option = 0;

                try
                {
                    option = int.Parse(Console.ReadLine());
                }

                catch (Exception)
                {
                    PrintMessage("ERROR: Only integer values allowed!");
                }

                bool goBack = false;

                switch (option)
                {
                    case 1:
                        PrintHeader();

                        Console.WriteLine($"\t\t{name.PadRight(40)}{id.PadRight(15)}{memory}");
                        Console.WriteLine("\t\t--------------------------------------------------------------------");

                        PrintAllProcesses();
                        PrintFooter();

                        break;
                    case 2:
                        SubMenu(goBack);
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        PrintMessage("Invalid option!");
                        break;
                }
            }
        }

        #region UI methods

        /// <summary>
        /// Представляет метод вывода header
        /// </summary>
        public static void PrintHeader()
        {
            Console.Clear();
            DateTime dtu = DateTime.Now;

            Console.WriteLine("\n\n\n\t\t\t\t\t\t\t" + dtu.ToString("dd-MM-yyyy"));
            Console.WriteLine("\t\t====================================================================");
            Console.WriteLine("\t\t\t\t\tTask Manager");
            Console.WriteLine("\t\t====================================================================");
        }

        /// <summary>
        /// Представляет метод вывода footer
        /// </summary>
        public static void PrintFooter()
        {
            Console.WriteLine("\t\t====================================================================");
        }

        /// <summary>
        /// Представляет метод вывода сообщений для пользователя
        /// </summary>
        /// <param name="userMessage"></param>
        public static void PrintMessage(string userMessage)
        {
            PrintHeader();
            Console.WriteLine("\n\n" + st + userMessage + "\n\n");
            PrintFooter();
            Console.Write(st + "Press <any> key to continue:");
            Console.ReadKey();
        }

        /// <summary>
        /// Представляет метод вывода подменю
        /// </summary>
        /// <param name="goBack"></param>
        private static void SubMenu(bool goBack)
        {
            bool check = true;
            goBack = false;

            while (true)
            {
                PrintHeader();
                Console.WriteLine(xst + "[1] Kill process by ID\n");
                Console.WriteLine(xst + "[2] Kill process by name\n");
                Console.WriteLine(xst + "[3] Back to main menu\n");
                PrintFooter();

                Console.Write(st + "Choose an option: ");
                int option = 0;

                try
                {
                    option = int.Parse(Console.ReadLine());
                }

                catch (Exception)
                {
                    PrintMessage("ERROR: Only integer values allowed!");
                }

                switch (option)
                {
                    case 1:
                        PrintHeader();
                        Console.Write("\t\tEnter the process ID.\n\t\t");

                        KillProcess(1, check);

                        PrintHeader();
                        break;

                    case 2:
                        PrintHeader();
                        Console.Write("\t\tEnter the process name.\n\t\t");

                        KillProcess(2, check);

                        PrintHeader();
                        break;

                    case 3:
                        goBack = true;
                        break;

                    default:
                        break;
                }

                if (goBack)
                    return;
            }
        }

        #endregion

        #region Functional methods

        /// <summary>
        /// Представляет метод вывода списка процессов с сортировкой
        /// </summary>
        public static void PrintAllProcesses()
        {
            try
            {
                Process[] sourceProcesses = Process.GetProcesses();
                var sortedProcesses = sourceProcesses.OrderByDescending(o => o.WorkingSet64);

                foreach (var process in sortedProcesses)
                {
                    Console.WriteLine("\t\t" + process.ProcessName.PadRight(40) + process.Id.ToString().PadRight(15) + ConvertBytes(process.PrivateMemorySize64));
                }

                PrintFooter();
                Console.Write(st + "Press <any> key to continue:");
                Console.ReadLine();
            }

            catch (Exception e)
            {
                PrintMessage(e.Message);
            }
        }

        /// <summary>
        /// Представляет метод завершения процесса
        /// </summary>
        public static void KillProcess(int option, bool check)
        {
            switch (option)
            {
                case 1:
                    try
                    {
                        int processID = int.Parse(Console.ReadLine());
                        Process[] sourceProcesses = Process.GetProcesses();

                        Console.WriteLine("\t\t------------------------------------");

                        foreach (var process in sourceProcesses)
                        {
                            if (process.Id == processID)
                            {
                                check = false;
                                process.Kill();
                                Console.WriteLine($"\n\n\t\t\t Process \"{process.ProcessName}\" Killed!\n\n");
                            }
                        }

                        if (check)
                        {
                            Console.WriteLine("\n\n\t\t No Process Found!\n\n");
                        }

                        PrintFooter();
                        Console.Write(st + "Press <any> key to continue:");
                        Console.ReadKey();
                    }

                    catch (Exception e)
                    {
                        PrintMessage(e.Message);
                    }

                    break;

                case 2:
                    try
                    {
                        string processName = Console.ReadLine();
                        Process[] sourceProcesses = Process.GetProcesses();

                        Console.WriteLine("\t\t------------------------------------");

                        foreach (var process in sourceProcesses)
                        {
                            if (!String.IsNullOrEmpty(processName) && process.ProcessName.ToLower() == processName.ToLower())
                            {
                                check = false;
                                process.Kill();
                            }
                        }

                        if (check)
                        {
                            Console.WriteLine("\n\n\t\t No Process Found!\n\n");
                        }

                        else
                        {
                            Console.WriteLine("\n\n\t\t\t Process Killed!\n\n");
                        }

                        PrintFooter();
                        Console.Write(st + "Press <any> key to continue:");
                        Console.ReadKey();
                    }

                    catch (Exception e)
                    {
                        PrintMessage(e.Message);
                    }

                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Представляет метод конвертации байтов в доступные величины измерения
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        static string ConvertBytes(long bytes)
        {
            string[] measure = { "B", "KB", "MB" };
            int i;
            double doubleBytes = bytes;

            for (i = 0; i < measure.Length && bytes >= 1024; i++, bytes /= 1024)
            {
                doubleBytes = bytes / 1024.0;
            }

            return String.Format("{0:0.##} {1}", doubleBytes, measure[i]);
        }

        #endregion
    }
}
