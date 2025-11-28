using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iktraktar.Models
{
    internal class Order : IIndentifiable
    {
        public int Id { get; }
        public List<OrderItem> Items { get; } = new List<OrderItem>();

        public Order(int id)
        {
            Id = id;
        }
    }
}
