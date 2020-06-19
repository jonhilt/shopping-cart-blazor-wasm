using System.Collections.Generic;

namespace ShoppingCartStarter.Server.DomainModels
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public int SessionId { get; set; }
        public List<LineItem> LineItems { get; set; } = new List<LineItem>();
    }

    public class LineItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
    }
}