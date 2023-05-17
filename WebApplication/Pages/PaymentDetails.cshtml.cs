using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication.Models;

namespace WebApplication.Pages
{
    public class PaymentDetailsModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public PaymentDetailsModel(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        [BindProperty(SupportsGet = true)]
        public string OrderId { get; set; }

        public Payment Payment { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (string.IsNullOrEmpty(OrderId))
            {
                return NotFound();
            }

            var getPaymentResponse = await _httpClient.GetAsync($"https://localhost:44320/Payment/{OrderId}");
            if (getPaymentResponse.IsSuccessStatusCode)
            {
                Payment = await getPaymentResponse.Content.ReadFromJsonAsync<Payment>();
                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostSendShippingRequestAsync(string orderId)
        {
            // Send the request to the Shipping service
            var response = await _httpClient.PostAsync($"https://localhost:44330/Shipping/{orderId}", null);
            if (response.IsSuccessStatusCode)
            {
                TempData["Message"] = "Shipping request sent successfully.";
            }
            else
            {
                TempData["Message"] = "Failed to send the shipping request.";
            }

            return RedirectToPage("/Index");
        }
    }
}
