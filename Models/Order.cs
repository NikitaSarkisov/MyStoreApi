using System;
using System.Collections.Generic;

namespace MyStoreApi.Models
{
    public class Order
    {
        public Order()
        {
            Items = new HashSet<Item>();
        }

        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}
