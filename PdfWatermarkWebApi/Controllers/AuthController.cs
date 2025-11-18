using Microsoft.AspNetCore.Mvc;
using PdfWatermarkWebApi.Entities;
using PdfWatermarkWebApi.Models;
using PdfWatermarkWebApi.Service;
using PdfWatermarkWebApi.Common;

namespace PdfWatermarkWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public AuthController (
            IConfiguration configuration, 
            IUserService userService
            )
        {
            _configuration = configuration;
            _userService = userService;
        }

        [HttpPost("CheckUser")]
        public IActionResult CheckUser([FromBody] EmailRequest request)
        {
            try
            {
                var user = new
                {
                    UserId = Guid.NewGuid(),
                    Name = "John Doe"
                };
                return Ok(ApiResponse<object>.Ok(user));
            }
            catch (Exception)
            {
                throw new Exception("Check failed");
            }
        }
    }
}
