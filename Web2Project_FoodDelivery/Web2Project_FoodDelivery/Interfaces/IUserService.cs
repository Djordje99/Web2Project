using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2Project_FoodDelivery.DTO;

namespace Web2Project_FoodDelivery.Interfaces
{
    public interface IUserService
    {
        TokenDto Login(LogInUserDto user);
        UserDto Register(RegisterUserDto user);
        bool UpdateUser(UserDto updateUser);
        bool DeleteUser(string email);
        List<UserDto> RetrieveUsers();
        UserDto FindById(UserEmailDto email);
        bool AddUsersPicture(string email, string path);
        string GetUsersPicture(string email);
    }
}
