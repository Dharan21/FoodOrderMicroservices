using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIAuthentication.BL.Interfaces;
using APIAuthentication.BusinessEntities.RequestModel;
using AuthGrpcService.Protos;
using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace AuthGrpcService.Services
{
    public class UserGrpcProtoService : UserProtoService.UserProtoServiceBase
    {
        private readonly IUserManager userManager;
        private readonly IMapper mapper;

        public UserGrpcProtoService(IUserManager userManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }
        public override async Task<Empty> AddUser(AddUserRequestModel request, ServerCallContext context)
        {
            var user = this.mapper.Map<AddUserRequestModel, UserRequestModel>(request);
            await this.userManager.Add(user);
            return new Empty();
        }
    }
}
