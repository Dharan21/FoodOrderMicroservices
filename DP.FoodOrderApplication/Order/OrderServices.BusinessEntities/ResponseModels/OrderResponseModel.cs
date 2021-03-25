using System;
using System.Collections.Generic;
using System.Text;

namespace OrderServices.BusinessEntities.ResponseModels
{
    public class OrderResponseModel
    {
        public OrderResponseModel()
        {
            OrderItems = new List<OrderItemResponseModel>();
        }
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public string CustomerName { get; set; }
        public Nullable<int> DriverId { get; set; }
        public string DriverName { get; set; }
        public int TotalPrice { get; set; }
        public DateTime DateTime { get; set; }
        public string Status { get; set; }
        public IEnumerable<OrderItemResponseModel> OrderItems { get; set; }
    }
}
