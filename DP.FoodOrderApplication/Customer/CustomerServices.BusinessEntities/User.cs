using System;
using System.Collections.Generic;
using System.Text;
using static Infrastructure.Common.Enumerators.Enumerators;

namespace CustomerServices.BusinessEntities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
    }
}
