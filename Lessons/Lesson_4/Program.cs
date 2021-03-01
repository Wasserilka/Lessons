using System;

namespace Lesson_4
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. Написать метод GetFullName(string firstName, string lastName, string patronymic), 
            //принимающий на вход ФИО в разных аргументах и возвращающий объединённую строку с ФИО. 
            //Используя метод, написать программу, выводящую в консоль 3–4 разных ФИО.
            task_1();

            //2. Написать программу, принимающую на вход строку — набор чисел, разделенных пробелом, 
            //и возвращающую число — сумму всех чисел в строке. Ввести данные с клавиатуры и вывести результат на экран.
            task_2();

            //3. Написать метод по определению времени года. На вход подаётся число – порядковый номер месяца. 
            //На выходе — значение из перечисления (enum) — Winter, Spring, Summer, Autumn. Написать метод, 
            //принимающий на вход значение из этого перечисления и возвращающий название времени года (зима, весна, лето, осень). 
            //Используя эти методы, ввести с клавиатуры номер месяца и вывести название времени года. 
            //Если введено некорректное число, вывести в консоль текст «Ошибка: введите число от 1 до 12».
            task_3();

            //4. (*) Написать программу, вычисляющую число Фибоначчи для заданного значения рекурсивным способом.
            task_4();
        }

        static void title(int num)
        {
            Console.WriteLine($"Задание {num}");
        }
        static void task_1()
        {
            title(1);

            Console.WriteLine(GetFullName("Борис", "Соколов", "Иванович"));
            Console.WriteLine(GetFullName("Мария", "Ананьява", "Дмитриевна"));
            Console.WriteLine(GetFullName("Денис", "Мартынов", "Андреевич"));
            Console.WriteLine(GetFullName("Анастасия", "Донцова", "Николаевна"));

            static string GetFullName(string firstName, string lastName, string patronymic)
            {
                return $"{lastName} {firstName} {patronymic}";
            }
        }
        static void task_2()
        {
            title(2);

            Console.WriteLine($"Введите числа через пробел");

            string[] str_array = Console.ReadLine().Split(' ');
            double sum = 0;

            GetSum(ref sum, str_array);

            Console.WriteLine($"Сумма введенных чисел: {sum}");

            static void GetSum(ref double sum, params string[] str_array)
            {
                foreach (string array_part in str_array)
                    sum += Convert.ToDouble(array_part);
            }
        }
        static void task_3()
        {
            title(3);

            Console.WriteLine($"Введите порядковый номер месяца");
            while(true)
            {
                var season_num = (GetSeason(Convert.ToInt32(Console.ReadLine())));
                if (season_num != 0)
                {
                    Console.WriteLine($"Время года: {GetSeasonName(season_num)}");
                    break;
                }
                else
                    Console.WriteLine("Ошибка: введите число от 1 до 12");
            }

            static int GetSeason(int num)
            {
                switch (num)
                {
                    case 12:
                    case 1:
                    case 2:
                        return (int)Seasons.Winter;
                    case 3:
                    case 4:
                    case 5:
                        return (int)Seasons.Spring;
                    case 6:
                    case 7:
                    case 8:
                        return (int)Seasons.Summer;
                    case 9:
                    case 10:
                    case 11:
                        return (int)Seasons.Autumn;
                    default:
                        return 0;
                }
            }
            static string GetSeasonName(int num)
            {
                switch (num)
                {
                    case 1:
                        return "Зима";
                    case 2:
                        return "Весна";
                    case 3:
                        return "Лето";
                    case 4:
                        return "Осень";
                    default:
                        return null;
                }
            }
        }
        static void task_4()
        {
            title(4);

            Console.WriteLine($"Введите номер числа в последовательности Фибоначчи");
            var num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Число Фибоначчи: {GetValue(num)}");

            static int GetValue(int num)
            {
                var val_0 = 0;
                var val_1 = 1;
                var num_0 = 2;

                if (Math.Abs(num) == 0)
                    return val_0;
                else if (Math.Abs(num) == 1)
                    return val_1;
                else
                    return (int)Math.Pow(Math.Sign(num), num + 1) * Recurse(val_0, val_1, num_0, num);
            }
            static int Recurse(int val_0, int val_1, int i, int num)
            {
                var value = val_0 + val_1;
                if (i == Math.Abs(num))
                    return value;
                return Recurse(val_1, value, i + 1, num);
            }
        }
        enum Seasons
        {
            Winter = 1,
            Spring,
            Summer,
            Autumn
        }
    }
}
