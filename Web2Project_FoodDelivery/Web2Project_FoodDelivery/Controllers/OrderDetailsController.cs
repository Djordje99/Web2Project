using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2Project_FoodDelivery.DTO;
using Web2Project_FoodDelivery.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web2Project_FoodDelivery.Controllers
{
    [Route("api/orderdetails")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailsService _orderDetailsService;

        public OrderDetailsController(IOrderDetailsService orderDetailsService)
        {
            _orderDetailsService = orderDetailsService;
        }

        [HttpGet("find")]
        public IActionResult FindOrderDetails(long orderDetailsId)
        {
            return Ok(_orderDetailsService.FindById(orderDetailsId));
        }

        [HttpGet("retrieve")]
        public IActionResult RetrieveOrdersDetails()
        {
            return Ok(_orderDetailsService.RetrieveOrdersDetails());
        }

        [HttpDelete("delete")]
        public IActionResult DeleteOrderDetails(long orderDetailsId)
        {
            return Ok(_orderDetailsService.DeleteOrderDetail(orderDetailsId));
        }

        [HttpPut("update")]
        public IActionResult UpdateOrderDetails([FromForm] OrderDetailsDto newOrderDetails)
        {
            return Ok(_orderDetailsService.UpdateOrderDetail(newOrderDetails));
        }
    }
}
