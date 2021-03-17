using System;
using System.Diagnostics;

namespace Lesson_8_1
{
    class Program
    {
        static Process[] ProcessList;
        public class NoProcessException : Exception { }
        static void Main(string[] args)
        {
            //1.Написать консольное приложение Task Manager, которое выводит на экран запущенные процессы и позволяет завершить указанный процесс. 
            //Предусмотреть возможность завершения процессов с помощью указания его ID или имени процесса. 
            //В качестве примера можно использовать консольные утилиты Windows tasklist и taskkill.
            while (true)
            {
                Console.WriteLine("1. Отобразить список процессов\n2. Завершить процесс\n3. Выход");
                switch (Console.ReadLine())
                {
                    case "1":
                        TaskManager_GetProcesses(out ProcessList);
                        break;
                    case "2":
                        TaskManager_KillProcesses();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Неверная команда!");
                        break;
                }
            }          
        }

        static void TaskManager_GetProcesses(out Process[] ProcessList)
        {
            ProcessList = Process.GetProcesses();
            foreach (Process item in ProcessList)
            {
                Console.WriteLine($" {item.Id, -10}{item.ProcessName}");
            }             
        }
        static void TaskManager_KillProcesses()
        {
            Console.WriteLine("Введите имя или ID процесса");
            var str = Console.ReadLine();
            try
            {
                foreach (Process item in ProcessList)
                {
                    if (item.Id.ToString() == str || item.ProcessName == str)
                    {
                        item.Kill();
                        Console.WriteLine($"Процесс {str} завершен");
                        return;
                    }
                }
                throw new NoProcessException();
            }
            catch (NoProcessException)
            {
                Console.WriteLine("Указанный процесс не найден");
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
    }
}
