using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Common.Constants
{
    public static class Constants
    {
        public const string GatewayEndPointKey = "GatewayEndPoint";

        // Services Prefix
        public const string CustomerServicesPrefix = "Customer";
        public const string DriverServicesPrefix = "Driver";
        public const string RestaurantServicesPrefix = "Restaurant";
        public const string OrderServicesPrefix = "Order";
        public const string AuthenticationServicesPrefix = "Authentication";

        // CustomerServicesControllers
        public const string CustomerServiceCustomersController = "Customers";

        // DriverServiceControllers
        public const string DriverServiceDriversController = "Drivers";

        // RestaurantServiceControllers
        public const string RestaurantServiceRestaurantController = "Restaurant";
        public const string RestaurantServiceMenuItemController = "MenuItem";

        // UsersServiceControllers
        public const string AuthenticationServiceUsersController = "Users";

        // Generic Action Methods
        public const string Add = "Add";
        public const string Get = "Get";
        public const string GetAll = "GetAll";
        public const string Delete = "Delete";

    }
}
