using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        [Authorize(Roles = "Admin")]
        public IActionResult ActivateUser([FromBody]UserEmailDto email)
        {
            if (email.Email == "")
                return BadRequest("Bad email foramt");

            var result = _adminService.ActivateUser(email);

            if (!result)
                return BadRequest("Activation failed");
            else
                return Ok(result);
        }

        [HttpPost("verify")]
        [Authorize(Roles = "Admin")]
        public IActionResult VerifyDeliverer([FromBody] VerifyDto delivererVerify)
        {
            if (delivererVerify.Email == "")
                return BadRequest("Bad email foramt");

            var result = _adminService.VerifyDeliverer(delivererVerify);

            if (!result)
                return BadRequest("Verifivation failed");
            else
                return Ok(result);
        }

        [HttpGet("deliverers-status")]
        [Authorize(Roles = "Admin")]
        public IActionResult SeeDeliverersStatus()
        {
            var result = _adminService.SeeDelivererStatus();

            if (result == null)
                return BadRequest("Retriving deliveres failed.");
            return Ok(result);
        }

        [HttpGet("activation-request")]
        [Authorize(Roles = "Admin")]
        public IActionResult SeeActivationRequests()
        {
            var result = _adminService.SeeActivationRequests();

            if (result == null)
                return BadRequest("Retriving deliveres failed.");
            return Ok(result);
        }

        [HttpPost("create-product")]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateProduct([FromBody] ProductDto newProduct)
        {
            if (newProduct.Ingredients == "" || newProduct.Price < 0 || newProduct.Name == "")
                return BadRequest("Product missing filed fields");

            var result = _adminService.CreateProduct(newProduct);

            if (result == null)
                return BadRequest("Creating product failed.");

            return Ok(result);
        }

        [HttpGet("get-orders")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetOrders()
        {
            var result = _adminService.GetAllOrders();

            if (result == null)
                return BadRequest("Getting order faild.");

            return Ok(result);
        }
    }
}
