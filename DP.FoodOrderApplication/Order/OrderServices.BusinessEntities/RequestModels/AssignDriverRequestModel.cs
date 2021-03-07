using System;
using System.Collections.Generic;
using System.Text;

namespace OrderServices.BusinessEntities.RequestModels
{
    public class AssignDriverRequestModel
    {
        public int OrderId { get; set; }
        public int DriverId { get; set; }
    }
}
