using MyStoreApi.Models;

namespace MyStoreApi.Dto
{
    public class ItemDto
    {
        /// <summary>
        /// Creates ItemDto from Item object.
        /// </summary>
        /// <param name="item">Item source object</param>
        public ItemDto(Item item)
        {
            Id = item.Id;
            Name = item.Name;
            Price = item.Price;
        }

        public ItemDto() { }

        public int Id { get; set; }
        public string Name { get; set; }
        public long Price { get; set; }
    }
}
