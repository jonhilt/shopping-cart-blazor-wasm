using MediatR;

namespace ShoppingCartStarter.Shared.Cart.LineItem
{
    public class Delete
    {
        public class Command : IRequest
        {
            public int Id { get; set; }
        }
    }
}