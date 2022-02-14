using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Lesson_5_Task5
{
    class Program
    {
        private static string st = "\t\t ";
        private static string xst = "\t\t ";
        private const string fileName = "tasks.json";
        private const string fileNameXML = "tasks.xml";

        static void Main(string[] args)
        {
            Random rnd = new Random();
            int ID = rnd.Next(89);

            List<ToDo> TasksList = new List<ToDo>();
            bool check = true;

            while (true)
            {
                PrintHeader();
                Console.WriteLine(xst + "\t1.New Task.\t2.Update Task.\n");
                Console.WriteLine(xst + "\t3.View All.\t4.Delete task.\n");
                //Console.WriteLine();
                Console.WriteLine(xst + "5.Export file (JSON).\t6.Import file (JSON).\n");
                Console.WriteLine(xst + "7.Export file (XML).\t8.Import file (XML).\n");
                Console.WriteLine(xst + "\t\t   9.Exit.\n");
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
                    // Add
                    case 1:
                        PrintHeader();

                        Console.Write("\n\t\tEnter task title: \n\t\t");
                        string title = Console.ReadLine();
                        
                        ID++;

                        AddTask(TasksList, ID, title);

                        break;

                    // Update
                    case 2:
                        PrintHeader();
                        Console.Write("\t\tEnter the task ID.\n\t\t");

                        UpdateTask(TasksList, check);

                        break;

                    // View
                    case 3:
                        PrintHeader();
                        Console.WriteLine("\t\tID \t\tTitle \t\tCompleted");

                        ViewTasks(TasksList, check);

                        break;

                    // Delete
                    case 4:
                        PrintHeader();
                        Console.Write("\t\tEnter the task ID.\n\t\t");

                        DeleteTask(TasksList, check);

                        break;

                    // Export JSON
                    case 5:
                        PrintHeader();
                        Console.Write($"\t\t Serializing tasks into file \"{fileName}\"...\n\t\t\n");

                        SerializeIntoJson(TasksList);

                        break;

                    // Import JSON
                    case 6:
                        PrintHeader();
                        Console.Write($"\t\t Deserializing tasks from file \"{fileName}\"...\n\t\t\n");

                        DeserializeFromJson(TasksList);

                        break;

                    // Export XML
                    case 7:
                        PrintHeader();
                        Console.Write($"\t\t Serializing tasks into file \"{fileNameXML}\"...\n\t\t\n");

                        SerializeIntoXML(TasksList);

                        break;

                    // Import XML
                    case 8:
                        PrintHeader();
                        Console.Write($"\t\t Deserializing tasks from file \"{fileNameXML}\"...\n\t\t\n");

                        DeserializeFromXML(TasksList);

                        break;

                    // Exit
                    case 9:
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

            Console.WriteLine("\n\n\n\t\t\t\t\t\t" + dtu.ToString("dd-MM-yyyy"));
            Console.WriteLine("\t\t=============================================");
            Console.WriteLine("\t\t\t\t TO-DO List");
            Console.WriteLine("\t\t=============================================");
        }

        /// <summary>
        /// Представляет метод вывода footer
        /// </summary>
        public static void PrintFooter()
        {
            Console.WriteLine("\t\t=============================================");
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

        #endregion

        #region Functional methods

        /// <summary>
        /// Представляет метод сериализации (экспорта) списка задач в JSON файл
        /// </summary>
        /// <param name="tasksList"></param>
        public static void SerializeIntoJson(List<ToDo> tasksList)
        {
            try
            {
                if (tasksList.Count > 0)
                {
                    string json = Newtonsoft.Json.JsonConvert.SerializeObject(tasksList, Formatting.Indented);
                    File.WriteAllText(fileName, json);

                    foreach (var task in tasksList)
                    {
                        Console.WriteLine($"\t\t Adding task \"{task.Title}\" ...");
                        Thread.Sleep(1000);
                        Console.WriteLine($"\t\t\t Task added!");
                        Console.WriteLine();
                    }

                    Console.WriteLine($"\t\t All tasks added to file \"{fileName}\" successfully!");
                }

                else
                {
                    Console.WriteLine("\n\t\t No Record Found!\n");
                }

                PrintFooter();
                Console.Write(st + "Press <any> key to continue:");
                Console.ReadKey();
            }

            catch (Exception)
            {
                PrintMessage("ERROR while JSON serialization!");
            }
        }

        /// <summary>
        /// Представляет метод десериализации (импорта) из JSON файла
        /// </summary>
        /// <param name="tasksList"></param>
        public static void DeserializeFromJson(List<ToDo> tasksList)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    Console.WriteLine($"\t\t Reading data from \"{fileName}\" file...\n");
                    Thread.Sleep(500);

                    string chk = "[x]";
                    string data = File.ReadAllText(fileName);
                    var tasks = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ToDo>>(data);

                    Console.WriteLine($"\t\t Adding tasks from \"{fileName}\" file...\n");
                    Thread.Sleep(500);

                    foreach (var task in tasks)
                    {
                        if (!task.IsDone && task.Title.StartsWith(chk))
                        {
                            task.Title = task.Title.Substring(3);
                        }

                        Console.WriteLine($"\t\t Adding task \"{task.Title}\" ...");
                        Thread.Sleep(1500);

                        tasksList.Add(task);

                        Console.WriteLine($"\t\t\t Task added!");
                        Thread.Sleep(1000);
                        Console.WriteLine();
                    }

                    Console.WriteLine("\t\t All tasks added successfully!");
                    PrintFooter();
                    Console.Write(st + "Press <any> key to continue:");
                    Console.ReadKey();
                }

                else
                {
                    PrintMessage($"ERROR: File \"{fileName}\" not found!");
                }
            }

            catch (Exception)
            {
                PrintMessage("ERROR!");
            }

        }

        /// <summary>
        /// Представляет метод сериализации (экспорта) одиночной задачи в XML файл
        /// </summary>
        /// <param name="tasksList"></param>
        public static void SerializeIntoXML(List<ToDo> tasksList)
        {
            // TODO: сериализация коллекций объектов не реализована
            try
            {
                if (tasksList.Count == 1)
                {
                    StringWriter stringWriter = new StringWriter();
                    XmlSerializer serializer = new XmlSerializer(typeof(ToDo));

                    serializer.Serialize(stringWriter, tasksList[0]);
                    string xml = stringWriter.ToString();

                    Console.WriteLine($"\t\t Adding task \"{tasksList[0].Title}\" ...");
                    Thread.Sleep(1000);

                    File.WriteAllText(fileNameXML, xml);

                    Console.WriteLine($"\t\t\t Task added!");
                    Console.WriteLine();

                    PrintFooter();
                    Console.Write(st + "Press <any> key to continue:");
                    Console.ReadKey();
                }

                else if (tasksList.Count == 0)
                {
                    Console.WriteLine("\n\t\t No Record Found!\n");
                    
                    PrintFooter();
                    Console.Write(st + "Press <any> key to continue:");
                    Console.ReadKey();
                }

                else
                {
                    PrintMessage("ERROR: XML serialization is not available!");
                }
            }

            catch (Exception)
            {
                PrintMessage("ERROR while XML serialization!");
            }
        }

        /// <summary>
        /// Представляет метод десериализации (импорта) одиночной задачи из XML файла
        /// </summary>
        /// <param name="tasksList"></param>
        public static void DeserializeFromXML(List<ToDo> tasksList)
        {
            try
            {
                if (File.Exists(fileNameXML))
                {
                    Console.WriteLine($"\t\t Reading data from \"{fileNameXML}\" file...\n");
                    Thread.Sleep(500);

                    string xmlText = File.ReadAllText(fileNameXML);

                    Console.WriteLine($"\t\t Adding tasks from \"{fileNameXML}\" file...\n");
                    Thread.Sleep(500);

                    StringReader stringReader = new StringReader(xmlText);
                    XmlSerializer serializer = new XmlSerializer(typeof(ToDo));

                    ToDo task = (ToDo)serializer.Deserialize(stringReader);

                    Console.WriteLine($"\t\t Adding task \"{task.Title}\" ...");
                    Thread.Sleep(1500);

                    tasksList.Add(task);

                    Console.WriteLine($"\t\t\t Task added!");
                    Thread.Sleep(1000);
                    Console.WriteLine();

                    Console.WriteLine("\t\t All tasks added successfully!");
                    PrintFooter();
                    Console.Write(st + "Press <any> key to continue:");
                    Console.ReadKey();
                }

                else
                {
                    PrintMessage($"ERROR: File \"{fileNameXML}\" not found!");
                }


            }

            catch (Exception)
            {
                PrintMessage("ERROR!");
            }
        }

        /// <summary>
        /// Представляет метод добавления задачи
        /// </summary>
        /// <param name="tasksList"></param>
        /// <param name="ID"></param>
        /// <param name="title"></param>
        public static void AddTask(List<ToDo> tasksList, int ID, string title)
        {
            try
            {
                tasksList.Add(new ToDo(ID, title, false));
                PrintMessage("New Task created with Task ID = " + ID.ToString());
            }

            catch (Exception)
            {
                PrintMessage("ERROR while adding a task!");
            }
        }

        /// <summary>
        /// Представляет метод просмотра списка задач
        /// </summary>
        /// <param name="tasksList"></param>
        /// <param name="check"></param>
        public static void ViewTasks(List<ToDo> tasksList, bool check)
        {
            try
            {
                foreach (var task in tasksList)
                {
                    check = false;
                    string done = task.IsDone ? "Yes" : "No";
                    Console.WriteLine("\t\t" + task.Id + "\t\t" + task.Title + "\t\t" + done);
                }

                if (check)
                {
                    Console.WriteLine("\n\n\t\tNo Records Found!\n\n");
                }

                PrintFooter();
                Console.Write(st + "Press <any> key to continue:");
                Console.ReadKey();
            }

            catch (Exception)
            {
                PrintMessage("ERROR while viewing tasks!");
            }
        }

        /// <summary>
        /// Представляет метод обновления данных о задаче
        /// </summary>
        /// <param name="tasksList"></param>
        /// <param name="check"></param>
        public static void UpdateTask(List<ToDo> tasksList, bool check)
        {
            try
            {
                int taskID = int.Parse(Console.ReadLine());
                Console.WriteLine("\t\t------------------------------------");

                for (int i = 0; i < tasksList.Count; i++)
                {
                    if (tasksList[i].Id == taskID)
                    {
                        check = false;
                        try
                        {
                            Console.Write("\n\t\tEnter a new task title:\n\t\t");
                            string newTitle = Console.ReadLine();

                            Console.Write("\n\t\tEnter a new complete status: (yes or no)\n\t\t");

                            tasksList[i].Title = newTitle;

                            string isDone = Console.ReadLine();

                            if (isDone.ToLower().Equals("yes"))
                            {
                                tasksList[i].IsDone = true;
                                tasksList[i].Title = "[x]" + newTitle;
                            }

                            if (isDone.ToLower().Equals("no"))
                            {
                                tasksList[i].IsDone = false;
                            }

                            Console.WriteLine($"\n\t\tTask with ID {tasksList[i].Id} Updated!");

                        }

                        catch (Exception)
                        {
                            PrintMessage("ERROR: Only integer values allowed!");
                        }
                    }
                }

                if (check)
                {
                    Console.WriteLine("\n\n\t\t No Record Found!\n\n");
                }

                PrintFooter();
                Console.Write(st + "Press <any> key to continue:");
                Console.ReadKey();
            }

            catch (Exception)
            {
                PrintMessage("ERROR: Only integer values allowed!");
            }
        }

        /// <summary>
        /// Представляет метод удаления задачи
        /// </summary>
        /// <param name="tasksList"></param>
        /// <param name="check"></param>
        public static void DeleteTask(List<ToDo> tasksList, bool check)
        {
            try
            {
                int taskID = int.Parse(Console.ReadLine());

                Console.WriteLine("\t\t------------------------------------");

                for (int i = 0; i < tasksList.Count; i++)
                {
                    if (tasksList[i].Id == taskID)
                    {
                        check = false;
                        tasksList.RemoveAll(e => e.Id == taskID);
                    }
                }

                if (check)
                {
                    Console.WriteLine("\n\n\t\t No Record Found!\n\n");
                }

                else
                {
                    Console.WriteLine("\n\n\t\t\t Record Deleted!\n\n");

                }

                PrintFooter();
                Console.Write(st + "Press <any> key to continue:");
                Console.ReadKey();
            }

            catch (Exception)
            {
                PrintMessage("ERROR: Only integer values allowed!");
            }
        }

        #endregion
    }
}
