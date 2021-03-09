using System;
using System.IO;
using System.Collections;
using System.Text.Json;

namespace Lesson_6
{
    public class MyArraySizeException : Exception { }
    public class MyArrayDataException : Exception 
    {
        public int I;
        public int J;

        public MyArrayDataException(int i, int j)
        {
            I = i;
            J = j;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //1. Сохранить дерево каталогов и файлов по заданному пути в текстовый файл — с рекурсией и без.
            FileDirParse();

            //2. Список задач (ToDo-list):
            //написать приложение для ввода списка задач;
            //задачу описать классом ToDo с полями Title и IsDone;
            //на старте, если есть файл tasks.json / xml / bin(выбрать формат), загрузить из него массив имеющихся задач и вывести их на экран;
            //если задача выполнена, вывести перед её названием строку «[x]»;
            //вывести порядковый номер для каждой задачи;
            //при вводе пользователем порядкового номера задачи отметить задачу с этим порядковым номером как выполненную;
            //записать актуальный массив задач в файл tasks.json / xml / bin.
            ToDoListApp();

            //3.Напишите метод, на вход которого подаётся двумерный строковый массив размером 4х4,
            //при подаче массива другого размера необходимо бросить исключение MyArraySizeException.
            //Далее метод должен пройтись по всем элементам массива, преобразовать в int, и просуммировать.
            //Если в каком - то элементе массива преобразование не удалось
            //(например, в ячейке лежит символ или текст вместо числа), должно быть брошено исключение MyArrayDataException, 
            //с детализацией в какой именно ячейке лежат неверные данные.
            //В методе main() вызвать полученный метод, обработать возможные исключения MySizeArrayException и MyArrayDataException, и вывести результат расчета.
            ArraySumMain();

            //4.Создать класс "Сотрудник" с полями: ФИО, должность, email, телефон, зарплата, возраст;
            //Конструктор класса должен заполнять эти поля при создании объекта;
            //Внутри класса «Сотрудник» написать метод, который выводит информацию об объекте в консоль;
            //Создать массив из 5 сотрудников
            //С помощью цикла вывести информацию только о сотрудниках старше 40 лет;
            GetEmployees();
        }
        static void FileDirParse()
        {
            var root = @"C:\Windows";
            Console.WriteLine($"Задание 1");

            //рекурсия
            File.WriteAllText("FileDirTreeRecurse.txt", FileDirParseRecurse(root));

            //цикл
            File.WriteAllText("FileDirTreeCycle.txt", FileDirParseCycle(root));
        }
        static string FileDirParseRecurse(string root)
        {
            string tree = "";

            foreach (string dir_path in Directory.GetDirectories(root))
            {
                tree += FileDirParseRecurse(dir_path);
            }
            foreach (string file_path in Directory.GetFiles(root))
                tree += $"{file_path}\n";

            return $"{root}\n{tree}";
        }
        static string FileDirParseCycle(string root)
        {
            string tree = "";
            var array = new Stack();
            array.Push(root);

            while (array.Count > 0)
            {
                var root_temp = (string)array.Pop();
                foreach (string dir_path in Directory.GetDirectories(root_temp))
                    array.Push(dir_path);
                tree += $"{root_temp}\n";
                foreach (string file_path in Directory.GetFiles(root_temp))
                    tree += $"{file_path}\n";
            }

            return tree;
        }
        static void ToDoListApp()
        {
            Console.WriteLine($"Задание 2");
            var ToDoList = new ArrayList();

            if (File.Exists("tasks.json"))
                ToDoGetList(ToDoList);
            else
                ToDoNewList();

            while (true)
            {
                Console.WriteLine("1. Загрузить список задач\n2. Добавить новую задачу\n3. Изменить статус задачи\n4. Сохранить список задач\n5. Выход\n");
                switch (Console.ReadLine())
                {
                    case "1":
                        ToDoGetList(ToDoList);
                        break;
                    case "2":
                        ToDoNewTask(ToDoList);
                        break;
                    case "3":
                        ToDoTaskDone(ToDoList);
                        break;
                    case "4":
                        ToDoSaveList(ToDoList);
                        break;
                    case "5":
                        return;
                    default:
                    break;
                }
            }
        }
        static void ToDoNewList()
        {
            File.WriteAllText("tasks.json", "");
            Console.WriteLine("Создан новый список задач.\n");
        }
        static void ToDoGetList(ArrayList todolist)
        {
            Console.WriteLine("Список задач:\n");
            var json_text = File.ReadAllLines("tasks.json");
            todolist.Clear();
            foreach(string line in json_text)
            {
                var task = JsonSerializer.Deserialize<ToDo>(line);
                todolist.Add(task);
            }
            for (int i=0; i<todolist.Count; i++)
                Console.WriteLine($"{i+1}. {((ToDo)todolist[i]).Title}");
            Console.WriteLine();
        }
        static void ToDoNewTask(ArrayList todolist)
        {
            Console.WriteLine("Введите имя задачи");
            var name = Console.ReadLine();
            todolist.Add(new ToDo(name));
            Console.WriteLine($"Добавлена задача {name}\n");
        }
        static void ToDoTaskDone(ArrayList todolist)
        {
            Console.WriteLine("Введите номер задачи");
            var num = Convert.ToInt32(Console.ReadLine());
            ((ToDo)todolist[num - 1]).IsDone = true;
            Console.WriteLine($"Задача {num} выполнена\n");
        }
        static void ToDoSaveList(ArrayList todolist)
        {
            var json_text = "";
            foreach(ToDo task in todolist)
            {
                json_text += $"{JsonSerializer.Serialize(task)}\n";
            }
            File.WriteAllText("tasks.json", json_text);
            Console.WriteLine("Список задач сохранен\n");
        }
        static void ArraySumMain()
        {
            string[,] array = { 
                { "5", "7", "9", "2" },
                { "4", "6", "1", "0" },
                { "3", "5", "2", "8" },
                { "1", "0", "5", "6" }};
            var sum = 0;

            try
            {
                sum = ArraySum(array);
                Console.WriteLine($"Сумма всех элементов массива = {sum}");
            }
            catch (MyArraySizeException)
            {
                Console.WriteLine("Размер массива не соответствует установленному 4х4");
            }
            catch (MyArrayDataException ex)
            {
                Console.WriteLine($"Неверные данные массива в {ex.I} строке, {ex.J} столбце");
            }        
        }
        static int ArraySum(string[,] array)
        {
            var sum = 0;
            if (array.GetLength(0) != 4 || array.GetLength(1) != 4)
            {
                throw new MyArraySizeException();
            }
            for (int i=0; i<4; i++)
                for(int j=0; j<4; j++)
                {
                    int array_element;
                    try
                    {
                        array_element = Convert.ToInt32(array[i, j]);
                    }
                    catch (Exception)
                    {
                        throw new MyArrayDataException(i+1, j+1);
                    }
                    sum += array_element;
                }
            return sum;
        }
        static void GetEmployees()
        {
            Person[] persons = { 
                new Person("Соколов Борис Иванович", "Главный редактор", "sokolov@yandex.ru", 89995556677, 3000.7, 54),
                new Person("Ананьява Мария Дмитриевна", "Менеджер", "maria@yandex.ru", 83054071122, 2800.0, 41),
                new Person("Мартынов Денис Андреевич", "Бухгалтер", "denis@yandex.ru", 84653576400, 2750.15, 32),
                new Person("Донцова Анастасия Николаевна", "Специалист отдела продаж", "nastya@yandex.ru", 89002005040, 2360.24, 25),
                new Person("Ленина Иветта Григорьевна", "Администратор", "ivetta@yandex.ru", 87136120011, 2900.0, 39)};
            foreach (Person person in persons)
                if (person.Age > 40)
                    person.GetInfo();
        }
    }
}
