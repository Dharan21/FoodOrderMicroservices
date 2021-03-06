using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerServices.BusinessEntities.ResponseModels
{
    public class RestaurantResponseModel
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
