
using EmployeesPortal.DTOs;
using EmployeesPortal.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace EmployeesPortal.Controllers.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService service;

        public AuthController(IAuthService service)
        {
            this.service = service;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var result = await service.RegisterDtoAsync(dto);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var token = await service.LoginAsync(dto);
            return Ok(new { Token = token });
        }
    }
}
