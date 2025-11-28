using Iktraktar.Models;
using System;

namespace Iktraktar
{
    internal class Program
    {
        // Globális változó az automatikus rendelés azonosítókhoz
        static int nextOrderId = 1;

        static void Main(string[] args)
        {
            // 1️. Raktár létrehozása és termékek hozzáadása
            Storage storage = new Storage();    
            storage.Add(new Product(1, "Ceruza", 100));
            storage.Add(new Product(2, "Toll", 50));
            storage.Add(new Product(3, "Füzet", 80));

            bool running = true;

            while (running)
            {
                Console.WriteLine("\n--- Raktárkezelő ---");
                Console.WriteLine("1. Termékek listázása");
                Console.WriteLine("2. Rendelés létrehozása (kivonás)");
                Console.WriteLine("3. Készlet módosítása (hozzáadás / kivonás)");
                Console.WriteLine("4. Kilépés");
                Console.Write("Válassz menüpontot: ");

                string choice = Console.ReadLine()!;

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\nRaktár tartalma:");
                        storage.PrintAllProducts();
                        break;

                    case "2":
                        CreateOrder(storage);
                        break;

                    case "3":
                        ModifyStock(storage);
                        break;

                    case "4":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Hibás menüpont!");
                        break;
                }
            }
        }

        // Rendelés létrehozása
        static void CreateOrder(Storage storage)
        {
            // Automatikus rendelés azonosító
            Order order = new Order(nextOrderId);
            Console.WriteLine($"\nRendelés létrehozva. Order ID: {nextOrderId}");
            nextOrderId++;

            bool addingItems = true;

            while (addingItems)
            {
                Console.WriteLine("\n--- Termék felvétele a rendeléshez ---");
                storage.PrintAllProducts();

                Console.Write("Termék ID: ");
                int productId = int.Parse(Console.ReadLine()!);

                var product = storage.FindById(productId);

                if (product == null)
                {
                    Console.WriteLine("Nincs ilyen termék!");
                    continue;
                }

                Console.Write("Mennyiség: ");
                int qty = int.Parse(Console.ReadLine()!);

                order.AddItem(product, qty);

                Console.Write("További termék? (i/n): ");
                string cont = Console.ReadLine()!;
                if (cont.ToLower() != "i") addingItems = false;
            }

            Console.WriteLine("\n--- Rendelés feldolgozása ---");
            OrderProcess.ProcessOrder(order, storage);
        }

        // Készlet módosítása
        static void ModifyStock(Storage storage)
        {
            Console.WriteLine("\n--- Készlet módosítása ---");
            storage.PrintAllProducts();

            Console.Write("Termék ID: ");
            int id = int.Parse(Console.ReadLine()!);

            var product = storage.FindById(id);

            if (product == null)
            {
                Console.WriteLine("Nincs ilyen termék!");
                return;
            }

            Console.WriteLine("1. Hozzáadás a készlethez");
            Console.WriteLine("2. Kivonás a készletből");
            Console.Write("Választás: ");

            string action = Console.ReadLine()!;

            Console.Write("Mennyiség: ");
            int amount = int.Parse(Console.ReadLine()!);

            switch (action)
            {
                case "1":
                    product.Quantity += amount;
                    Console.WriteLine($"Készlet frissítve! Új mennyiség: {product.Quantity}");
                    break;

                case "2":
                    if (product.Quantity < amount)
                    {
                        Console.WriteLine("Nincs ennyi a készleten!");
                    }
                    else
                    {
                        product.Quantity -= amount;
                        Console.WriteLine($"Készlet frissítve! Új mennyiség: {product.Quantity}");
                    }
                    break;

                default:
                    Console.WriteLine("Hibás művelet!");
                    break;
            }
        }
    }
}
