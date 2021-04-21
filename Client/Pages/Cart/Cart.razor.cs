using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using ShoppingCartStarter.Shared.Cart;

namespace ShoppingCartStarter.Client.Pages.Cart
{
    public class CartBase : ComponentBase
    {
        [Inject] private HttpClient Http { get; set; }

        protected Details.Model Model { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Model = await Http.GetFromJsonAsync<Details.Model>("api/cart");
        }
    }
}