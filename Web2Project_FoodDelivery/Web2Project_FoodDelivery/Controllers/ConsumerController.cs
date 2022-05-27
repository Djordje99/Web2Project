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
        public IActionResult CreateOrder([FromForm] OrderDto newOrder)
        {
            return Ok(_consumerService.CreateOrder(newOrder));
        }

        [HttpPost("add-product")]
        public IActionResult AddOrderDetails(long orderId, long productId, int amount)
        {
            return Ok(_consumerService.AddOrderDetail(orderId, productId, amount));
        }

        [HttpPost("order")]
        public IActionResult Order(long orderId)
        {
            return Ok(_consumerService.Order(orderId));
        }

        [HttpPost("get-orders")]
        public IActionResult GetOrders(string email)
        {
            return Ok(_consumerService.GetOrders(email));
        }

        [HttpPost("get-orders-details")]
        public IActionResult GetOrdersDetails(string email)
        {
            return Ok(_consumerService.GetOrdersDetails(email));
        }
    }
}
