using System.Collections.Generic;
using MediatR;

namespace ShoppingCartStarter.Shared.Cart
{
    public class Details
    {
        public class Query : IRequest<Model>
        {
        }

        public class Model
        {
            public List<LineItem> Items { get; set; } = new List<LineItem>();

            public class LineItem
            {
                public int Id { get; set; }
                public string Name { get; set; }
                public int Quantity { get; set; }
                public decimal Price { get; set; }
                public string Image { get; set; }
            }
        }
    }
}