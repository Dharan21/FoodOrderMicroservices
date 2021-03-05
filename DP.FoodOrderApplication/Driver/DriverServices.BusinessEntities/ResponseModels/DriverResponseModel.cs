using System;
using System.Collections.Generic;
using System.Text;

namespace DriverServices.BusinessEntities.ResponseModels
{
    public class DriverResponseModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
    }
}
