using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShoppingCartStarter.Shared.Cart;
using ShoppingCartStarter.Shared.Cart.LineItem;

namespace ShoppingCartStarter.Server.Endpoints.Cart
{
    [Route("api/cart")]
    public class ApiController : Controller
    {
        private readonly IMediator _mediator;

        public ApiController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Details([FromQuery] Details.Query query)
        {
            var cart = await _mediator.Send(query);
            return Ok(cart);
        }

        [HttpDelete("lines/{id}")]
        public async Task<IActionResult> Delete(Delete.Command command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut("lines")]
        public async Task<IActionResult> Update([FromBody]Update.Command command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}