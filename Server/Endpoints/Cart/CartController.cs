using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShoppingCartStarter.Shared.Cart;

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
    }
}