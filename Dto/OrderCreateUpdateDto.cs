using System.Collections.Generic;

namespace MyStoreApi.Dto
{
    /// <summary>
    /// Defines fileds requited to Create (POST) or Update (PUT) Order.
    /// </summary>
    public class OrderCreateUpdateDto
    {
        public ICollection<int> ItemsIds { get; set; }
    }
}
