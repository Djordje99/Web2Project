using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2Project_FoodDelivery.Models;
using static Web2Project_FoodDelivery.Enums.Enums;

namespace Web2Project_FoodDelivery.DTO
{
    public class OrderDto
    {
        public long Id { get; set; }
        public string Comment { get; set; }
        public string Address { get; set; }
        public OrderStatusType Status { get; set; }
        public string CreatorEmail { get; set; }
        //public string DelivererEmail { get; set; }
        //public List<long> OrderDetailsIds { get; set; }
    }
}
