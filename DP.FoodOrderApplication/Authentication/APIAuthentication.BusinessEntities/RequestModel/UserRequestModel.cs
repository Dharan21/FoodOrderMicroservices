using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Infrastructure.Common.Enumerators.Enumerators;

namespace APIAuthentication.BusinessEntities.RequestModel
{
    public class UserRequestModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
    }
}
