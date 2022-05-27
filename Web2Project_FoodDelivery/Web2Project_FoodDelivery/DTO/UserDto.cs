using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Web2Project_FoodDelivery.Enums.Enums;

namespace Web2Project_FoodDelivery.DTO
{
    public class UserDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public UserType Type { get; set; }
        public DateTime Birthday { get; set; }
        public string Picture { get; set; }
        public VeryfiedType Veryfied { get; set; }
        public bool AccepredRegistration { get; set; }
    }
}
