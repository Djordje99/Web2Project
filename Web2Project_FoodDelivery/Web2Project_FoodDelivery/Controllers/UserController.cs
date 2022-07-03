using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2Project_FoodDelivery.Interfaces;
using Web2Project_FoodDelivery.DTO;
using System.IO;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace Web2Project_FoodDelivery.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _consumerService;
        
        public UserController(IUserService consumerService)
        {
            _consumerService = consumerService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LogInUserDto user)
        {
            var returnValue = _consumerService.Login(user);
            if (returnValue == null)
                return BadRequest("Login failed.");

            return Ok(returnValue);
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterUserDto user)
        {
            var returnValue = _consumerService.Register(user);
            if (returnValue == null)
                return BadRequest("Register failed.");

            return Ok(returnValue);
        }

        [HttpPost("find")]
        public IActionResult FindUser([FromBody] UserEmailDto email)
        {
            return Ok(_consumerService.FindById(email));
        }

        [HttpGet("retrieve")]
        public IActionResult RetrieveUsers()
        {
            return Ok(_consumerService.RetrieveUsers());
        }

        [HttpPut("update")]
        public IActionResult UpdateUser([FromBody] UserDto user)
        {
            return Ok(_consumerService.UpdateUser(user));
        }

        [HttpDelete("delete")]
        public IActionResult DeleteUser(string email)
        {
            return Ok(_consumerService.DeleteUser(email));
        }

        [HttpPost("upload"), DisableRequestSizeLimit]
        public IActionResult Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    if (_consumerService.AddUsersPicture(file.Name, dbPath))
                        return Ok(new { dbPath });
                    else
                        return BadRequest();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + "No image attached");
            }
        }

        [HttpPost("download")]
        [ResponseCache(VaryByHeader = "User-Agent", Duration = 0)]
        public IActionResult Download(UserEmailDto email)
        {
            string imagePath = _consumerService.GetUsersPicture(email.Email);
            if (imagePath == string.Empty)
            {
                return StatusCode(409, "User does not exist.");
            }

            if (imagePath == null)
            {
                return NoContent();
            }

            var file = Path.Combine(Directory.GetCurrentDirectory(), imagePath);
            return PhysicalFile(file, "image/png");
        }
    }
}
