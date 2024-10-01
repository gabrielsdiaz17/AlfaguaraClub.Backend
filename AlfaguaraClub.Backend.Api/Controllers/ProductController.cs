using AlfaguaraClub.Backend.Application.Services.ProductServices.CreateProductCommands;
using AlfaguaraClub.Backend.Application.Services.ProductServices.QueryProductCommands;
using AlfaguaraClub.Backend.Application.Services.ProductServices.UpdateProductCommands;
using MediatR;
using MercadoPago.Config;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MercadoPago.Config;
using MercadoPago.Client.Preference;
using MercadoPago.Resource.Preference;
using AlfaguaraClub.Backend.Application.Services.ProductServices.ShoppingCardCommands;
using AlfaguaraClub.Backend.Application.Services.UserInfoServices.CreateUserInfoCommands;

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
        [HttpGet("GetProductById/{id}", Name = "GetProductById")]
        public async Task<ActionResult<ProductListVm>> GetProductById(long id)
        {
            var product = new GetProductQuery() { ProductId = id };
            return Ok(await _mediator.Send(product));
        }

        [HttpGet("GetProductByCode/{code}", Name = "GetProductByCode")]
        public async Task<ActionResult<ProductListVm>> GetProductByCode(string code)
        {
            var product = new GetProductCodeQuery() { Code = code };
            return Ok(await _mediator.Send(product));
        }

        [HttpPost(Name = "AddProduct"), Authorize]
        public async Task<ActionResult<CreateProductCommandResponse>> Create([FromBody] CreateProductCommand createProductCommand)
        {
            var newProduct = await _mediator.Send(createProductCommand);
            return Ok(newProduct);
        }

        [HttpPost("AddItemToBuy", Name = "AddItemToBuy")]
        public async Task<ActionResult> AddItemToBuy([FromBody] ShoppingCardCommand shoppingCardCommand)
        {
            // SDK de Mercado Pago

            // Agrega credenciales
            MercadoPagoConfig.AccessToken = "APP_USR-1496588329103205-082919-ce0818dd4aaae049745a7dbb24c00c80-1957771295";
            //Configura url de retorno 
            var successUrl = string.Format("https://espaciosalfaguara.com/payment/failurepayment/{0}", shoppingCardCommand.CreateUserInfoCommand.IdentificationNumber);
            var pendingUrl = string.Format("https://espaciosalfaguara.com/payment/pendingpayment/{0}", shoppingCardCommand.CreateUserInfoCommand.IdentificationNumber);
            var failureUrl = string.Format("https://espaciosalfaguara.com/payment/successpayment/{0}", shoppingCardCommand.CreateUserInfoCommand.IdentificationNumber);
            var backUrls = new PreferenceBackUrlsRequest
            {
                Success = successUrl,
                Pending = pendingUrl,
                Failure = failureUrl
            };
            var request = new PreferenceRequest
            {
                Items = shoppingCardCommand.PreferenceRequest, 
                BackUrls = backUrls
            };
            // Crea la preferencia usando el client
            var newUserInfo = await _mediator.Send(shoppingCardCommand.CreateUserInfoCommand);

            var client = new PreferenceClient();
            Preference preference = await client.CreateAsync(request);
            return Ok(preference);
        }

        [HttpPut(Name = "UpdateProduct"), Authorize]
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
