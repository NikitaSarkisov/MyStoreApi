using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using MyStoreApi.Data;
using MyStoreApi.Dto;

namespace MyStoreApi.Controllers
{
    [Route("api/items")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public ItemController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<ItemDto> Get()
        {
            return context.Items.Select(item => new ItemDto(item));
        }
    }
}
