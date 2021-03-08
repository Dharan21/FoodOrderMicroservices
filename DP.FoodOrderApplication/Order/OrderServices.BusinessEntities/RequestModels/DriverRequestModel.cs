using System;
using System.Collections.Generic;
using System.Text;

namespace OrderServices.BusinessEntities.RequestModels
{
    public class DriverRequestModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
    }
}
