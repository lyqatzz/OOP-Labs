using System;

namespace Lab10_OOP
{
    class Program
    {
        /*
   ДИАГРАММА КЛАССОВ
   
   +----------------------+
   |    <<interface>>     |
   |        IInit         |
   +----------------------+
   | + Init()             |
   | + RandomInit()       |
   +----------+-----------+
              |
              | реализует
+----------------------------------+
|         abstract Engine          |
+----------------------------------+
| # name: string                   |
| # power: int                     |
+----------------------------------+
| + Show() : virtual               |
| + Init() : virtual               |
| + RandomInit() : virtual         |
| + CompareTo(obj) : int           |
| + Equals(obj) : bool             |
+----------------------------------+
              |
     +--------+--------+
     |                 |
+----v-----+      +----v-----+
|   ICE    |      | Turbojet |
+----------+      +----------+
| # volume |      | - thrust |
+----------+      +----------+
     |
+----v-----+
|  Diesel  |
+----------+
| - torque |
+----------+
*/
        static void Main(string[] args)
        {
            Console.WriteLine("ЧАСТЬ 1. Иерархия классов");
            Console.WriteLine("-------------------------");
            Engine[] engines = new Engine[5];
            engines[0] = new ICE("Базовый ДВС", 150, 2.0);
            engines[1] = new Diesel("Тяжелый дизель", 400, 6.5, 800);
            engines[2] = new Turbojet("Авиационный", 5000, 120);
            engines[3] = new ICE("Малолитражка", 100, 1.4);
            engines[4] = new Diesel("Грузовик", 300, 4.0, 600);

            Console.WriteLine("Массив двигателей:");
            foreach (Engine e in engines) e.Show();

            Console.WriteLine("\nЧАСТЬ 2. Сортировка (IComparable)");
            Console.WriteLine("---------------------------------");
            Array.Sort(engines);
            Console.WriteLine("После сортировки по мощности:");
            foreach (Engine e in engines) e.Show();

            Console.WriteLine("\nЧАСТЬ 3. Динамическая идентификация (is, as)");
            Console.WriteLine("-------------------------------------------");
            int dieselCount = 0;
            foreach (Engine e in engines)
            {
                if (e is Diesel)
                {
                    dieselCount++;
                    Diesel d = e as Diesel;
                    Console.WriteLine($"Найден дизель: {d.Name}, Момент: {d.Torque} Н·м");
                }
            }
            Console.WriteLine($"Всего дизелей: {dieselCount}");

            Console.WriteLine("\nЧАСТЬ 4. Интерфейс IInit");
            Console.WriteLine("------------------------");
            IInit[] inits = new IInit[3];
            inits[0] = new ICE();
            inits[1] = new Turbojet();
            inits[2] = new Car();

            foreach (IInit item in inits)
            {
                item.RandomInit();
                if (item is Engine eng) eng.Show();
                else if (item is Car car) car.Show();
            }

            Console.WriteLine("\nЧАСТЬ 5. Клонирование");
            Console.WriteLine("---------------------");
            Diesel original = new Diesel("Оригинал", 200, 3.0, 400);
            Diesel clone = new Diesel(original);

            Console.WriteLine("Оригинал:");
            original.Show();
            Console.WriteLine("Клон:");
            clone.Show();

            original.Name = "Измененный";
            Console.WriteLine("\nПосле изменения оригинала:");
            Console.WriteLine("Оригинал:");
            original.Show();
            Console.WriteLine("Клон:");
            clone.Show();

            Console.ReadKey();
        }
    }
}