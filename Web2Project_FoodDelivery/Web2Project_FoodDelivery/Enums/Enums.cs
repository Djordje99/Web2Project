using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web2Project_FoodDelivery.Enums
{
    public static class Enums
    {
        public enum UserType
        {
            Admin = 0,
            Consumer = 1,
            Deliverer = 2,
        }

        public enum VeryfiedType
        {
            Approved,
            Denied,
            InProgress,
        }

        public enum OrderStatusType
        {
            Wating,
            InProgress,
            Delivered,
        }
    }
}
