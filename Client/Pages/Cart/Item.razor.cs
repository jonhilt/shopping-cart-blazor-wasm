using Microsoft.AspNetCore.Components;
using ShoppingCartStarter.Shared.Cart;

namespace ShoppingCartStarter.Client.Pages.Cart
{
    public class ItemBase : ComponentBase
    {
        [Parameter]
        public Details.Model.LineItem Details { get; set; }
    }
}