using System;

namespace Lesson_2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите минимальную суточную температуру:");
            var temperature_min = Console.ReadLine();
            Console.WriteLine("Введите максимальную суточную температуру:");
            var temperature_max = Console.ReadLine();
            var temperature_avg = (Convert.ToDouble(temperature_min) + Convert.ToDouble(temperature_max)) / 2;
            Console.WriteLine($"Среднесуточная температура: {temperature_avg}");
            Console.ReadLine();
        }
    }
}
