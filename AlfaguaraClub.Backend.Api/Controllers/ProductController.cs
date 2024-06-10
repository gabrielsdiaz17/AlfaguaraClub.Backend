using AlfaguaraClub.Backend.Application.Services.ProductServices.CreateProductCommands;
using AlfaguaraClub.Backend.Application.Services.ProductServices.QueryProductCommands;
using AlfaguaraClub.Backend.Application.Services.ProductServices.UpdateProductCommands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlfaguaraClub.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet(Name = "GetAllProducts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<ProductListVm>>> GetAllProducts()
        {
            var products = await _mediator.Send(new GetProductListQuery());
            return Ok(products);
        }
        [HttpGet("/GetProductById/{id}", Name = "GetProductById")]
        public async Task<ActionResult<ProductListVm>> GetProductById(long id)
        {
            var product = new GetProductQuery() { ProductId = id };
            return Ok(await _mediator.Send(product));
        }

        [HttpGet("/GetProductByCode/{code}", Name = "GetProductByCode")]
        public async Task<ActionResult<ProductListVm>> GetProductByCode(string code)
        {
            var product = new GetProductCodeQuery() { Code = code };
            return Ok(await _mediator.Send(product));
        }

        [HttpPost(Name = "AddProduct")]
        public async Task<ActionResult<CreateProductCommandResponse>> Create([FromBody] CreateProductCommand createProductCommand)
        {
            var newProduct = await _mediator.Send(createProductCommand);
            return Ok(newProduct);
        }

        [HttpPut(Name = "UpdateProduct")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateProductCommand updateProductCommand)
        {
            await _mediator.Send(updateProductCommand);
            return NoContent();
        }
    }
}
