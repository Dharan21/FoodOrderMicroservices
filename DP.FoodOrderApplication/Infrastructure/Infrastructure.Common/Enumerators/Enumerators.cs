using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Common.Enumerators
{
    public static class Enumerators
    {
        public enum OrderStatus
        {
            OrderPlaced = 1,
            DriverAssigned = 2,
            Delivered = 3
        }

        public enum UserRole
        {
            Customer = 1,
            Restaurant = 2,
            Driver = 3
        }
    }
}
