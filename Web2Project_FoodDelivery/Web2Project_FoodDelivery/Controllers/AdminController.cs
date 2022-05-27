﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2Project_FoodDelivery.DTO;
using Web2Project_FoodDelivery.Interfaces;

namespace Web2Project_FoodDelivery.Controllers
{
    [Route("api/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost("activate")]
        public IActionResult ActivateUser(string email)
        {
            return Ok(_adminService.ActivateUser(email));
        }

        [HttpPost("verify")]
        public IActionResult VerifyDeliverer(string email, Enums.Enums.VeryfiedType status)
        {
            return Ok(_adminService.VerifyDeliverer(email, status));
        }

        [HttpGet("deliverers-status")]
        public IActionResult SeeDeliverersStatus()
        {
            return Ok(_adminService.SeeDelivererStatus());
        }

        [HttpGet("activation-request")]
        public IActionResult SeeActivationRequests()
        {
            return Ok(_adminService.SeeActivationRequests());
        }

        [HttpPost("create-product")]
        public IActionResult CreateProduct([FromForm] ProductDto newProduct)
        {
            return Ok(_adminService.CreateProduct(newProduct));
        }

        [HttpGet("get-orders")]
        public IActionResult GetOrders()
        {
            return Ok(_adminService.GetAllOrders());
        }
    }
}