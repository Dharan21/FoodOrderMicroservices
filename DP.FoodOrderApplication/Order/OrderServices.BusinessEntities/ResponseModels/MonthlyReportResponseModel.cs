using System;
using System.Collections.Generic;
using System.Text;

namespace OrderServices.BusinessEntities.ResponseModels
{
    public class MonthlyReportResponseModel
    {
        public string Month { get; set; }
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public List<OrderResponseModel> DeliveredOrders { get; set; }
    }
}
