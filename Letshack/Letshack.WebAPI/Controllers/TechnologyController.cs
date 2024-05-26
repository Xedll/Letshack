using Letshack.Application.Services;
using Letshack.Domain.Models;
using Letshack.WebAPI.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Letshack.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologyController : ControllerBase
    {
        private readonly TechnologyService _technologyService;

        public TechnologyController(TechnologyService technologyService)
        {
            _technologyService = technologyService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var technologies = await _technologyService.GetAllTechnologies();
            return Ok(technologies.Select(t => new TechnologyResponse(t.Id, t.Title)));
        }
        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var technology = await _technologyService.GetById(id);
            return Ok(new TechnologyResponse(technology.Id, technology.Title));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TechnologyRequest request)
        {
            if (!ModelState.IsValid) return BadRequest("invalid request");
            await _technologyService.CreateTechnology(new Technology
            {
                Title = request.Title
            });
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _technologyService.DeleteById(id);
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] TechnologyRequest request)
        {
            if (!ModelState.IsValid) return BadRequest("invalid request");
            await _technologyService.UpdateTechnology(new Technology
            {
                Id = id,
                Title = request.Title
            });
            return Ok();
        }
    }
}
