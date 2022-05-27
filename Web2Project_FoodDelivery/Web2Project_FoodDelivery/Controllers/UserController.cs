﻿using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Login(string email, string password)
        {
            return Ok(_consumerService.Login(email, password));
        }

        [HttpPost("register")]
        public IActionResult Register(string firstName, string lastName, 
                                      string email, string password, 
                                      string passwordVerify, string username, 
                                      DateTime birthday, string address,
                                      string photo, Enums.Enums.UserType userType)
        {
            return Ok(_consumerService.Register(firstName, lastName, email, password, passwordVerify, username, birthday, address, photo, userType));
        }

        [HttpGet("find")]
        public IActionResult FindUser(string email)
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