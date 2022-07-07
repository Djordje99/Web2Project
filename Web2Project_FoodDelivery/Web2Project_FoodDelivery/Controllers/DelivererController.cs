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
        [Authorize(Roles = "Deliverer")]
        public IActionResult TakeOrder([FromBody] DeliveryDto delivery)
        {
            if (delivery.DelivererEmail == "" || delivery.OrderId < 0)
                return BadRequest("Bad parameters");

            var result = _delivererService.TakeOrder(delivery);

            if (result == -1)
                return BadRequest("Deliverer has already order in progress.");

            return Ok(result);
        }

        [HttpPost("deliver")]
        [Authorize(Roles = "Deliverer")]
        public IActionResult Deliver([FromBody] DeliveryDto delivery)
        {
            if (delivery.DelivererEmail == "" || delivery.OrderId < 0)
                return BadRequest("Bad parameters");

            var result = _delivererService.Deliver(delivery);
            if (!result)
                return BadRequest("Delivery failed");

            return Ok(result);
        }


        [HttpGet("available-orders")]
        [Authorize(Roles = "Deliverer")]
        public IActionResult SeeAvailableOrders()
        {
            return Ok(_delivererService.SeeAvailableOrders());
        }

        [HttpPost("delivered-orders")]
        [Authorize(Roles = "Deliverer")]
        public IActionResult GetDeliveredOrders([FromBody] UserEmailDto email)
        {
            return Ok(_delivererService.GetDeliveredOrders(email));
        }

        [HttpPost("actual-orders")]
        [Authorize(Roles = "Deliverer")]
        public IActionResult GetActualOrders([FromBody] UserEmailDto email)
        {
            return Ok(_delivererService.GetActualOrders(email));
        }

        [HttpGet("orders-details")]
        [Authorize(Roles = "Deliverer")]
        public IActionResult GetOrderDetails([FromBody] UserEmailDto email)
        {
            return Ok(_delivererService.GetOrdersDetails(email));
        }
    }
}
