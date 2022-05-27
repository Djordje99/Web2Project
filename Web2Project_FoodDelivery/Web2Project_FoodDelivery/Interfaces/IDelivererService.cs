using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2Project_FoodDelivery.DTO;

namespace Web2Project_FoodDelivery.Interfaces
{
    public interface IDelivererService
    {
        int TakeOrder(long orderId, string delivererEmail);
        List<OrderDto> SeeAvailableOrders();
        List<OrderDto> GetDeliveredOrders(string email);
        List<OrderDetailsDto> GetOrdersDetails(string email);
    }
}
