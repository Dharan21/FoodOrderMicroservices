using System;
using System.Collections.Generic;
using System.Text;

namespace OrderServices.BusinessEntities.ResponseModels
{
    public class DriverOrderResponseModel
    {
        public DriverOrderResponseModel()
        {
            Orders = new List<OrderResponseModel>();
        }
        public int DriverId { get; set; }
        public string DriverName { get; set; }
        public List<OrderResponseModel> Orders { get; set; }
    }
}
