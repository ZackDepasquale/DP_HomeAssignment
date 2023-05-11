using Newtonsoft.Json;
using ProductCatalogueMicroservice.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProductCatalogueMicroservice.Services
{
    public class ProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Product>> GetProductsByCategory(string category)
        {
            var response = await _httpClient.GetAsync($"https://fakestoreapi.com/products/category/{category}");

            if (response.IsSuccessStatusCode)
            {
                var products = JsonConvert.DeserializeObject<List<Product>>(await response.Content.ReadAsStringAsync());
                return products;
            }

            return null;
        }

        public async Task<Product> GetProductById(int id)
        {
            var response = await _httpClient.GetAsync($"https://fakestoreapi.com/products/{id}");

            if (response.IsSuccessStatusCode)
            {
                var product = JsonConvert.DeserializeObject<Product>(await response.Content.ReadAsStringAsync());
                return product;
            }

            return null;
        }
    }
}
