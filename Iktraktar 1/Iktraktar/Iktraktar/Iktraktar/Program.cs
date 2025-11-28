using Iktraktar.Models;
using System;

namespace Iktraktar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Storage storage = new Storage();
            string filePath = "raktar.csv";

            

            while (true)
            {
                Console.WriteLine("\n=== Raktár menü ===");
                Console.WriteLine("1 - Termékek listázása");
                Console.WriteLine("9 - Raktár betöltése CSV-ből");
                Console.WriteLine("10 - Raktár mentése CSV-be");
                Console.WriteLine("0 - Kilépés");
                Console.Write("Válassz egy menüpontot: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\nRaktár tartalma:");
                        foreach (var p in storage.FindAll(""))
                        {
                            Console.WriteLine(p);
                        }
                        break;

                    case "9":
                        storage.Load(filePath);
                        Console.WriteLine($"\nRaktár betöltve: {filePath}");
                        break;

                    case "10":
                        storage.Save(filePath);
                        Console.WriteLine($"\nRaktár mentve: {filePath}");
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Érvénytelen menüpont.");
                        break;
                }
            }
        }
    }
}
