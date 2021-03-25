using System;
using System.Collections.Generic;
using System.Text;

namespace OrderServices.DataEntities.Entities
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int OrderedItemId { get; set; }
        public string OrderedItemName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }

        public Order Order { get; set; }
    }
}
