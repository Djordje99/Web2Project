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
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("find")]
        public IActionResult FindOrder(long orderId)
        {
            return Ok(_orderService.FindById(orderId));
        }

        [HttpGet("retrieve")]
        public IActionResult RetrieveOrders()
        {
            return Ok(_orderService.RetrieveOrders());
        }

        [HttpDelete("delete")]
        public IActionResult DeleteOrder(long orderId)
        {
            return Ok(_orderService.DeleteOrder(orderId));
        }

        [HttpPut("update")]
        public IActionResult UpdateOrder([FromForm] OrderDto newOrder)
        {
            return Ok(_orderService.UpdateOrder(newOrder));
        }
    }
}
