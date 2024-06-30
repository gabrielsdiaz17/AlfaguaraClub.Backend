using AlfaguaraClub.Backend.Application.Services.PictureServices.CreatePictureCommands;
using AlfaguaraClub.Backend.Application.Services.PictureServices.QueryPictureCommands;
using AlfaguaraClub.Backend.Application.Services.PictureServices.UpdatePictureCommands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlfaguaraClub.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PictureController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PictureController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet(Name = "GetAllPictures")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<PictureListVm>>> GetAllPictures()
        {
            var pictures = await _mediator.Send(new GetPictureListQuery());
            return Ok(pictures);
        }

        [HttpGet("/GetPictureById/{id}", Name = "GetPictureById")]
        public async Task<ActionResult<PictureListVm>> GetPictureById(long id)
        {
            var picture = new GetPictureQuery() { PictureId = id };
            return Ok(await _mediator.Send(picture));
        }
        [HttpGet("/GetPictureBySpace/{id}", Name = "GetPictureBySpace")]
        public async Task<ActionResult<List<PictureListVm>>> GetPictureBySpace(long id)
        {
            var picturesSpace = new GetPicturesBySpaceListQuery() { SpaceId = id };
            return Ok(await _mediator.Send(picturesSpace));
        }

        [HttpGet("/GetPictureByStory/{id}", Name = "GetPictureByStory")]
        public async Task<ActionResult<List<PictureListVm>>> GetPictureByStory(long id)
        {
            var picturesStory = new GetPicturesByStoryListQuery() { StoryId = id };
            return Ok(await _mediator.Send(picturesStory));
        }
        [HttpPost(Name = "AddPicture")]
        public async Task<ActionResult<CreatePictureCommandResponse>> Create([FromBody] CreatePictureCommand createPictureCommand)
        {
            var newPicture = await _mediator.Send(createPictureCommand);
            return Ok(newPicture);
        }

        [HttpPut(Name = "UpdatePicture")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdatePictureCommand updatePictureCommand)
        {
            await _mediator.Send(updatePictureCommand);
            return NoContent();
        }
    }
}
