using Letshack.Application.Services;
using Letshack.Domain.Models;
using Letshack.WebAPI.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Letshack.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly UserManager<User> _userManager;
        private readonly UserService _userService;

        public AuthController(AuthService authService, UserManager<User> userManager, UserService userService)
        {
            _authService = authService;
            _userManager = userManager;
            _userService = userService;
        }
        

        [HttpPost]
        [Route("login")]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> Login([FromBody] AuthRequest request)
        {
            if (!ModelState.IsValid) return BadRequest("invalid request");
            try
            {
                var user = await _userService.GetByLogin(request.Login);
                var token = await _authService.Login(new User
                {
                    UserName = request.Login,
                    PasswordHash = request.Password
                });
                if (token is null) return BadRequest("invalid request");
                if (user is null) return Unauthorized();
                var userTechnologies = await _userService.GetUserTechnology(user.Id);
                return Ok(new AuthResponse(token, new ProfileResponse(
                    user!.Initials
                    , user!.Description
                    , user.Email ?? ""
                    , user.PhoneNumber ?? ""
                    , user.TgId ?? ""
                    , user!.IsVisible
                    , userTechnologies
                        .Select(ut => new TechnologyResponse(ut.Id, ut.Title)).ToList()
                )));
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
                return isSucceed ? Ok(new RegisterResponse(request.Login, request.Password)) : BadRequest("invalid request");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "internal server error");
            }
        }
    }
}
