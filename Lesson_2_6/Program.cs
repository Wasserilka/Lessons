using System;

namespace Lesson_2_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Пример использования битовых масок\nВведите день недели:");
            var day_number = Convert.ToInt32(Console.ReadLine());
            string day_name;
            int day_mask;
            switch (day_number)
            {
                case (int)Days.Понедельник:
                    day_name = "Понедельник";
                    day_mask = 0b1000000;
                    break;
                case (int)Days.Вторник:
                    day_name = "Вторник";
                    day_mask = 0b100000;
                    break;
                case (int)Days.Среда:
                    day_name = "Среда";
                    day_mask = 0b10000;
                    break;
                case (int)Days.Четверг:
                    day_name = "Четверг";
                    day_mask = 0b1000;
                    break;
                case (int)Days.Пятница:
                    day_name = "Пятница";
                    day_mask = 0b100;
                    break;
                case (int)Days.Суббота:
                    day_name = "Суббота";
                    day_mask = 0b10;
                    break;
                case (int)Days.Воскресенье:
                    day_name = "Воскресенье";
                    day_mask = 0b1;
                    break;
                default:
                    day_name = "Неизвестно";
                    day_mask = 0b0;
                    break;
            }

            Console.WriteLine($"Оффисы, работающие в выбранный день недели ({day_name}):\n");
            string str_offices = null;
            if (((int)Offices.Офис_1 & day_mask) == day_mask)
                str_offices += "Офис 1\n";
            if (((int)Offices.Офис_2 & day_mask) == day_mask)
                str_offices += "Офис 2\n";
            if (((int)Offices.Офис_3 & day_mask) == day_mask)
                str_offices += "Офис 3\n";
            if (((int)Offices.Офис_4 & day_mask) == day_mask)
                str_offices += "Офис 4\n";
            if (str_offices == null)
                str_offices = "Все офисы закрыты\n";
            Console.WriteLine(str_offices);
            Console.ReadLine();
        }
    }
    enum Days
    {
        Понедельник = 1,
        Вторник,
        Среда,
        Четверг,
        Пятница,
        Суббота,
        Воскресенье
    }
    enum Offices
    {
        Офис_1 = 0b1010101,
        Офис_2 = 0b1111100,
        Офис_3 = 0b1111111,
        Офис_4 = 0b1101110
    }
}
