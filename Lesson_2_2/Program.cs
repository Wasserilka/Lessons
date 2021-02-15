using System;

namespace Lesson_2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите порядковый номер текущего месяца:");
            var month_number = Convert.ToInt32(Console.ReadLine());
            string month_name;
            switch (month_number)
            {
                case (int)Months.Январь:
                    month_name = "январь";
                    break;
                case (int)Months.Февраль:
                    month_name = "февраль";
                    break;
                case (int)Months.Март:
                    month_name = "март";
                    break;
                case (int)Months.Апрель:
                    month_name = "апрель";
                    break;
                case (int)Months.Май:
                    month_name = "май";
                    break;
                case (int)Months.Июнь:
                    month_name = "июнь";
                    break;
                case (int)Months.Июль:
                    month_name = "июль";
                    break;
                case (int)Months.Август:
                    month_name = "август";
                    break;
                case (int)Months.Сентябрь:
                    month_name = "сентябрь";
                    break;
                case (int)Months.Октябрь:
                    month_name = "октябрь";
                    break;
                case (int)Months.Ноябрь:
                    month_name = "ноябрь";
                    break;
                case (int)Months.Декабрь:
                    month_name = "декабрь";
                    break;
                default:
                    month_name = "неизвестно";
                    break;
            }
            Console.WriteLine($"Текущий месяц - {month_name}");
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
