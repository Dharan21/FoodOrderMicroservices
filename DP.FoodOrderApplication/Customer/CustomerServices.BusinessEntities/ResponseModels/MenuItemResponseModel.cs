using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerServices.BusinessEntities.ResponseModels
{
    public class MenuItemResponseModel
    {
        public int Id { get; set; }
        public int MenuItemId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public bool IsAvailable { get; set; }
        public int RestaurantId { get; set; }
    }
}
