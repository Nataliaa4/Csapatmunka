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
        }
    }
}
