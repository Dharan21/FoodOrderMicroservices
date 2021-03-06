using System;
using System.Collections.Generic;
using System.Text;

namespace OrderServices.BusinessEntities.RequestModels
{
    public class OrderItemRequestModel
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
    }
}
