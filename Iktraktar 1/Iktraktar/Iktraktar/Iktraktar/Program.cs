using Iktraktar.Models;
using System;

namespace Iktraktar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1️. Raktár létrehozása és termékek hozzáadása
            Storage storage = new Storage();
            storage.Add(new Product(1, "Ceruza", 100));
            storage.Add(new Product(2, "Toll", 50));
            storage.Add(new Product(3, "Füzet", 80));

            Console.WriteLine("Kezdeti raktár:");
            storage.PrintAllProducts();
            Console.WriteLine();

            // 2️. Első rendelés létrehozása
            Order order1 = new Order(1);
            order1.AddItem(storage.FindById(1)!, 10); // 10 Ceruza
            order1.AddItem(storage.FindById(2)!, 5);  // 5 Toll

            // 3️. Második rendelés létrehozása (nem lesz elég készlet)
            Order order2 = new Order(2);
            order2.AddItem(storage.FindById(3)!, 100); // 100 Füzet → nincs elég készlet

            // 4️. Rendelések feldolgozása
            Console.WriteLine("Feldolgozás 1. rendelés:");
            OrderProcess.ProcessOrder(order1, storage);
            Console.WriteLine();

            Console.WriteLine("Feldolgozás 2. rendelés:");
            OrderProcess.ProcessOrder(order2, storage);
            Console.WriteLine();

            // 5️. Raktár állapotának ellenőrzése feldolgozás után
            Console.WriteLine("Raktár állapota feldolgozás után:");
            storage.PrintAllProducts();
        }
    }
}
