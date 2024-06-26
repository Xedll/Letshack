using Letshack.Application.Services;
using Letshack.Domain.Models;
using Letshack.WebAPI.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Letshack.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly UserService _userService;

        public ProfileController(UserManager<User> userManager, UserService userService)
        {
            _userManager = userManager;
            _userService = userService;
        }
        

        [Route("manage")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user is null) return Unauthorized();
            var userTeams = await _userService.GetById(user.Id);
            var userTechnologies = await _userService.GetUserTechnology(user.Id);
            return Ok(new ManageProfileResponse(
                    user!.Id,
                    user!.Initials
                    ,user!.Description
                    , user.Email ?? ""
                    , user.PhoneNumber ?? ""
                    , user.TgId ?? ""
                    ,user!.IsVisible
                    , userTechnologies
                        .Select(ut => new TechnologyResponse(ut.Id, ut.Title)).ToList(),
                    userTeams!.Teams.Select(t => new TeamHistory(t.Title, t.Description)).ToList()
                ));
        }
        
        [Route("manage")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] ProfileRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var user = await _userManager.GetUserAsync(User);
            if (user is null) return Unauthorized();

            user.Initials = request.Initials;
            user.TgId = request?.TgId ?? "";
            user.Description = request!.Description;
            user.PhoneNumber = request?.Number ?? "";
            user.Email = request?.Email ?? "";
            user.IsVisible = request!.IsVisible;
            
            await _userService.UpdateUserTechnologies(user.Id, request.TechnologiesList);
            await _userManager.UpdateAsync(user);
            
            return Ok();
        }

        [Route("manage/visible")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CheckBoxRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var user = await _userManager.GetUserAsync(User);
            if (user is null) return Unauthorized();

            
            user.IsVisible = request!.IsVisible;
            await _userManager.UpdateAsync(user);
            return Ok();
        }
    }
}
