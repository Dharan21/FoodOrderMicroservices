﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OrderServices.BusinessEntities.ResponseModels
{
    public class OrderItemResponseModel
    {
        public string MenuItemName { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
}
