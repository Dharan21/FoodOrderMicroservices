using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DriverGrpcService.Protos;
using DriverServices.BL.Interfaces;
using DriverServices.BusinessEntities.ResponseModels;
using Grpc.Core;

namespace DriverGrpcService.Services
{
    public class DriverGrpcProtoService : DriverProtoService.DriverProtoServiceBase
    {
        private readonly IDriverManager driverManager;
        private readonly IMapper mapper;

        public DriverGrpcProtoService(IDriverManager driverManager, IMapper mapper)
        {
            this.driverManager = driverManager;
            this.mapper = mapper;
        }

        public async override Task<GetDriverResponseModel> GetDriver(GetDriverRequestModel request, ServerCallContext context)
        {
            var driver = await this.driverManager.Get(request.DriverId);
            return this.mapper.Map<DriverResponseModel, GetDriverResponseModel>(driver);
        }
    }
}
