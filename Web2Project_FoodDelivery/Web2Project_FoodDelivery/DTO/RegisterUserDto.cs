using System;
using System.ComponentModel.DataAnnotations;
using static Web2Project_FoodDelivery.Enums.Enums;

namespace Web2Project_FoodDelivery.DTO
{
    public class RegisterUserDto
    {
        [Required(ErrorMessage = "The field with name {0} is reqiered.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "The field with name {0} is reqiered.")]
        public string LastName { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "The field with name {0} is reqiered.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "The field with name {0} is reqiered.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "The field with name {0} is reqiered.")]
        public string PasswordVerify { get; set; }
        [Required(ErrorMessage = "The field with name {0} is reqiered.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "The field with name {0} is reqiered.")]
        public DateTime Birthday { get; set; }
        [Required(ErrorMessage = "The field with name {0} is reqiered.")]
        public string Address { get; set; }

        public string Photo { get; set; }
        [Required(ErrorMessage = "The field with name {0} is reqiered.")]
        public int UserType { get; set; }
    }
}
