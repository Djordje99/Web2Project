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
        OrderDetailsDto AddOrderDetail(long orderId, long productId, int amount);
        bool Order(long orderId);
        List<OrderDto> GetOrders(string email);
        List<OrderDetailsDto> GetOrdersDetails(string email);
    }
}
