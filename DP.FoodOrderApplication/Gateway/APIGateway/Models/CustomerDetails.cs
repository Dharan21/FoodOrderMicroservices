using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway.Models
{
    public class CustomerDetails
    {
        public CustomerDetails()
        {
            OrderDetails = new List<OrderDetails>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
    }
}
