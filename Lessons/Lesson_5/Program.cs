using System;
using System.IO;
using System.Text;

namespace Lesson_5
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.Ввести с клавиатуры произвольный набор данных и сохранить его в текстовый файл.
            Task_1();

            //2.Написать программу, которая при старте дописывает текущее время в файл «startup.txt».
            Task_2();

            //3.Ввести с клавиатуры произвольный набор чисел(0...255) и записать их в бинарный файл.
            Task_3();
        }
        static void title(int num)
        {
            Console.WriteLine($"Задание {num}");
        }
        static void Task_1()
        {
            title(1);

            Console.WriteLine("Введите произвольный текст");
            var text = Console.ReadLine();
            File.WriteAllText("task_1_text.txt", text);
            Console.WriteLine("Текст сохранен в файле task_1_text.txt");
        }
        static void Task_2()
        {
            title(2);

            File.AppendAllText("startup.txt", $"{DateTime.Now:T}\n");
            Console.WriteLine("Текущее время добавлено в файл startup.txt");
        }
        static void Task_3()
        {
            title(3);

            Console.WriteLine($"Введите произвольный набор чисел");
            byte[] bytes_array = Encoding.ASCII.GetBytes(Console.ReadLine());
            File.WriteAllBytes("task_3_bytes.bin", bytes_array);
            Console.WriteLine($"Числа сохранены в файле task_3_bytes.bin");
        }
    }
}
