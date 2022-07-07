using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2Project_FoodDelivery.DTO;

namespace Web2Project_FoodDelivery.Interfaces
{
    public interface IConsumerService
    {
        OrderDto CreateOrder(OrderDto newOrder);
        OrderDetailsDto AddProdactOrder(OrderDetailsDto product);
        List<OrderDto> GetOrders(UserEmailDto email);
        OrderDto GetCurrentOrders(UserEmailDto email);
        List<ProductDto> GetOrdersDetails(UserProductsDto userProducts);
    }
}
