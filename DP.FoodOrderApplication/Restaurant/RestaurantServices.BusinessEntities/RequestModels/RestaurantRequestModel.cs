using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantServices.BusinessEntities.RequestModels
{
    public class RestaurantRequestModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
    }
}
