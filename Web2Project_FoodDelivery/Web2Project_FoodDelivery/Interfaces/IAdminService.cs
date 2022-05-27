using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2Project_FoodDelivery.DTO;

namespace Web2Project_FoodDelivery.Interfaces
{
    public interface IAdminService
    {
        bool VerifyDeliverer(string email, Enums.Enums.VeryfiedType status);
        bool ActivateUser(string email);
        List<UserDto> SeeDelivererStatus();
        List<UserDto> SeeActivationRequests();
        ProductDto CreateProduct(ProductDto newProduct);
        List<OrderDto> GetAllOrders();
    }
}
