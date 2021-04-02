using APIAuthentication.BusinessEntities.RequestModel;
using APIAuthentication.DataEntities.Entities;
using APIAuthentication.DL.Interfaces;
using APIAuthentication.BL.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIAuthentication.BL.Manager
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UserManager(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }
        public async Task Add(UserRequestModel user)
        {
            User userEntity = this.mapper.Map<UserRequestModel, User>(user);
            await this.userRepository.Create(userEntity);
        }

        public async Task<bool> CheckUserCredentials(UserRequestModel user)
        {
            User userEntity = await this.userRepository.FindAsync(x => x.Role == user.Role && x.Email == user.Email && x.Password == user.Password);
            return userEntity != null;
        }
    }
}
