using System;
using System.Collections.Generic;
using System.Text;
using static Infrastructure.Common.Enumerators.Enumerators;

namespace OrderServices.DataEntities.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public Nullable<int> DriverId { get; set; }
        public string DriverName { get; set; }
        public int TotalPrice { get; set; }
        public int ItemsQuantity { get; set; }
        public DateTime DateTime { get; set; }
        public OrderStatus Status { get; set; }
        public virtual IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
