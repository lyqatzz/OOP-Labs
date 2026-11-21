using System;

namespace Lab11_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("ЛАБОРАТОРНАЯ РАБОТА №11. КОЛЛЕКЦИИ");

            CollectionsDemo.RunNonGeneric();
            CollectionsDemo.RunGeneric();
            CollectionsDemo.CompareTyping();

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}