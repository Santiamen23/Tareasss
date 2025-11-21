using Microsoft.AspNetCore.Mvc;
using TareaTecWeb.Models.Dtos;
using TareaTecWeb.Services;

namespace BooksTW.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _service;
        public AuthController(IAuthService service)
        {
            _service = service;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var (ok, response) = await _service.login(dto);
            if (!ok || response is null) return Unauthorized();
            return Ok(response);
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var id = await _service.register(dto);
            return CreatedAtAction(nameof(Register), new { id }, null);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] RefreshRequestDto dto)
        {
            var (ok, response) = await _service.refresh(dto);
            if (!ok || response is null) return Unauthorized();
            return Ok(response);
        }
    }
}
