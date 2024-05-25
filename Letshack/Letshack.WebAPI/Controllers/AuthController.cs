using Letshack.Application.Services;
using Letshack.Domain.Models;
using Letshack.WebAPI.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Letshack.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }
        
        [HttpPost]
        [Route("login")]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> Login([FromBody] AuthRequest request)
        {
            if (!ModelState.IsValid) return BadRequest("invalid request");
            try
            {
                var token = await _authService.Login(new User
                {
                    UserName = request.Login,
                    PasswordHash = request.Password
                });
                return token is not null ? Ok(new AuthResponse(token)) : BadRequest("invalid request");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "internal server error");
            }

        }

        [HttpPost]
        [Route("register")]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> Register([FromBody] AuthRequest request)
        {
            if (!ModelState.IsValid) return BadRequest("invalid request");
            try
            {
                var isSucceed =
                    await _authService.RegisterUser(new User { UserName = request.Login }, request.Password);
                return isSucceed ? Ok() : BadRequest("invalid request");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "internal server error");
            }
        }
    }
}
