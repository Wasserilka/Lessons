using System;

namespace Lesson_2_4
{
    class Program
    {
        static void Main(string[] args)
        {
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
                $"НДС {vat}% {vat_amount}\nИТОГ = {item_cost}\nЭЛЕКТРОННЫМИ ПОЛУЧЕНО: {item_cost}\n{card} = {item_cost}\nБ:СУММА НДС {vat}% = {vat_amount}");
            Console.ReadLine();
        }
    }
}
//Результат
//
//Камелот - А
//630111,г.Новосибирск,кл.Кропоткина,288
//КАССОВЫЙ ЧЕК/ПРИХОД
//ИНН:7017187800
//Кассир: Балховская Д.
//Сайт ФНС: www.nalog.ru
//ОФД: ООО Петер-Сервис Спецтехнологии
//Сайт ОФД: www.ofd.ru
//Номер чека 3Ъ301082194
//----------
//Грудка куриная охл.подл.
//0.682 Х 165.5 = 112.87_Б
//НДС 10% 11.29
//ИТОГ = 112.87
//ЭЛЕКТРОННЫМИ ПОЛУЧЕНО: 112.87
//Картой МИР = 112.87
//Б:СУММА НДС 10% = 11.29
