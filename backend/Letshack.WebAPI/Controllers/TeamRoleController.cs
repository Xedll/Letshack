using Letshack.Application.Services;
using Letshack.Domain.Models;
using Letshack.WebAPI.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Letshack.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamRoleController : ControllerBase
    {
        private readonly TeamRoleService _teamRoleService;

        public TeamRoleController(TeamRoleService teamRoleService)
        {
            _teamRoleService = teamRoleService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
           var roles = await _teamRoleService.GetAllTeamRoles();
           return Ok(roles.Select(r => new TeamRoleResponse(r.Id, r.Title)));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var role = await _teamRoleService.GetTeamRoleById(id);
            return Ok(new TeamRoleResponse(role.Id, role.Title));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TeamRoleRequest request)
        {
            if (!ModelState.IsValid) return BadRequest("invalid request");

            await _teamRoleService.CreateTeamRole(new Role
            {
                Title = request.Title
            });
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _teamRoleService.DeleteTeamRole(id);
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id,[FromBody] TeamRoleRequest request)
        {
            await _teamRoleService.UpdateTeamRole(new Role
            {
                Id = id,
                Title = request.Title
            });
            return Ok();
        }
    }
}
