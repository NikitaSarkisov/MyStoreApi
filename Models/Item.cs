using System.Collections.Generic;

namespace MyStoreApi.Models
{
    public class Item
    {
        public Item()
        {
            orders = new HashSet<Order>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public long Price { get; set; }

        public ICollection<Order> orders { get; set; }
    }
}
