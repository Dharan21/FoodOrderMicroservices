using System;
using System.Collections.Generic;
using System.Text;

namespace OrderServices.DataEntities.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int MenuItemId { get; set; }
        public string MenuItemName { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
