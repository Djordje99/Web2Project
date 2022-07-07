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
    [Route("api/consumer")]
    [ApiController]
    public class ConsumerController : ControllerBase
    {
        private readonly IConsumerService _consumerService;

        public ConsumerController(IConsumerService consumerService)
        {
            _consumerService = consumerService;
        }

        [HttpPost("create-order")]
        public IActionResult CreateOrder([FromBody] OrderDto newOrder)
        {
            var order = _consumerService.CreateOrder(newOrder);
            if (order == null)
                return BadRequest("Consumer already have current order.");

            return Ok(order);
        }

        [HttpPost("add-product-details")]
        public IActionResult AddOrderDetails([FromBody] OrderDetailsDto product)
        {
            return Ok(_consumerService.AddProdactOrder(product));
        }

        [HttpPost("get-orders")]
        public IActionResult GetOrders([FromBody] UserEmailDto email)
        {
            return Ok(_consumerService.GetOrders(email));
        }

        [HttpPost("get-current-orders")]
        public IActionResult GetCurrentOrders([FromBody] UserEmailDto email)
        {
            return Ok(_consumerService.GetCurrentOrders(email));
        }
        
        [HttpPost("get-orders-details")]
        public IActionResult GetOrdersDetails([FromBody] UserProductsDto userProducts)
        {
            return Ok(_consumerService.GetOrdersDetails(userProducts));
        }
    }
}
