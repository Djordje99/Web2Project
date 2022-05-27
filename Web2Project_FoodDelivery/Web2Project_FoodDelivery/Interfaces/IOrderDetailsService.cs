using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2Project_FoodDelivery.DTO;

namespace Web2Project_FoodDelivery.Interfaces
{
    public interface IOrderDetailsService
    {
        bool DeleteOrderDetail(long orderDetailsId);
        bool UpdateOrderDetail(OrderDetailsDto updatedOrderDetails);
        OrderDetailsDto FindById(long orderDetailsId);
        List<OrderDetailsDto> RetrieveOrdersDetails();
    }
}
