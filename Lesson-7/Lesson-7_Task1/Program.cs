// Decompiled with JetBrains decompiler
// Type: Lesson_6_Task1.Program
// Assembly: Lesson-6_Task1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5BAA95F8-EF52-4B35-9B9E-8A1F866D0DEA
// Assembly location: D:\Learning\GeekBrains\GeekBrains_Repo_2011\Lesson-6\Lesson-6_Task1\bin\Debug\net5.0\Lesson-6_Task1.dll

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Lesson_6_Task1
{
    internal class Program
  {
    private static string st = "\t\t ";
    private static string xst = "\t\t ";
    private static string name = "Name";
    private static string id = "ID";
    private static string memory = "Memory";

    private static void Main(string[] args)
    {
      while (true)
      {
        Program.PrintHeader();
        Console.WriteLine(Program.xst + "[1] View all procesess\n");
        Console.WriteLine(Program.xst + "[2] Kill process\n");
        Console.WriteLine(Program.xst + "[3] Exit\n");
        Program.PrintFooter();
        Console.Write(Program.st + "Choose an option: ");
        int num = 0;
        try
        {
          num = int.Parse(Console.ReadLine());
        }
        catch (Exception ex)
        {
          Program.PrintMessage("ERROR: Only integer values allowed!");
        }
        bool goBack = false;
        switch (num)
        {
          case 1:
            Program.PrintHeader();
            Console.WriteLine("\t\t" + Program.name.PadRight(40) + Program.id.PadRight(15) + Program.memory);
            Console.WriteLine("\t\t--------------------------------------------------------------------");
            Program.PrintAllProcesses();
            Program.PrintFooter();
            break;
          case 2:
            Program.SubMenu(goBack);
            break;
          case 3:
            Environment.Exit(0);
            break;
          default:
            Program.PrintMessage("Invalid option!");
            break;
        }
      }
    }

    public static void PrintHeader()
    {
      Console.Clear();
      Console.WriteLine("\n\n\n\t\t\t\t\t\t\t" + DateTime.Now.ToString("dd-MM-yyyy"));
      Console.WriteLine("\t\t====================================================================");
      Console.WriteLine("\t\t\t\t\tTask Manager");
      Console.WriteLine("\t\t====================================================================");
    }

    public static void PrintFooter() => Console.WriteLine("\t\t====================================================================");

    public static void PrintMessage(string userMessage)
    {
      Program.PrintHeader();
      Console.WriteLine("\n\n" + Program.st + userMessage + "\n\n");
      Program.PrintFooter();
      Console.Write(Program.st + "Press <any> key to continue:");
      Console.ReadKey();
    }

    private static void SubMenu(bool goBack)
    {
      bool check = true;
      goBack = false;
      do
      {
        Program.PrintHeader();
        Console.WriteLine(Program.xst + "[1] Kill process by ID\n");
        Console.WriteLine(Program.xst + "[2] Kill process by name\n");
        Console.WriteLine(Program.xst + "[3] Back to main menu\n");
        Program.PrintFooter();
        Console.Write(Program.st + "Choose an option: ");
        int num = 0;
        try
        {
          num = int.Parse(Console.ReadLine());
        }
        catch (Exception ex)
        {
          Program.PrintMessage("ERROR: Only integer values allowed!");
        }
        switch (num)
        {
          case 1:
            Program.PrintHeader();
            Console.Write("\t\tEnter the process ID.\n\t\t");
            Program.KillProcess(1, check);
            Program.PrintHeader();
            break;
          case 2:
            Program.PrintHeader();
            Console.Write("\t\tEnter the process name.\n\t\t");
            Program.KillProcess(2, check);
            Program.PrintHeader();
            break;
          case 3:
            goBack = true;
            break;
        }
      }
      while (!goBack);
    }

    public static void PrintAllProcesses()
    {
      try
      {
        foreach (Process process in (IEnumerable<Process>) ((IEnumerable<Process>) Process.GetProcesses()).OrderByDescending<Process, long>((Func<Process, long>) (o => o.WorkingSet64)))
          Console.WriteLine("\t\t" + process.ProcessName.PadRight(40) + process.Id.ToString().PadRight(15) + process.PrivateMemorySize64);
        Program.PrintFooter();
        Console.Write(Program.st + "Press <any> key to continue:");
        Console.ReadLine();
      }
      catch (Exception ex)
      {
        Program.PrintMessage(ex.Message);
      }
    }

    public static void KillProcess(int option, bool check)
    {
      switch (option)
      {
        case 1:
          try
          {
            int num = int.Parse(Console.ReadLine());
            Process[] processes = Process.GetProcesses();
            Console.WriteLine("\t\t------------------------------------");
            foreach (Process process in processes)
            {
              if (process.Id == num)
              {
                check = false;
                process.Kill();
                Console.WriteLine("\n\n\t\t\t Process \"" + process.ProcessName + "\" Killed!\n\n");
              }
            }
            if (check)
              Console.WriteLine("\n\n\t\t No Process Found!\n\n");
            Program.PrintFooter();
            Console.Write(Program.st + "Press <any> key to continue:");
            Console.ReadKey();
            break;
          }
          catch (Exception ex)
          {
            Program.PrintMessage(ex.Message);
            break;
          }
        case 2:
          try
          {
            string str = Console.ReadLine();
            Process[] processes = Process.GetProcesses();
            Console.WriteLine("\t\t------------------------------------");
            foreach (Process process in processes)
            {
              if (!string.IsNullOrEmpty(str) && process.ProcessName.ToLower() == str.ToLower())
              {
                check = false;
                process.Kill();
              }
            }
            if (check)
              Console.WriteLine("\n\n\t\t No Process Found!\n\n");
            else
              Console.WriteLine("\n\n\t\t\t Process Killed!\n\n");
            Program.PrintFooter();
            Console.Write(Program.st + "Press <any> key to continue:");
            Console.ReadKey();
            break;
          }
          catch (Exception ex)
          {
            Program.PrintMessage(ex.Message);
            break;
          }
      }
    }

    // Внесение правок (комментирование метода) по задаче урока 7

    //private static string ConvertBytes(long bytes)
    //{
    //  string[] strArray = new string[3]{ "B", "KB", "MB" };
    //  double num = (double) bytes;
    //  int index;
    //  for (index = 0; index < strArray.Length && bytes >= 1024L; bytes /= 1024L)
    //  {
    //    num = (double) bytes / 1024.0;
    //    ++index;
    //  }
    //  return string.Format("{0:0.##} {1}", (object) num, (object) strArray[index]);
    //}
  }
}
