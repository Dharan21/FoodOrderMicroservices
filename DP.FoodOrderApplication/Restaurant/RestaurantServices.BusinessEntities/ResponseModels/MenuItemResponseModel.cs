using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantServices.BusinessEntities.ResponseModels
{
    public class MenuItemResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public bool IsAvailable { get; set; }
        public int RestaurantId { get; set; }
    }
}
