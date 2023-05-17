using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication.Models;

namespace WebApplication.Pages
{
    public class ShippingDetailsModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public ShippingDetailsModel(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        [BindProperty(SupportsGet = true)]
        public string ShippingId { get; set; }

        public ShippingDetails ShippingDetails { get; set; }
 
        public async Task<IActionResult> OnGetAsync()
        {
            if (string.IsNullOrEmpty(ShippingId))
            {
                return NotFound();
            }

            var getShippingDetailsResponse = await _httpClient.GetAsync($"https://localhost:44330/Shipping/{ShippingId}");
            if (getShippingDetailsResponse.IsSuccessStatusCode)
            {
                ShippingDetails = await getShippingDetailsResponse.Content.ReadFromJsonAsync<ShippingDetails>();
                return Page();
            }

            return NotFound();
        }
    }
}
