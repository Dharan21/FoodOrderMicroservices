using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantServices.DataEntities.Entities
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public IEnumerable<MenuItem> MenuItems { get; set; }
    }
}
