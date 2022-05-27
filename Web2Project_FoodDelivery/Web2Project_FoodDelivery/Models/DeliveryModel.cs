using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web2Project_FoodDelivery.Models
{
    public class DeliveryModel
    {
        public long Id { get; set; }
        public string DelivererEmail { get; set; }
        public UserModel Deliverer { get; set; }
        public long OrderId { get; set; }
        public OrderModel Order { get; set; }
    }
}
