using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway.Models
{
    public class OrderDetails
    {
        public OrderDetails()
        {
            OrderItems = new List<OrderItems>();
        }
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public Nullable<int> DriverId { get; set; }
        public string DriverName { get; set; }
        public int TotalPrice { get; set; }
        public DateTime DateTime { get; set; }
        public string Status { get; set; }
        public IEnumerable<OrderItems> OrderItems { get; set; }
    }

    public class OrderItems
    {
        public string MenuItemName { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
}
