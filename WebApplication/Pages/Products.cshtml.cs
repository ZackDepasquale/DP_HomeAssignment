using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication.Models;

namespace WebApplication.Pages
{
    public class ProductsModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public ProductsModel(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public string SelectedCategory { get; set; }
        public List<Product> Products { get; set; }

        public async Task<IActionResult> OnGetAsync(string category)
        {
            SelectedCategory = category;
            Products = await GetProductsByCategory(category);

            return Page();
        }

        private async Task<List<Product>> GetProductsByCategory(string category)
        {
            var response = await _httpClient.GetAsync($"https://localhost:44396/Product?category={category}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<Product>>();
            }

            return new List<Product>();
        }
    }
}
