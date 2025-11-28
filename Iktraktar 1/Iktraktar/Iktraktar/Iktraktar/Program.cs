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


            int id = 0;
            storage.FindById(id);

            Console.WriteLine("Raktár rendszer - fejlesztési alap");
        }
        
          public static void PrintTable(IEnumerable<Product> products)
            {
                Console.WriteLine("ID | Név     | Készlet");
                Console.WriteLine("------------------------");
                foreach (var p in products)
                {
                    Console.WriteLine($"{p.Id}  | {p.Name,-7} | {p.Quantity}");
                }
            }
 

       
    }
}

