using System;
using System.Linq;

namespace Lab5_15var
{
    class Program
    {
        static readonly Random rnd = new Random();
        const string TestString = "В траве сидел кузнечик! Кузнечик не трогал козявок и дружил с мухом.";

        static void Main()
        {
            Console.Clear();
            while (true)
            {
                Console.Write(@"Лабораторная работа №5. Вариант 15.
1 - Двумерный массив (удалить чётные строки)
2 - Рваный массив (добавить строку в конец)
3 - Строка (удалить слова с одинаковыми началом и концом)
0 - Выход
Выберите задачу: 
");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": RunTaskBinArr(); break;
                    case "2": RunTaskRag(); break;
                    case "3": RunTaskString(); break;
                    case "0": return;
                    default:
                        Console.WriteLine("Неверный выбор. Повторите.");
                        break;
                }
            }
        }

        static void RunTaskBinArr()
        {
            Console.Clear();
            Console.WriteLine("Задача 1. Двумерный массив: удалить все чётные строки.");

            int rows, cols;
            ReadSize("строк", out rows);
            ReadSize("столбцов", out cols);

            int[,] matrix = new int[rows, cols];
            FillBinArr(matrix);

            Console.WriteLine("\nИсходный массив:");
            Print(matrix);

            int[,] result = RemoveEvenRows(matrix);

            Console.WriteLine("\nМассив после удаления чётных строк:");
            if (result.GetLength(0) == 0)
                Console.WriteLine("Массив пуст.");
            else
                Print(result);

            ReturnToMenu();
        }

        static int[,] RemoveEvenRows(int[,] src)
        {
            int rows = src.GetLength(0);
            int cols = src.GetLength(1);

            int newRows = 0;
            for (int i = 0; i < rows; i++)
                if (i % 2 == 0) newRows++;

            int[,] result = new int[newRows, cols];
            int k = 0;
            for (int i = 0; i < rows; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < cols; j++)
                        result[k, j] = src[i, j];
                    k++;
                }
            }
            return result;
        }

        static void RunTaskRag()
        {
            Console.Clear();
            Console.WriteLine("Задача 2. Рваный массив: добавить строку в конец массива.");

            int rows;
            ReadSize("строк", out rows);

            int[][] jagArr = new int[rows][];
            int cols;
            for (int i = 0; i < rows; i++)
            {
                ReadSize($"столбцов в строке {i + 1}", out cols);
                jagArr[i] = new int[cols];
                for (int j = 0; j < cols; j++)
                    jagArr[i][j] = rnd.Next(0, 10);
            }

            Console.WriteLine("\nИсходный рваный массив:");
            Print(jagArr);

            Console.Write("\nВведите длину новой строки: ");
            int newLen;
            while (!int.TryParse(Console.ReadLine(), out newLen) || newLen <= 0)
                Console.Write("Некорректно. Введите положительное целое число: ");

            int[] newRow = new int[newLen];
            for (int j = 0; j < newLen; j++)
                newRow[j] = rnd.Next(0, 10);

            int[][] resultArr = AddRowToEnd(jagArr, newRow);

            Console.WriteLine("\nМассив после добавления строки в конец:");
            Print(resultArr);

            ReturnToMenu();
        }

        static int[][] AddRowToEnd(int[][] src, int[] newRow)
        {
            int[][] result = new int[src.Length + 1][];
            for (int i = 0; i < src.Length; i++)
                result[i] = src[i];
            result[src.Length] = newRow;
            return result;
        }

        static void RunTaskString()
        {
            Console.Clear();
            Console.WriteLine("Задача 3. Строки: удалить слова, начинающиеся и" +
                " заканчивающиеся на один и тот же символ.");

            Console.WriteLine("1 - Ввести строку с клавиатуры");
            Console.WriteLine("2 - Использовать тестовую строку");
            Console.Write("Выберите: ");
            int mode;
            while (!int.TryParse(Console.ReadLine(), out mode) || mode > 2 || mode < 1)
                Console.Write("Некорректно. Повторите: ");
            string input;
            if (mode == 2)
            {
                input = TestString;
            }
            else
            {
                Console.Write("Введите строку: ");
                input = Console.ReadLine();
            }

            if (string.IsNullOrWhiteSpace(input))
            {
                do
                {
                    Console.WriteLine("Строка пуста.");
                    Console.Write("Введите строку: ");
                    input = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(input));
            }

            Console.WriteLine("\nИсходная строка:");
            Console.WriteLine(input);

            string result = RemoveWordsX_X(input);

            Console.WriteLine("\nРезультат:");
            Console.WriteLine(string.IsNullOrWhiteSpace(result) ? "Строка пуста." : result);

            ReturnToMenu();
        }

        static string RemoveWordsX_X(string input)
        {
            string[] words = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string result = "";
            bool bigNext = false;
            for (int i = 0; i < words.Length; i++)
            {
                string w = words[i];

                int end = w.Length - 1;
                while (end >= 0 && !char.IsLetter(w[end]))
                    end--;

                string core = w.Substring(0, end + 1);
                string postfix = w.Substring(end + 1);

                char firstLetter = char.ToLower(core[0]);
                char lastLetter = char.ToLower(core[core.Length - 1]);

                if (core.Length == 1 || firstLetter != lastLetter)
                {
                    if (bigNext)
                    {
                        w = char.ToUpper(w[0]) + w.Substring(1);
                        bigNext = false;
                    }
                    if (result == " ")
                        result = "";
                    result += w + " ";
                }
                else
                {
                    if (char.IsUpper(core[0]))
                        bigNext = true;
                    if (result.Length > 0)
                        result = result.Remove(result.Length - 1);
                    if (postfix.Length > 0)
                        result += postfix + " ";
                    else 
                        result += " ";
                }
            }
            return result;
        }

        static void ReadSize(string str, out int value)
        {
            Console.Write($"Введите количество {str}: ");
            while (!int.TryParse(Console.ReadLine(), out value) || value <= 0)
                Console.Write("Некорректно. Введите положительное целое: ");
        }

        static void FillBinArr(int[,] matrix)
        {
            Console.Write("Заполнить случайно? (1 - да, 2 - вручную): ");
            int mode;
            while (!int.TryParse(Console.ReadLine(), out mode) || mode > 2 || mode < 1)
                Console.Write("Некорректно. Повторите: ");
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (mode == 2)
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        Console.Write($"[{i},{j}] = ");
                        while (!int.TryParse(Console.ReadLine(), out matrix[i, j]))
                            Console.Write("Некорректно. Повторите: ");
                    }
                }
            }
            else
            {
                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < cols; j++)
                        matrix[i, j] = rnd.Next(0, 100);
            }
        }

        static void Print(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                    Console.Write($"{matrix[i, j],5}");
                Console.WriteLine();
            }
        }

        static void Print(int[][] jag)
        {
            for (int i = 0; i < jag.Length; i++)
            {
                for (int j = 0; j < jag[i].Length; j++)
                    Console.Write($"{jag[i][j],4}");
                Console.WriteLine();
            }
        }

        static void ReturnToMenu()
        {
            Console.WriteLine("\nНажмите Enter для возврата в меню...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}