using System;
using System.Collections.Generic;
using System.Linq;
using MyStoreApi.Models;

namespace MyStoreApi.Dto
{
    public class OrderDto
    {
        /// <summary>
        /// Creates OrderDto from Order object.
        /// </summary>
        /// <param name="order"></param>
        public OrderDto(Order order)
        {
            Id = order.Id;
            Created = order.Created;
            Modified = order.Modified;
            Items = order.Items.Select(item => new ItemDto(item)).ToList();
        }

        public OrderDto() { }
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }

        public ICollection<ItemDto> Items { get; set; }
    }
}
