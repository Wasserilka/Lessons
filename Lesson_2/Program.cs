using System;

namespace Lesson_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //1
            Console.WriteLine("Введите минимальную суточную температуру:");
            var temperature_min = Console.ReadLine();
            Console.WriteLine("Введите максимальную суточную температуру:");
            var temperature_max = Console.ReadLine();
            var temperature_avg = (Convert.ToDouble(temperature_min) + Convert.ToDouble(temperature_max)) / 2;
            Console.WriteLine($"Среднесуточная температура: {temperature_avg}\n");

            //2
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
            Console.WriteLine($"Текущий месяц - {month_name}\n");

            //3
            if (Convert.ToDecimal(month_number) % 2 == 0)
                Console.WriteLine("Введенное число четное\n");
            else
                Console.WriteLine("Введенное число нечетное\n");

            //4
            var shop_name = "Камелот-А";
            var shop_adress = "630111,г.Новосибирск,кл.Кропоткина,288";
            var tin = "ИНН:7017187800";
            var cashier_name = "Кассир: Балховская Д.";
            var ofd = "ООО Петер-Сервис Спецтехнологии";
            var receipt_num = "3Ъ301082194";
            var item_name = "Грудка куриная охл.подл.";
            var item_amount = 0.682;
            var item_price = 165.5;
            var vat = 10;
            var card = "Картой МИР";

            var item_cost = Math.Round(item_amount * item_price, 2);
            var vat_amount = Math.Round(item_cost * vat / 100, 2);

            Console.WriteLine($"{shop_name}\n{shop_adress}\nКАССОВЫЙ ЧЕК/ПРИХОД\n{tin}\n{cashier_name}\nСайт ФНС: www.nalog.ru\nОФД: {ofd}\n" +
                $"Сайт ОФД: www.ofd.ru\nНомер чека {receipt_num}\n----------\n{item_name}\n{item_amount} Х {item_price} = {item_cost}_Б\n" +
                $"НДС {vat}% {vat_amount}\nИТОГ = {item_cost}\nЭЛЕКТРОННЫМИ ПОЛУЧЕНО: {item_cost}\n{card} = {item_cost}\nБ:СУММА НДС {vat}% = {vat_amount}\n");

            //Результат
            /*
            Камелот - А
            630111,г.Новосибирск,кл.Кропоткина,288
            КАССОВЫЙ ЧЕК/ ПРИХОД
            ИНН: 7017187800
            Кассир: Балховская Д.
            Сайт ФНС: www.nalog.ru
            ОФД: ООО Петер-Сервис Спецтехнологии
            Сайт ОФД: www.ofd.ru
            Номер чека 3Ъ301082194
            ----------
            Грудка куриная охл.подл.
            0.682 Х 165.5 = 112.87_Б
            НДС 10 % 11.29
            ИТОГ = 112.87
            ЭЛЕКТРОННЫМИ ПОЛУЧЕНО: 112.87
            Картой МИР = 112.87
            Б: СУММА НДС 10 % = 11.29
            */

            //5*
            switch (month_number)
            {
                case (int)Months.Декабрь:
                case (int)Months.Январь:
                case (int)Months.Февраль:
                    if (temperature_avg > 0)
                        Console.WriteLine("Дождливая зима\n");
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

            //6*
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

            //dop
            Console.WriteLine("Введите год:");
            var year = Convert.ToInt32(Console.ReadLine());
            if ((year % 4 == 0) && ((year % 100 != 0) || (year % 400 == 0)))
                Console.WriteLine($"{year} - високосный год");
            else
                Console.WriteLine($"{year} - невисокосный год");

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
