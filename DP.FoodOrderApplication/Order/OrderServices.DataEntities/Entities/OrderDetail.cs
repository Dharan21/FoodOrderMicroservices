using System;
using System.Collections.Generic;
using System.Text;

namespace OrderServices.DataEntities.Entities
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int OrderItemId { get; set; }

        public Order Order { get; set; }
        public OrderItem OrderItem { get; set; }
    }
}
