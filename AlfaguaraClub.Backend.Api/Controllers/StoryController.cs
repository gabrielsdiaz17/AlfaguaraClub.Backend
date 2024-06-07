
using AlfaguaraClub.Backend.Application.Services.StoryServices.CreateStoryCommands;
using AlfaguaraClub.Backend.Application.Services.StoryServices.QueryStoryCommands;
using AlfaguaraClub.Backend.Application.Services.StoryServices.UpdateStoryCommands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlfaguaraClub.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StoryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet(Name = "GetAllStories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<StoryListVm>>> GetAllStories()
        {
            var stories = await _mediator.Send(new GetStoryListQuery());
            return Ok(stories);
        }

        [HttpGet("/GetStoryById/{id}", Name = "GetStoryById")]
        public async Task<ActionResult<StoryListVm>> GetStoryById(long id)
        {
            var getStoryQuery = new GetStoryQuery() { StoryId = id };
            return Ok(await _mediator.Send(getStoryQuery));

        }

        [HttpGet("/GetStoryQuantity/{quantity}", Name = "GetStoryQuantity")]
        public async Task<ActionResult<List<StoryListVm>>> GetStoryQuantity(int quantity)
        {
            var getStoryQuantity = new GetStoryListQuantity() { QuantityStories = quantity };
            return Ok(await _mediator.Send(getStoryQuantity));

        }

        [HttpGet("/GetStoryByCategory/{categoryId}", Name = "GetStoryByCategory")]
        public async Task<ActionResult<List<StoryListVm>>> GetStoryByCategory(int categoryId)
        {
            var getStoriesByCategory = new GetStoryListByCategory() { CategoryId = categoryId };
            return Ok(await _mediator.Send(getStoriesByCategory));
        }

        [HttpPost(Name = "AddStory")]
        public async Task<ActionResult<CreateStoryCommandResponse>> Create([FromBody] CreateStoryCommand createStoryCommand)
        {
            var response = await _mediator.Send(createStoryCommand);
            return Ok(response);
        }

        [HttpPut(Name = "UpdateStory")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateStoryCommand updateStoryCommand)
        {
            await _mediator.Send(updateStoryCommand);
            return NoContent();
        }
    }
}
