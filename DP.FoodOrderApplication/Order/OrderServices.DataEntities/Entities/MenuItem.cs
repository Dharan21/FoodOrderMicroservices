using System;
using System.Collections.Generic;
using System.Text;

namespace OrderServices.DataEntities.Entities
{
    public class MenuItem
    {
        public int Id { get; set; }
        public int MenuItemId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
