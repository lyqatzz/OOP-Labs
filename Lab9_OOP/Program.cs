using System;

namespace Lab9_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ЧАСТЬ 1. Класс Money и сравнение");
            Console.WriteLine("--------------------------------");
            Money m1 = new Money(10, 50);
            Money m2 = new Money(10, 50);
            Money m3 = new Money(5, 0);

            Console.Write("m1: "); m1.Print();
            Console.Write("m2: "); m2.Print();
            Console.Write("m3: "); m3.Print();

            Console.WriteLine($"\nСравнение m1 и m2 (метод): {m1.CompareMethod(m2)}");
            Console.WriteLine($"Сравнение m1 и m3 (статический): {Money.CompareStatic(m1, m3)}");

            Console.WriteLine("\nЧАСТЬ 2. Перегрузка операторов");
            Console.WriteLine("-------------------------------");
            m1++;
            Console.Write("m1 после ++: "); m1.Print();

            m3--;
            Console.Write("m3 после --: "); m3.Print();

            int rub = m1;
            double kop = (double)m1;
            Console.WriteLine($"Приведение m1 к int (рубли): {rub}");
            Console.WriteLine($"Приведение m1 к double (копейки): {kop:F2}");

            Money res1 = m1 - 50;
            Console.Write("m1 - 50 копеек: "); res1.Print();

            Money res2 = 100 - m1;
            Console.Write("100 - m1 (копеек): "); res2.Print();

            Console.WriteLine("\nЧАСТЬ 3. Коллекция MoneyArray");
            Console.WriteLine("------------------------------");

            bool isRandom;
            while (true)
            {
                Console.Write("Заполнить массив случайно? (1 - да, 0 - нет): ");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    isRandom = true;
                    break;
                }
                else if (input == "0")
                {
                    isRandom = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Ошибка! Введите только 1 или 0.");
                }
            }

            Console.Write("Введите количество элементов в массиве: ");
            int size = int.Parse(Console.ReadLine());

            MoneyArray wallet = new MoneyArray(size, isRandom);
            wallet.PrintAll();

            int minNum = wallet.FindMinIndex();
            Console.WriteLine($"\nНомер минимального элемента: {minNum}");
            Console.Write("Самый маленький элемент: ");
            wallet[minNum - 1].Print();

            Console.WriteLine($"\nВсего создано объектов Money: {Money.count}");
            Console.ReadKey();
        }
    }
}