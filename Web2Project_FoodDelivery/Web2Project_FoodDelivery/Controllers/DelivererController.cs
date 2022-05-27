using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2Project_FoodDelivery.Interfaces;

namespace Web2Project_FoodDelivery.Controllers
{
    [Route("api/deliverer")]
    [ApiController]
    public class DelivererController : ControllerBase
    {
        private readonly IDelivererService _delivererService;

        public DelivererController(IDelivererService delivererService)
        {
            _delivererService = delivererService;
        }

        [HttpPost("take-order")]
        public IActionResult TakeOrder(long orderId, string delivererEmail)
        {
            return Ok(_delivererService.TakeOrder(orderId, delivererEmail));
        }

        [HttpGet("available-orders")]
        public IActionResult SeeAvailableOrders()
        {
            return Ok(_delivererService.SeeAvailableOrders());
        }

        [HttpPost("delivered-orders")]
        public IActionResult GetDeliveredOrders(string email)
        {
            return Ok(_delivererService.GetDeliveredOrders(email));
        }

        [HttpGet("orders-details")]
        public IActionResult GetOrderDetails(string email)
        {
            return Ok(_delivererService.GetOrdersDetails(email));
        }
    }
}
