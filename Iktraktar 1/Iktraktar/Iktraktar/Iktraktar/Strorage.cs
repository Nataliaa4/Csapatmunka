using Iktraktar.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Iktraktar.Models
{
    internal class Storage : ISearchable<Product>
    {
        private List<Product> items = new List<Product>();
        public void Add (Product product)
        {
            items.Add(product);
        }
        public Product? FindById(int id)
        {
            /*return items.Find(x => x.Id == id);*/
            foreach (var item in items) 
            {
                if(item.Id == id) return item;
            }
            return null;
        }
        public IEnumerable<Product> FindAll(string name)
        {
            List<Product> searchedProducts = new List<Product>();
            foreach (Product product in items)
            {
                if(product.Name.Contains(name, StringComparison.CurrentCultureIgnoreCase))
                {
                    searchedProducts.Add(product);
                }
            }
            return searchedProducts;
        }
        // Készlet lekérdezése
        public int GetQuantity(Product product)
        {
            var p = FindById(product.Id);
            return p != null ? p.Quantity : 0;
        }

        // Készlet csökkentése, siker / hiba visszaadása
        public bool ReduceQuantity(Product product, int amount)
        {
            var p = FindById(product.Id);
            if (p == null || p.Quantity < amount)
                return false;

            p.Quantity -= amount;
            return true;
        }

        // Összes termék kiíratása (teszteléshez)
        public void PrintAllProducts()
        {
            Console.WriteLine("Raktár tartalma:");
            foreach (var p in items)
            {
                Console.WriteLine(p);
            }
        }

    }
}
