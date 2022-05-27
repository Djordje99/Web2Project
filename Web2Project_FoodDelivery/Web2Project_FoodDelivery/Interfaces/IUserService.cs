using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2Project_FoodDelivery.DTO;

namespace Web2Project_FoodDelivery.Interfaces
{
    public interface IUserService
    {
        string Login(string email, string password);
        UserDto Register(string firstName, string lastName,
                         string email, string password,
                         string passwordVerify, string username,
                         DateTime birthday, string address,
                         string photo, Enums.Enums.UserType userType);
        bool UpdateUser(UserDto updateUser);
        bool DeleteUser(string email);
        List<UserDto> RetrieveUsers();
        UserDto FindById(string email);
    }
}
