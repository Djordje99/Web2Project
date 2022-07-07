using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Web2Project_FoodDelivery.Enums.Enums;

namespace Web2Project_FoodDelivery.Models
{
    public class OrderModel
    {
        public long Id { get; set; }
        public string Comment { get; set; }
        public string Address { get; set; }
        public OrderStatusType Status { get; set; }
        public UserModel Creator { get; set; }
        public string CreatorEmail { get; set; }
        public int Price { get; set; }
        public long TakenTime { get; set; }
        public DeliveryModel Delivery { get; set; }
        public List<OrderDetailsModel> OrderDetails { get; set; }
    }
}
