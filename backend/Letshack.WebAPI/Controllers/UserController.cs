using Letshack.Application.Services;
using Letshack.WebAPI.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Letshack.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users.Select(u => new ProfileResponse(
                u!.Id,
                u.Initials,
                u.Description,
                u.Email ?? "",
                u.PhoneNumber ?? "",
                u.TgId ?? "",
                u!.IsVisible,
                u.UserTechnologies.Select(ut => new TechnologyResponse(ut.TechnologyId, ut.Technology.Title)).ToList()
            )));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(string id)
        {
            var user = await _userService.GetById(id);
            if (user is null) return BadRequest();

            return Ok(new ProfileResponse(
                    user!.Id,
                    user!.Initials,
                    user!.Description,
                    user.Email ?? "",
                    user.PhoneNumber ?? "",
                    user.TgId ?? "",
                    user!.IsVisible,
                    user.UserTechnologies
                        .Select(ut => new TechnologyResponse(ut.TechnologyId, ut.Technology.Title)).ToList()
            ));
        }
    }
}
