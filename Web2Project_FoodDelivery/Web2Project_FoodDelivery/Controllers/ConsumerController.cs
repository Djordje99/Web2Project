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
        [Authorize(Roles = "Consumer")]
        public IActionResult CreateOrder([FromBody] OrderDto newOrder)
        {
            if (newOrder.Address == "" || newOrder.Comment == "" || newOrder.Price < 0 || newOrder.CreatorEmail == "")
                return BadRequest("Order parameters are not given");

            var order = _consumerService.CreateOrder(newOrder);
            if (order == null)
                return BadRequest("Consumer already have current order.");

            return Ok(order);
        }

        [HttpPost("add-product-details")]
        [Authorize(Roles = "Consumer")]
        public IActionResult AddOrderDetails([FromBody] OrderDetailsDto product)
        {
            if (product.ProductId < 0 || product.OrderId < 0)
                return BadRequest("Products parameters are not given.");

            var result = _consumerService.AddProdactOrder(product);

            if (result == null)
                return BadRequest("Adding product to order failed.");
            return Ok(result);
        }

        [HttpPost("get-orders")]
        [Authorize(Roles = "Consumer")]
        public IActionResult GetOrders([FromBody] UserEmailDto email)
        {
            if (email.Email == "")
                return BadRequest("Email not valid.");

            var result = _consumerService.GetOrders(email);

            if (result == null)
                return BadRequest("Getting orders failed");

            return Ok(result);
        }

        [HttpPost("get-current-orders")]
        [Authorize(Roles = "Consumer")]
        public IActionResult GetCurrentOrders([FromBody] UserEmailDto email)
        {
            if (email.Email == "")
                return BadRequest("Email not valid.");

            var result = _consumerService.GetCurrentOrders(email);

            if (result == null)
                return BadRequest("Current order does not exists.");

            return Ok(result);
        }

        [HttpPost("get-orders-details")]
        [Authorize(Roles = "Consumer,Admin,Deliverer")]
        public IActionResult GetOrdersDetails([FromBody] UserProductsDto userProducts)
        {
            if (userProducts.OrderId < 0 || userProducts.Email == "")
                return BadRequest("Bad parameters.");

            var result = _consumerService.GetOrdersDetails(userProducts);
            if (result == null)
                return BadRequest("Getting details failed");

            return Ok(result);
        }
    }
}
