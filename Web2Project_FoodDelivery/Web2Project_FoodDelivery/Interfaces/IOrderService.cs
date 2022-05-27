using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2Project_FoodDelivery.DTO;

namespace Web2Project_FoodDelivery.Interfaces
{
    public interface IOrderService
    {
        bool DeleteOrder(long orderId);
        bool UpdateOrder(OrderDto updatedOrder);
        OrderDto FindById(long orderId);
        List<OrderDto> RetrieveOrders();
    }
}
