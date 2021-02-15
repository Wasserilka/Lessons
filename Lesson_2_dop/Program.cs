using System;

namespace Lesson_2_dop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите год:");
            var year = Convert.ToInt32(Console.ReadLine());
            if ((year % 4 == 0) && ((year % 100 != 0) || (year % 400 == 0)))
                Console.WriteLine($"{year} - високосный год");
            else
                Console.WriteLine($"{year} - невисокосный год");

            Console.ReadLine();
        }
    }
}
