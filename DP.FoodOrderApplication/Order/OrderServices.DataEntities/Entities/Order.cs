using System;
using System.Collections.Generic;
using System.Text;

namespace OrderServices.DataEntities.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int DriverId { get; set; }
        public string DriverName { get; set; }
        public int Price { get; set; }
        public DateTime DateTime { get; set; }
        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
