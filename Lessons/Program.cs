using System;

namespace Lessons
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите имя пользователя:");
            var user_name = Console.ReadLine();
            Console.WriteLine($"Привет, {user_name}, сегодня {DateTime.Now:d}");
            Console.ReadLine();
        }
    }
}
