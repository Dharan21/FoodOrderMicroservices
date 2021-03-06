using System;
using System.Collections.Generic;
using System.Text;

namespace OrderServices.BusinessEntities.RequestModels
{
    public class OrderRequestModel
    {
        public OrderRequestModel()
        {
            OrderedItems = new List<OrderItemRequestModel>();
        }
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public int CustomerId { get; set; }
        public List<OrderItemRequestModel> OrderedItems { get; set; }
    }
}
