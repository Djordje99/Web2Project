using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web2Project_FoodDelivery.Models
{
    public class ProductModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Ingredients { get; set; }
        public List<OrderDetailsModel> ProductDetails { get; set; }
    }
}
