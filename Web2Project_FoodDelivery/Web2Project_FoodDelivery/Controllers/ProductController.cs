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
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("find")]
        public IActionResult FindProduct(long productId)
        {
            return Ok(_productService.FindById(productId));
        }

        [HttpGet("retrieve")]
        public IActionResult RetrieveProducts()
        {
            return Ok(_productService.RetreveProducts());
        }

        [HttpDelete("delete")]
        public IActionResult DeleteProduct(long productId)
        {
            return Ok(_productService.DeleteProduct(productId));
        }

        [HttpPut("update")]
        public IActionResult UpdateProduct([FromForm] ProductDto newProduct)
        {
            return Ok(_productService.UpdateProduct(newProduct));
        }
    }
}
