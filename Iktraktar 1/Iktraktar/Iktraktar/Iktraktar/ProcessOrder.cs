using Iktraktar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iktraktar
{
    internal static class OrderProcess
    {
        public static void ProcessOrder(Order order, Storage storage)
        {
            bool canProcess = true;
            var insufficientProducts = new List<OrderItem>();

            // Először ellenőrizzük, van-e elég készlet minden tételhez
            foreach (var item in order.Items)
            {
                var storedProduct = storage.FindById(item.Product.Id);
                if (storedProduct == null || storedProduct.Quantity < item.Quantity)
                {
                    canProcess = false;
                    insufficientProducts.Add(item);
                }
            }

            if (!canProcess)
            {
                Console.WriteLine($"Hiba: nem elég készlet a következő termékekből:");
                foreach (var item in insufficientProducts)
                {
                    Console.WriteLine($"#{item.Product.Id} {item.Product.Name} (kért: {item.Quantity}, raktáron: {storage.GetQuantity(item.Product)})");
                }
                return;
            }

            // Levonjuk a készletet
            Console.WriteLine($"Rendelés feldolgozva #{order.Id}");
            Console.WriteLine("Levont készlet:");
            foreach (var item in order.Items)
            {
                storage.ReduceQuantity(item.Product, item.Quantity);
                Console.WriteLine($"#{item.Product.Id} {item.Product.Name} (-{item.Quantity})");
            }
        }
    }
}

