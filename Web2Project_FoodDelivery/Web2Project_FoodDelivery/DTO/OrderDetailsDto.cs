using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2Project_FoodDelivery.Models;

namespace Web2Project_FoodDelivery.DTO
{
    public class OrderDetailsDto
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public long ProductId { get; set; }
        public int Amount { get; set; }
        public double CurrentPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
