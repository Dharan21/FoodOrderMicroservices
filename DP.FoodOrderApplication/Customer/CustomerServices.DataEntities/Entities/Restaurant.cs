using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerServices.DataEntities.Entities
{
    public class Restaurant
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
