using System;

namespace Lesson_2_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число:");
            var number = Console.ReadLine();
            if (Convert.ToDecimal(number) % 2 == 0)
                Console.WriteLine("Введенное число четное");
            else
                Console.WriteLine("Введенное число нечетное");
            Console.ReadLine();
        }
    }
}
