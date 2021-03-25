using System;
using System.Collections.Generic;
using System.Text;

namespace OrderServices.BusinessEntities
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public bool IsAvailable { get; set; }
    }
}
