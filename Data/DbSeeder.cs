using MyStoreApi.Models;

namespace MyStoreApi.Data
{
    public class DbSeeder
    {
        public static void Seed(ApplicationDbContext context)
        {
            var items = new Item[]
            {
                new Item() {Name = "Apple iPhone", Price = 50000},
                new Item() {Name = "Google Pixel", Price = 40000},
                new Item() {Name = "Nokia 4.2", Price = 15000},
                new Item() {Name = "Samsung Galaxy", Price = 70000},
            };
            context.Items.AddRange(items);
            context.SaveChanges();
        }
    }
}
