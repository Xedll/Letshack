using Letshack.Application.Services;
using Letshack.Domain.Models;
using Letshack.WebAPI.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Letshack.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly TagService _tagService;

        public TagController(TagService tagService)
        {
            _tagService = tagService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tags = await _tagService.GetAllTags();
            return Ok(tags.Select(t => new TagResponse(t.Id, t.RelatedTopic.Title, t.Technology.Title)));
        }

        [Route("technology/{id:int}")]
        [HttpGet]
        public async Task<IActionResult> GetWithTechnology(int id)
        {
            var tags = await _tagService.GetAllTechnologyTags(id);
            var first = tags.FirstOrDefault();
            if (first is null) return NotFound();
            return Ok(new TechnologyTagResponse(first.TechnologyId
                , first.Technology.Title
                , tags.Select(t => new RelatedTopicResponse(t.RelatedTopicId, t.RelatedTopic.Title)).ToList()));
        }
        
        [Route("topic/{id:int}")]
        [HttpGet]
        public async Task<IActionResult> GetWitnTopic(int id)
        {
            var tags = await _tagService.GetAllTopicsTags(id);
            var first = tags.FirstOrDefault();
            if (first is null) return NotFound();
            return Ok(new RelatedTopicTagResponse(first.RelatedTopicId
                , first.RelatedTopic.Title
                , tags.Select(t => new TechnologyResponse(t.TechnologyId, t.Technology.Title)).ToList()));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TagRequest request)
        {
            if (!ModelState.IsValid) return BadRequest("invalid request");
            await _tagService.CreateTag(new Tag
            {
                RelatedTopicId = request.RelatedTopicId,
                TechnologyId = request.TechnologyId
            });
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _tagService.DeleteById(id);
            return Ok();
        }
    }
}
