using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2Project_FoodDelivery.DTO;

namespace Web2Project_FoodDelivery.Interfaces
{
    public interface IDelivererService
    {
        int TakeOrder(DeliveryDto delivery);
        List<OrderDto> SeeAvailableOrders();
        List<OrderDto> GetDeliveredOrders(UserEmailDto email);
        List<OrderDto> GetActualOrders(UserEmailDto email);
        List<OrderDetailsDto> GetOrdersDetails(UserEmailDto email);
        bool Deliver(DeliveryDto delivery);
    }
}
