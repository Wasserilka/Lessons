using System;

namespace Lesson_2_5
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

            Console.WriteLine("Введите порядковый номер текущего месяца:");
            var month_number = Convert.ToInt32(Console.ReadLine());

            switch (month_number)
            {
                case (int)Months.Декабрь:
                case (int)Months.Январь:
                case (int)Months.Февраль:
                    if (temperature_avg > 0)
                        Console.WriteLine("Дождливая зима");
                    break;
                case (int)Months.Март:
                case (int)Months.Апрель:
                case (int)Months.Май:
                case (int)Months.Июнь:
                case (int)Months.Июль:
                case (int)Months.Август:
                case (int)Months.Сентябрь:
                case (int)Months.Октябрь:
                case (int)Months.Ноябрь:
                default:
                    break;
            }
            Console.ReadLine();
        }
    }
    enum Months
    {
        Январь = 1,
        Февраль,
        Март,
        Апрель,
        Май,
        Июнь,
        Июль,
        Август,
        Сентябрь,
        Октябрь,
        Ноябрь,
        Декабрь
    }
}
