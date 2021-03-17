using System;
using System.Collections;

namespace Lesson_7
{
    class Program
    {
        public class InitSizeException : Exception { }
        public class InvalidCellException : Exception { }
        public class ForcedAction : Exception
        {
            public int X;
            public int Y;

            public ForcedAction(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        static int FIELD_SIZE;
        static int WIN_SIZE;

        static int[,] field;

        static char PLAYER_DOT = 'X';
        static char AI_DOT = 'O';
        static char EMPTY_DOT = '.';

        static int[] last_step = new int[1];
        static void Main(string[] args)
        {
            //1. Написать любое приложение, произвести его сборку с помощью MSBuild, осуществить декомпиляцию с помощью dotPeek, 
            //внести правки в программный код и пересобрать приложение.
            Console.WriteLine("Добро пожаловать в игру \"крестики-нолики\"!");

            //2. Переделать проверку победы, чтобы она не была реализована просто набором условий, например, с использованием циклов.
            //3. *Попробовать переписать логику проверки победы, чтобы она работала для поля 5х5 и количества фишек 4.
            //Очень желательно не делать это просто набором условий для каждой из возможных ситуаций;
            //4. ***Доработать искусственный интеллект, чтобы он мог блокировать ходы игрока

            //Инициализация размера поля
            while (true)
            {
                try
                {
                    InitFieldSize();
                    break;
                }
                catch (InitSizeException)
                {
                    Console.WriteLine("Неверный размер! Введите число больше 3.");
                    continue;
                }
            }
            //Инициализация размера ряда для победы
            while (true)
            {
                try
                {
                    InitWinSize();
                    break;
                }
                catch (InitSizeException)
                {
                    Console.WriteLine($"Неверный размер! Введите число от 3 до {FIELD_SIZE}.");
                    continue;
                }
            }
            //Инициализация и отображение поля
            InitField();
            PrintField();

            //Игровой процесс
            while (true)
            {
                PlayerStep(out last_step);
                PrintField();
                if (CheckWin(1))
                {
                    Console.WriteLine("Player Win!");
                    break;
                }
                if (IsFieldFull())
                {
                    Console.WriteLine("DRAW");
                    break;
                }
                AiStep(out last_step);
                PrintField();
                if (CheckWin(-1))
                {
                    Console.WriteLine("SkyNet Win!");
                    break;
                }
                if (IsFieldFull())
                {
                    Console.WriteLine("DRAW");
                    break;
                }
            }
            Console.ReadLine();
        }
        //Метод инициализации размера поля
        private static void InitFieldSize()
        {
            Console.WriteLine("Введите размер поля:");
            var size = Console.ReadLine();
            try
            {
                FIELD_SIZE = Convert.ToInt32(size);
                if (FIELD_SIZE < 3)
                {
                    throw new InitSizeException();
                }
                field = new int[FIELD_SIZE, FIELD_SIZE];
            }
            catch (Exception)
            {
                throw new InitSizeException();
            }
        }
        //Метод инициализации размера ряда для победы
        private static void InitWinSize()
        {
            if (FIELD_SIZE == 3)
            {
                WIN_SIZE = FIELD_SIZE;
                return;
            }

            Console.WriteLine("Введите размер ряда для победы:");
            var size = Console.ReadLine();
            try
            {
                WIN_SIZE = Convert.ToInt32(size);
                if (WIN_SIZE > FIELD_SIZE || WIN_SIZE < 3)
                {
                    throw new InitSizeException();
                }
            }
            catch (Exception)
            {
                throw new InitSizeException();
            }
        }
        //Метод инициализации поля
        private static void InitField()
        {
            for (int i = 0; i < FIELD_SIZE; i++)
            {
                for (int j = 0; j < FIELD_SIZE; j++)
                {
                    field[i, j] = 0;
                }
            }
        }
        //Метод отображения поля с переводом чисел в массиве в игровые символы
        private static void PrintField()
        {
            PrintFrame();
            for (int i = 0; i < FIELD_SIZE; i++)
            {
                Console.Write("|");
                for (int j = 0; j < FIELD_SIZE; j++)
                {
                    Console.Write(TranslateSym(field[i, j]) + "|");
                }
                Console.WriteLine();
            }
            PrintFrame();
        }
        //Метод отображения рамки, подстроенной под размер поля
        private static void PrintFrame()
        {
            for (int i = 0; i < FIELD_SIZE * 2 + 1; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }
        //Метод смены значения в ячейке массива поля
        private static void SetSym(int y, int x, int sym)
        {
            field[y, x] = sym;
        }
        //Метод перевода чисел массива в игровые символы
        private static char TranslateSym(int sym_int)
        {
            char sym_char;
            switch (sym_int)
            {
                case 1:
                    sym_char = PLAYER_DOT;
                    break;
                case -1:
                    sym_char = AI_DOT;
                    break;
                case 0:
                default:
                    sym_char = EMPTY_DOT;
                    break;
            }
            return sym_char;
        }
        //Метод проверки доступности ячейки
        private static bool IsCellValid(int y, int x)
        {
            if (x < 0 || y < 0 || x > FIELD_SIZE - 1 || y > FIELD_SIZE - 1)
            {
                return false;
            }

            return field[y, x] == 0;
        }
        //Метод проверки заполненности поля
        private static bool IsFieldFull()
        {
            for (int i = 0; i < FIELD_SIZE; i++)
            {
                for (int j = 0; j < FIELD_SIZE; j++)
                {
                    if (field[i, j] == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        //Метод шага игрока
        private static void PlayerStep(out int[] step)
        {
            int x;
            int y;
            while (true)
            {
                Console.WriteLine($"Введите координаты X Y (1-{FIELD_SIZE})");
                try
                {
                    x = Int32.Parse(Console.ReadLine()) - 1;
                    y = Int32.Parse(Console.ReadLine()) - 1;
                    if (x > FIELD_SIZE || x < 0 || y > FIELD_SIZE || y < 0)
                    {
                        throw new Exception();
                    }
                    if (!IsCellValid(y, x))
                    {
                        throw new InvalidCellException();
                    }
                    break;
                }
                catch (InvalidCellException)
                {
                    Console.WriteLine("Ячейка уже занята!");
                    continue;
                }
                catch (Exception)
                {
                    Console.WriteLine("Неверно введены координаты!");
                    continue;
                }
            }
            SetSym(y, x, 1);
            //Запоминаем шаг для использвоания в проверке победы и хода ИИ
            step = GetStep(y, x);
        }
        //Метод перевода координат в точку
        private static int[] GetStep(int x, int y)
        {
            int[] step = { y, x };
            return step;
        }
        //Метод шага ИИ
        private static void AiStep(out int[] step)
        {
            int x;
            int y;
            (y, x) = GetAiPriority();
            SetSym(y, x, -1);
            //Запоминаем шаг для использвоания в проверке победы
            step = GetStep(y, x);
        }
        //Метод проверки победы
        private static bool CheckWin(int mod)
        {
            //проверка по горизонтали
            int check_sum_h = 0;
            //проверка по вертикали
            int check_sum_v = 0;
            //проверка по диагоналям
            int check_sum_d_main = 0;
            int check_sum_d_add = 0;

            //Для проверки используются функции суммирования значений вдоль строк и соотношения суммы к числу для победы
            
            for (int i = 0; i < FIELD_SIZE; i++)
            {                
                check_sum_h = (check_sum_h + field[last_step[1], i]) * (field[last_step[1], i] == mod ? 1 : 0);
                check_sum_v = (check_sum_v + field[i, last_step[0]]) * (field[i, last_step[0]] == mod ? 1 : 0);
                if (Math.Abs(check_sum_h) == WIN_SIZE || Math.Abs(check_sum_v) == WIN_SIZE)
                {
                    return true;
                }
            }
            for (int i = Math.Abs(last_step[0] - last_step[1]); i < FIELD_SIZE; i++)
            {
                int current_cell = field[i - Math.Max(0, last_step[0] - last_step[1]), i - Math.Max(0, last_step[1] - last_step[0])];
                check_sum_d_main = (check_sum_d_main + current_cell) * (current_cell == mod ? 1 : 0);
                if (Math.Abs(check_sum_d_main) == WIN_SIZE)
                {
                    return true;
                }
            }
            for (int i = Math.Max(0, last_step[0] + last_step[1] - FIELD_SIZE + 1); i < Math.Min(FIELD_SIZE, last_step[0] + last_step[1] + 1); i++)
            {
                int current_cell = field[i, last_step[0] + last_step[1] - i];
                check_sum_d_add = (check_sum_d_add + current_cell) * (current_cell == mod ? 1 : 0);
                if (Math.Abs(check_sum_d_add) == WIN_SIZE)
                {
                    return true;
                }
            }

            return false;
        }
        //Метод выбора приоритета хода для ИИ
        private static (int, int) GetAiPriority()
        {
            int x;
            int y;
            if (FirstPriority(-1, out x, out y))
            {
                return (x, y);
            }
            if (FirstPriority(1, out x, out y))
            {
                return (x, y);
            }

            Random random = new Random();
            do
            {
                x = random.Next(0, FIELD_SIZE);
                y = random.Next(0, FIELD_SIZE);
            } while (!IsCellValid(y, x));
            return (y, x);
        }
        //Метод главного приоритета для ИИ, когда возможна победа одной из сторон (не совершенен)
        private static bool FirstPriority(int mod, out int x, out int y)
        {
            x = 0;
            y = 0;

            int sum_d_main = 0;
            int sum_d_add = 0;
            (int, int) sum_to = (0, 0);
            (int, int) sum_re = (0, 0);
            for (int i = 0; i < FIELD_SIZE; i++)
            {
                try
                {
                    sum_to = HorVerCheck_Priority(mod, 1, i, sum_to.Item1, sum_to.Item2);
                    sum_re = HorVerCheck_Priority(mod, -1, FIELD_SIZE - 1 - i, sum_re.Item1, sum_re.Item2);
                }
                catch (ForcedAction ex)
                {
                    x = ex.X;
                    y = ex.Y;
                    return true;
                }
            }
            for (int i = Math.Abs(last_step[0] - last_step[1]); i < FIELD_SIZE; i++)
            {
                try
                {
                    sum_d_main = MainDiagCheck_Priority(mod, i, sum_d_main);
                }
                catch (ForcedAction ex)
                {
                    x = ex.X;
                    y = ex.Y;
                    return true;
                }
            }
            for (int i = Math.Max(0, last_step[0] + last_step[1] - FIELD_SIZE + 1); i < Math.Min(FIELD_SIZE, last_step[0] + last_step[1] + 1); i++)
            {
                try
                {
                    sum_d_add = AddDiagCheck_Priority(mod, i, sum_d_add);
                }
                catch (ForcedAction ex)
                {
                    x = ex.X;
                    y = ex.Y;
                    return true;
                }
            }
            return false;

        }
        //Метод проверки возможности победы для отдельно взятой суммы значений определенного ряда
        private static void CheckWinProbability(int mod, int sum, int y, int x, int vector_y, int vector_x)
        {
            if (sum == (WIN_SIZE - 1) * mod && field[y, x] == 0)
            {
                throw new ForcedAction(y, x);
            }
            if (y + vector_y < FIELD_SIZE && y + vector_y >= 0 && x + vector_x < FIELD_SIZE && x + vector_x >=0)
            {
                if (field[y + vector_y, x + vector_x] == mod && sum == (WIN_SIZE - 2) * mod && field[y, x] == 0)
                {
                    throw new ForcedAction(y, x);
                }
            }
        }
        //Метод проверки по горизонтали и вертикали
        private static (int, int) HorVerCheck_Priority(int mod, int re_mod, int i, int sum_h, int sum_v)
        {
            CheckWinProbability(mod, sum_h, last_step[1], i, 0, re_mod);
            sum_h = (sum_h + field[last_step[1], i]) * Math.Abs(field[last_step[1], i]);
            CheckWinProbability(mod, sum_v, i, last_step[0], re_mod, 0);
            sum_v = (sum_v + field[i, last_step[0]]) * Math.Abs(field[i, last_step[0]]);
            return (sum_h, sum_v);
        }
        //Метод проверки по главной диагонали
        private static int MainDiagCheck_Priority(int mod, int i, int sum_d)
        {
            CheckWinProbability(mod, sum_d, i - Math.Max(0, last_step[0] - last_step[1]), i - Math.Max(0, last_step[1] - last_step[0]), 1, 1);
            int current_cell = field[i - Math.Max(0, last_step[0] - last_step[1]), i - Math.Max(0, last_step[1] - last_step[0])];
            sum_d = (sum_d + current_cell) * Math.Abs(current_cell);
            return sum_d;
        }
        //Метод проверки по побочной диагонали
        private static int AddDiagCheck_Priority(int mod, int i, int sum_d)
        {
            CheckWinProbability(mod, sum_d, i, last_step[0] + last_step[1] - i, 1, -1);
            int current_cell = field[i, last_step[0] + last_step[1] - i];
            sum_d = (sum_d + current_cell) * Math.Abs(current_cell);
            return sum_d;
        }
    }
}
