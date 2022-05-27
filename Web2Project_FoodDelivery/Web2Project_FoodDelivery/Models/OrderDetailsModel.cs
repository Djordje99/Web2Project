using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web2Project_FoodDelivery.Models
{
    public class OrderDetailsModel
    {
        public long Id { get; set; }
        public OrderModel Order { get; set; }
        public ProductModel Product { get; set; }
        public int Amount { get; set; }
        public double CurrentPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public long OrderId { get; set; }
        public long ProductId { get; set; }

    }
}
