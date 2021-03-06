using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantServices.BusinessEntities.ResponseModels
{
    public class RestaurantResponseModel
    {
        public RestaurantResponseModel()
        {
            MenuItems = new List<MenuItemResponseModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public IEnumerable<MenuItemResponseModel> MenuItems { get; set; }
    }
}
