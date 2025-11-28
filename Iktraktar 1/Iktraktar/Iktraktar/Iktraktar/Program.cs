using Iktraktar.Models;
using System.Data.SqlTypes;
using System.Net.Http.Headers;
namespace Iktraktar
{
    internal class Program
    {
        /*
         *
         *
         */

        static void Main(string[] args)
        {
            Storage storage = new Storage();
            storage.Add(new Product(1, "Ceruza", 100));
            storage.Add(new Product(2, "Toll", 50));
            storage.Add(new Product(3, "Füzet", 80));

            Console.WriteLine("Raktár rendszer - fejlesztési alap");

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("--- Raktárkezelő ---");
                Console.WriteLine("4 - Készlet növelése");
                Console.WriteLine("5 - Készlet csökkentése");
                Console.WriteLine("0 - Kilépés");
                Console.Write("Választás: ");

                string choice = Console.ReadLine();

                Console.WriteLine();
                switch (choice)
                {
                    case "4":
                        Console.Write("Termék ID: ");
                        int incId = int.Parse(Console.ReadLine());

                        Console.Write("Mennyivel növeljem?: ");
                        int incAmount = int.Parse(Console.ReadLine());

                        IncreaseQuantity(storage, incId, incAmount);
                        break;

                    case "5":
                        Console.Write("Termék ID: ");
                        int decId = int.Parse(Console.ReadLine());

                        Console.Write("Mennyivel csökkentsem?: ");
                        int decAmount = int.Parse(Console.ReadLine());

                        DecreaseQuantity(storage, decId, decAmount);
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Érvénytelen választás!");
                        break;
                }
            }
        }
        static void IncreaseQuantity(Storage storage, int id, int amount)
        {
            var product = storage.FindById(id);

            if (product == null)
            {
                Console.WriteLine("Nincs ilyen termék!");
                return;
            }

            product.Quantity += amount;
            Console.WriteLine($"#{product.Id} {product.Name} új mennyiség: {product.Quantity}");
        }

        static void DecreaseQuantity(Storage storage, int id, int amount)
        {
            var product = storage.FindById(id);

            if (product == null)
            {
                Console.WriteLine("Nincs ilyen termék!");
                return;
            }

            if (product.Quantity < amount)
            {
                Console.WriteLine("Nincs elég készlet!");
                return;
            }

            product.Quantity -= amount;
            Console.WriteLine($"#{product.Id} {product.Name} új mennyiség: {product.Quantity}");
        }
    }
}

