using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using MyStoreApi.Data;
using MyStoreApi.Dto;
using MyStoreApi.Models;

namespace MyStoreApi.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public OrdersController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<OrderDto> Get()
        {
            return context.Orders
                .Include(i => i.Items)
                .Select(order => new OrderDto(order));
        }

        [HttpGet("{id:int}")]
        public ActionResult<OrderDto> Get(int id)
        {
            var found = context.Orders.Include(i => i.Items).FirstOrDefault(order => order.Id == id);
            if (found == null)
            {
                return NotFound();
            }
            return new OrderDto(found);
        }

        [HttpPost]
        public IActionResult Create(OrderCreateUpdateDto createOrder)
        {
            // Load Items enteties by supplied ids
            var items = GetItemsByIds(createOrder.ItemsIds);
            // If items is null -> request contains illegal item id
            if (items == null || items.Count == 0)
            {
                return BadRequest();
            }

            // Create new order
            Order newOrder = new Order
            {
                Created = DateTime.Now,
                Modified = null,
                Items = items
            };
            context.Orders.Add(newOrder);
            context.SaveChanges();
            var newOrderDto = new OrderDto(newOrder);
            return CreatedAtAction(nameof(Get), new { id = newOrderDto.Id }, newOrderDto);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] OrderCreateUpdateDto updateOrder)
        {
            var order = context.Orders.Include(i => i.Items).FirstOrDefault(o => o.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            var items = GetItemsByIds(updateOrder.ItemsIds);
            if (items == null || items.Count == 0)
            {
                return BadRequest();
            }

            // Update order items
            order.Items.Clear();
            foreach (var i in items)
            {
                order.Items.Add(i);
            }
            // Set new Modified date
            order.Modified = DateTime.Now;

            // Update order
            context.Orders.Update(order);
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }
            var newOrderDto = new OrderDto(order);
            return CreatedAtAction(nameof(Get), new { id = newOrderDto.Id }, newOrderDto);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var order = context.Orders.Find(id);
            if (order == null)
            {
                return NotFound();
            }
            context.Orders.Remove(order);
            int rowsModified;
            try
            {
                rowsModified = context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }
            if (rowsModified == 0)
            {
                return NotFound();
            }
            return Ok();
        }

        /// <summary>
        /// Finds Item entities.
        /// </summary>
        /// <param name="ids">Ids to find</param>
        /// <returns>List of Items. If any of supplied ids do not exist null is returned.</returns>
        private List<Item> GetItemsByIds(ICollection<int> ids)
        {
            bool containsIligalItems = false;
            var items = new List<Item>(ids.Count);
            foreach (var id in ids)
            {
                var item = context.Items.Find(id);
                if (item == null)
                {
                    containsIligalItems = true;
                    break;
                }
                items.Add(item);
            }
            return containsIligalItems ? null : items;
        }
    }
}
