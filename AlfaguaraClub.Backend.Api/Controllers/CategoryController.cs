using AlfaguaraClub.Backend.Application.Services.CategoryServices.CreateCategoryCommands;
using AlfaguaraClub.Backend.Application.Services.CategoryServices.QueryCategoryCommands;
using AlfaguaraClub.Backend.Application.Services.CategoryServices.UpdateCategoryCommands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlfaguaraClub.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet(Name = "GetAllCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<CategoryListVm>>> GetAllCategories()
        {
            var categories = await _mediator.Send(new GetCategoryListQuery());
            return Ok(categories);
        }
        [HttpPost(Name = "AddCategory")]
        public async Task<ActionResult<CreateCategoryCommandResponse>> Create([FromBody] CreateCategoryCommand createCategoryCommand)
        {
            var newCategory = await _mediator.Send(createCategoryCommand);
            return Ok(newCategory);
        }
        [HttpPut(Name = "UpdateCategory")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateCategoryCommand updateCategoryCommand)
        {
            await _mediator.Send(updateCategoryCommand);
            return NoContent();
        }
    }
}
