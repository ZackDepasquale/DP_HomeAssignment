using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication.Models;

namespace WebApplication.Pages
{
    public class OrderDetailsModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public OrderDetailsModel(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        [BindProperty(SupportsGet = true)]
        public string OrderId { get; set; }

        public Order SelectedOrder { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (string.IsNullOrEmpty(OrderId))
            {
                return NotFound();
            }

            var getOrderResponse = await _httpClient.GetAsync($"https://localhost:44381/Order/{OrderId}");
            if (getOrderResponse.IsSuccessStatusCode)
            {
        SelectedOrder = await getOrderResponse.Content.ReadFromJsonAsync<Order>();
        
        // Calculate the total amount
        SelectedOrder.TotalAmount = SelectedOrder.Products.Sum(product => product.Price);
        
        return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostCreatePaymentAsync(string userId, string orderId, decimal amount)
        {
            // Create the payment
            var payment = new Payment
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                OrderId = orderId,
                Amount = amount
            };

            // Send the post request to create the payment
            var createPaymentResponse = await _httpClient.PostAsJsonAsync("https://localhost:44320/Payment", payment);

            if (createPaymentResponse.IsSuccessStatusCode)
            {
                TempData["Message"] = "Payment created successfully.";
                return RedirectToPage("/Index");
            }
            else
            {
                TempData["Message"] = "Failed to create payment.";
                return Page();
            }
        }
    }
}
