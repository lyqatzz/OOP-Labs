using Lab11_OOP;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab11_OOP
{
    public static class CollectionsDemo
    {
        public static void RunNonGeneric()
        {
            Console.WriteLine("ЧАСТЬ 1. НЕПАРАМЕТРИЗОВАННЫЕ КОЛЛЕКЦИИ");
            Console.WriteLine("---------------------------------------");

            Console.WriteLine("\nArrayList");
            Console.WriteLine("----------");
            ArrayList list = new ArrayList();
            list.Add(new ICE("V8", 150, 2.0));
            list.Add(new Diesel("TDI", 400, 6.5, 800));
            list.Add(new Turbojet("Авиа", 5000, 120));
            list.Add(new Car { Brand = "Lada" });

            Console.WriteLine($"Count = {list.Count}, Capacity = {list.Capacity}");
            foreach (object item in list)
            {
                if (item is Engine eng) eng.Show();
                else if (item is Car car) car.Show();
                else Console.WriteLine("Неизвестный объект");
            }

            Console.WriteLine($"\nИндекс дизеля: {list.IndexOf(list[1])}");
            list.RemoveAt(2);
            Console.WriteLine($"После RemoveAt(2) Count = {list.Count}");

            Console.WriteLine("\nHashtable");
            Console.WriteLine("---------");
            Hashtable table = new Hashtable();
            table["V8"] = new ICE("V8", 150, 2.0);
            table["TDI"] = new Diesel("TDI", 400, 6.5, 800);
            table["Авиа"] = new Turbojet("Авиа", 5000, 120);

            Console.WriteLine($"Содержит ключ 'TDI': {table.ContainsKey("TDI")}");
            Console.WriteLine($"Содержит ключ 'XXX': {table.ContainsKey("XXX")}");

            foreach (DictionaryEntry entry in table)
            {
                Engine e = entry.Value as Engine;
                Console.Write($"Ключ: {entry.Key}, ");
                e?.Show();
            }

            Console.WriteLine("\nSortedList");
            Console.WriteLine("-----------");
            SortedList sorted = new SortedList();
            sorted["V8"] = new ICE("V8", 150, 2.0);
            sorted["TDI"] = new Diesel("TDI", 400, 6.5, 800);
            sorted["Авиа"] = new Turbojet("Авиа", 5000, 120);

            Console.WriteLine("Ключи в SortedList (по возрастанию):");
            foreach (object key in sorted.Keys)
                Console.WriteLine($"  {key}");

            Console.WriteLine("\nДоступ по ключу 'TDI':");
            ((Engine)sorted["TDI"]).Show();
            Console.WriteLine("\nДоступ по индексу 0:");
            ((Engine)sorted.GetByIndex(0)).Show();

            Console.WriteLine("\nStack (LIFO)");
            Console.WriteLine("-------------");
            Stack stack = new Stack();
            stack.Push(new ICE("Первый", 100, 1.4));
            stack.Push(new Diesel("Второй", 200, 3.0, 400));
            stack.Push(new Turbojet("Третий", 300, 80));

            Console.WriteLine("Peek (верхний без удаления):");
            ((Engine)stack.Peek()).Show();

            Console.WriteLine("Извлечение (Pop):");
            while (stack.Count > 0)
                (stack.Pop() as Engine)?.Show();

            Console.WriteLine("\nQueue (FIFO)");
            Console.WriteLine("-------------");
            Queue queue = new Queue();
            queue.Enqueue(new ICE("Первый", 100, 1.4));
            queue.Enqueue(new Diesel("Второй", 200, 3.0, 400));
            queue.Enqueue(new Turbojet("Третий", 300, 80));

            Console.WriteLine("Извлечение (Dequeue):");
            while (queue.Count > 0)
                (queue.Dequeue() as Engine)?.Show();
        }

        public static void RunGeneric()
        {
            Console.WriteLine("ЧАСТЬ 2. ПАРАМЕТРИЗОВАННЫЕ КОЛЛЕКЦИИ");
            Console.WriteLine("-------------------------------------");

            Console.WriteLine("\nList<Engine>");
            Console.WriteLine("------------");
            List<Engine> engines = new List<Engine>
            {
                new ICE("V8", 150, 2.0),
                new Diesel("TDI", 400, 6.5, 800),
                new Turbojet("Авиа", 5000, 120),
                new Diesel("Грузовик", 300, 4.0, 600),
            };

            Console.WriteLine($"Count = {engines.Count}");
            foreach (Engine e in engines) e.Show();

            engines.Sort();
            Console.WriteLine("\nПосле Sort() по мощности:");
            foreach (Engine e in engines) e.Show();

            Engine found = engines.Find(e => e is Diesel && ((Diesel)e).Torque > 500);
            Console.WriteLine($"\nПервый дизель с моментом > 500: {found?.Name}");

            Console.WriteLine("\nDictionary<string, Engine>");
            Console.WriteLine("--------------------------");
            Dictionary<string, Engine> dict = new Dictionary<string, Engine>
            {
                ["V8"] = new ICE("V8", 150, 2.0),
                ["TDI"] = new Diesel("TDI", 400, 6.5, 800),
                ["Авиа"] = new Turbojet("Авиа", 5000, 120),
            };

            if (dict.TryGetValue("TDI", out Engine tdi))
                tdi.Show();

            foreach (KeyValuePair<string, Engine> kvp in dict)
            {
                Console.Write($"Ключ: {kvp.Key}, ");
                kvp.Value.Show();
            }

            Console.WriteLine("\nSortedDictionary<string, Engine>");
            Console.WriteLine("--------------------------------");
            SortedDictionary<string, Engine> sortedDict = new SortedDictionary<string, Engine>
            {
                ["V8"] = new ICE("V8", 150, 2.0),
                ["TDI"] = new Diesel("TDI", 400, 6.5, 800),
                ["Авиа"] = new Turbojet("Авиа", 5000, 120),
            };

            foreach (var kvp in sortedDict)
                Console.WriteLine($"  {kvp.Key} → {kvp.Value.Name}");

            Console.WriteLine("\nLinkedList<Engine>");
            Console.WriteLine("------------------");
            LinkedList<Engine> linked = new LinkedList<Engine>();
            linked.AddLast(new ICE("Первый", 100, 1.4));
            linked.AddFirst(new Turbojet("Нулевой", 300, 80));
            linked.AddLast(new Diesel("Последний", 200, 3.0, 400));

            Console.WriteLine("Обход вперёд:");
            for (var node = linked.First; node != null; node = node.Next)
                node.Value.Show();

            Console.WriteLine("Обход назад:");
            for (var node = linked.Last; node != null; node = node.Previous)
                node.Value.Show();

            Console.WriteLine("\nStack<Engine> (LIFO)");
            Console.WriteLine("--------------------");
            Stack<Engine> stack = new Stack<Engine>();
            stack.Push(new ICE("Первый", 100, 1.4));
            stack.Push(new Diesel("Второй", 200, 3.0, 400));
            stack.Push(new Turbojet("Третий", 300, 80));

            while (stack.Count > 0)
                stack.Pop().Show();

            Console.WriteLine("\nQueue<Engine> (FIFO)");
            Console.WriteLine("--------------------");
            Queue<Engine> queue = new Queue<Engine>();
            queue.Enqueue(new ICE("Первый", 100, 1.4));
            queue.Enqueue(new Diesel("Второй", 200, 3.0, 400));
            queue.Enqueue(new Turbojet("Третий", 300, 80));

            while (queue.Count > 0)
                queue.Dequeue().Show();
        }

        public static void CompareTyping()
        {
            Console.WriteLine("ЧАСТЬ 3. СРАВНЕНИЕ ТИПИЗАЦИИ");
            Console.WriteLine("----------------------------");

            ArrayList badList = new ArrayList();
            badList.Add(new ICE("V8", 150, 2.0));
            badList.Add("это строка, а не двигатель");
            Console.WriteLine("ArrayList: добавлена строка — ошибка будет только при приведении.");

            List<Engine> goodList = new List<Engine>();
            goodList.Add(new ICE("V8", 150, 2.0));
            Console.WriteLine("List<Engine>: компилятор не даст добавить строку.");
        }
    }
}