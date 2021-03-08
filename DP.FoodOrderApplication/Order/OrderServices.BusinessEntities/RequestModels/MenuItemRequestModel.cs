using System;
using System.Collections.Generic;
using System.Text;

namespace OrderServices.BusinessEntities.RequestModels
{
    public class MenuItemRequestModel
    {
        public int Id { get; set; }
        public int MenuItemId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
