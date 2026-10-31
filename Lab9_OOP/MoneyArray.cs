using System;

namespace Lab9_OOP
{
    public class MoneyArray
    {
        private Money[] arr;

        public MoneyArray()
        {
            arr = new Money[0];
        }

        public MoneyArray(int size, bool isRandom)
        {
            arr = new Money[size];
            Random rnd = new Random();

            for (int i = 0; i < size; i++)
            {
                if (isRandom)
                {
                    arr[i] = new Money(rnd.Next(0, 1000), rnd.Next(0, 100));
                }
                else
                {
                    Console.WriteLine($"Элемент {i + 1}:");
                    Console.Write("  Рубли: ");
                    int r = int.Parse(Console.ReadLine());
                    Console.Write("  Копейки: ");
                    int k = int.Parse(Console.ReadLine());
                    arr[i] = new Money(r, k);
                }
            }
        }

        public Money this[int index]
        {
            get
            {
                if (index < 0 || index >= arr.Length)
                    throw new ArgumentException("Выход за границы массива!");
                return arr[index];
            }
            set
            {
                if (index < 0 || index >= arr.Length)
                    throw new ArgumentException("Выход за границы массива!");
                arr[index] = value;
            }
        }

        public void PrintAll()
        {
            if (arr.Length == 0)
            {
                Console.WriteLine("Массив пуст.");
                return;
            }
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"[{i+1}-й элемент] ");
                arr[i].Print();
            }
        }

        public int FindMinIndex()
        {
            if (arr.Length == 0) return -1;

            int minIndex = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                int currentTotal = arr[i].Rubles * 100 + arr[i].Kopeks;
                int minTotal = arr[minIndex].Rubles * 100 + arr[minIndex].Kopeks;

                if (currentTotal < minTotal)
                    minIndex = i;
            }
            return minIndex + 1;
        }
    }
}