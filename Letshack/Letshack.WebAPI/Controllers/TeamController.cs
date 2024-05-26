using Letshack.Application.Services;
using Letshack.Domain.Models;
using Letshack.WebAPI.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Letshack.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly TeamService _teamService;
        private readonly UserManager<User> _userManager;

        public TeamController(TeamService teamService, UserManager<User> userManager)
        {
            _teamService = teamService;
            _userManager = userManager;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TeamRequest request)
        {
            if (!ModelState.IsValid) return BadRequest("invalid request");
            
            var user = await _userManager.GetUserAsync(User);
            if (user is null) return Unauthorized();

            var result = await _teamService.Create(new Team
            {
                Description = request.Description,
                Title = request.Title,
                CreatorId = user.Id,
                CreatedAt = DateTime.UtcNow
            }, request.NeededRoles);
            return result is true ? Ok() : BadRequest();
        }

        [Authorize]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Edit(int id, [FromBody] TeamEditRequest request)
        {
            if (!ModelState.IsValid) return BadRequest("invalid request");
            
            var user = await _userManager.GetUserAsync(User);
            if (user is null) return Unauthorized();
            var res = await _teamService.UpdateTeam(id,
                user.Id, request.Title, request.Description, request.NeededRoles);
            
            return res is true ? Ok() : BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var teams = await _teamService.GetAll();
            return Ok(teams.Select(t => new TeamResponse(
                t.Id,
                new TeamCreator(t.CreatorId, t.Creator.UserName!, t.Creator.TgId ?? "", t.Creator.PhoneNumber ?? "", t.Creator.Email ?? ""),
                t.Title,
                t.Description,
                t.CreatedAt,
                [],
                t.NeededRoles.Select(nr => new TeamRole(nr.RoleId, nr.Role.Title)).ToList()
            )));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var team = await _teamService.GetById(id);
            if (team is null) return BadRequest();

            return Ok(new TeamResponse(
                team.Id,
                new TeamCreator(team.CreatorId, team.Creator.UserName!, team.Creator.TgId ?? "", team.Creator.PhoneNumber ?? "", team.Creator.Email ?? ""),
                team.Title,
                team.Description,
                team.CreatedAt,
                [],
                team.NeededRoles.Select(nr => new TeamRole(nr.RoleId, nr.Role.Title)).ToList()
            ));
        }
    }
}
