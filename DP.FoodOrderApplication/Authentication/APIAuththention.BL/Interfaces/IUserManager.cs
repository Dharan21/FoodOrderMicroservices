using APIAuthentication.BusinessEntities.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIAuthentication.BL.Interfaces
{
    public interface IUserManager
    {
        Task Add(UserRequestModel user);
        Task<bool> CheckUserCredentials(UserRequestModel user);
    }
}
