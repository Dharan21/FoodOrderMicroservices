using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerServices.BusinessEntities.ResponseModels
{
    public class CustomerResponseModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
    }
}
