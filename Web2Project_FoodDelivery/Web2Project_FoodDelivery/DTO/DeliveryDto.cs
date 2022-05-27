using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web2Project_FoodDelivery.DTO
{
    public class DeliveryDto
    {
        public long Id { get; set; }
        public string DelivererEmail { get; set; }
        public long OrderId { get; set; }
    }
}
