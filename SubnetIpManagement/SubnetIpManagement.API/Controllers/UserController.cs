using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SubnetIpManagement.API.Dtos;
using SubnetIpManagement.API.Services;

namespace SubnetIpManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(AuthService authService) : ControllerBase
    {
        private readonly AuthService _authService = authService;

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDto dto)
        {
            var result = await _authService.RegisterAsync(dto);
            if (!result)
                return BadRequest("Email is already taken.");
            return Ok("Registration successful.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserDto dto)
        {
            var token = await _authService.LoginAsync(dto);
            if (token is null)
                return Unauthorized("Invalid email or password.");
            return Ok(new { Token = token });
        }
    }
}
