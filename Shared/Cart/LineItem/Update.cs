using MediatR;

namespace ShoppingCartStarter.Shared.Cart.LineItem
{
    public class Update
    {
        public class Command : IRequest
        {
            public int Id { get; set; }
            public int Quantity { get; set; }
        }
    }
}