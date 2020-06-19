using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShoppingCartStarter.Server.Data;
using ShoppingCartStarter.Shared.Cart.LineItem;

namespace ShoppingCartStarter.Server.Endpoints.Cart.LineItem
{
    public class DeleteHandler : AsyncRequestHandler<Delete.Command>
    {
        private readonly StoreContext _context;

        public DeleteHandler(StoreContext context)
        {
            _context = context;
        }

        protected override async Task Handle(Delete.Command request, CancellationToken cancellationToken)
        {
            // in reality we'd have more than one cart and would need to locate the correct one here
            // for the current user/session
            
            var cart = await _context.Carts.Include(x => x.LineItems)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);
            
            var toDelete = cart.LineItems.Single(x => x.Id == request.Id);
            cart.LineItems.Remove(toDelete);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}