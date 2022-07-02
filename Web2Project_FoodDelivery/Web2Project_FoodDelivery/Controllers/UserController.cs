using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2Project_FoodDelivery.Interfaces;
using Web2Project_FoodDelivery.DTO;

namespace Web2Project_FoodDelivery.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _consumerService;
        
        public UserController(IUserService consumerService)
        {
            _consumerService = consumerService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LogInUserDto user)
        {
            var returnValue = _consumerService.Login(user);
            if (returnValue == null)
                return BadRequest("Login failed.");

            return Ok(returnValue);
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterUserDto user)
        {
            var returnValue = _consumerService.Register(user);
            if (returnValue == null)
                return BadRequest("Register failed.");

            return Ok(returnValue);
        }

        [HttpPost("find")]
        public IActionResult FindUser([FromBody] UserEmailDto email)
        {
            return Ok(_consumerService.FindById(email));
        }

        [HttpGet("retrieve")]
        public IActionResult RetrieveUsers()
        {
            return Ok(_consumerService.RetrieveUsers());
        }

        [HttpPut("update")]
        public IActionResult UpdateUser([FromBody] UserDto user)
        {
            return Ok(_consumerService.UpdateUser(user));
        }

        [HttpDelete("delete")]
        public IActionResult DeleteUser(string email)
        {
            return Ok(_consumerService.DeleteUser(email));
        }
    }
}
