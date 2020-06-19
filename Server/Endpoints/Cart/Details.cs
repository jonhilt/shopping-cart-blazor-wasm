using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShoppingCartStarter.Server.Data;
using ShoppingCartStarter.Shared.Cart;

namespace ShoppingCartStarter.Server.Endpoints.Cart
{
    public class CartDetailsHandler : IRequestHandler<Details.Query, Details.Model>
    {
        private readonly StoreContext _context;

        public CartDetailsHandler(StoreContext context)
        {
            _context = context;
        }

        public async Task<Details.Model> Handle(Details.Query request, CancellationToken cancellationToken)
        {
            // in reality we'd retrieve a specific cart (for the current user/session) but for demo
            // purposes this just pulls back the first cart it finds
            
            var cart = await _context.Carts
                .Include(x => x.LineItems)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (cart != null)
            {
                return new Details.Model
                {
                    Items = cart.LineItems.Select(x => new Details.Model.LineItem
                    {
                        Id = x.Id,
                        Image = x.Image,
                        Name = x.Name,
                        Price = x.Price,
                        Quantity = x.Quantity
                    }).ToList()
                };
            }
            return new Details.Model();
        }
    }
}