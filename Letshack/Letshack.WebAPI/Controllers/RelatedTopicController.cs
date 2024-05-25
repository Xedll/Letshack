using Letshack.Application.Services;
using Letshack.Domain.Models;
using Letshack.WebAPI.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Letshack.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RelatedTopicController : ControllerBase
    {
        private readonly RelatedTopicService _relatedTopicService;

        public RelatedTopicController(RelatedTopicService relatedTopicService)
        {
            _relatedTopicService = relatedTopicService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
           var topics = await _relatedTopicService.GetAllTopics();
           return Ok(topics.Select(t => new RelatedTopicResponse(t.Id, t.Title)));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var topic = await _relatedTopicService.GetById(id);
            return Ok(new RelatedTopicResponse(topic.Id, topic.Title));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RelatedTopicRequest request)
        {
            if (!ModelState.IsValid) return BadRequest();
            await _relatedTopicService.CreateRelatedTopic(new RelatedTopic
            {
                Title = request.Title
            });
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _relatedTopicService.DeleteById(id);
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id,[FromBody] RelatedTopicRequest request)
        {
            if (!ModelState.IsValid) return BadRequest("invalid request");
            await _relatedTopicService.UpdateRelatedTopic(new RelatedTopic
            {
                Id = id,
                Title = request.Title
            });
            return Ok();
        }
    }
}
