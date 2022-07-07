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
        public IActionResult TakeOrder([FromBody] DeliveryDto delivery)
        {
            var result = _delivererService.TakeOrder(delivery);

            if (result == -1)
                return BadRequest("Deliverer has olready order in progress.");

            return Ok(result);
        }

        [HttpPost("deliver")]
        public IActionResult Deliver([FromBody] DeliveryDto delivery)
        {
            return Ok(_delivererService.Deliver(delivery));
        }


        [HttpGet("available-orders")]
        public IActionResult SeeAvailableOrders()
        {
            return Ok(_delivererService.SeeAvailableOrders());
        }

        [HttpPost("delivered-orders")]
        public IActionResult GetDeliveredOrders([FromBody] UserEmailDto email)
        {
            return Ok(_delivererService.GetDeliveredOrders(email));
        }

        [HttpPost("actual-orders")]
        public IActionResult GetActualOrders([FromBody] UserEmailDto email)
        {
            return Ok(_delivererService.GetActualOrders(email));
        }

        [HttpGet("orders-details")]
        public IActionResult GetOrderDetails([FromBody] UserEmailDto email)
        {
            return Ok(_delivererService.GetOrdersDetails(email));
        }
    }
}
