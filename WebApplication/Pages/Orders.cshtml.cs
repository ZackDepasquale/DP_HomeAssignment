using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication.Models;

namespace WebApplication.Pages
{
    public class OrdersModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public OrdersModel(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public List<Order> Orders { get; set; }
        public string SelectedOrderId { get; set; }
        public Order SelectedOrder { get; set; }
        public string ShippingDetailsId { get; set; }

        public async Task OnGetAsync(string orderId)
        {
            var getOrdersResponse = await _httpClient.GetAsync("https://ordermicroservice-mvug6bkbra-uc.a.run.app/Order");
            if (getOrdersResponse.IsSuccessStatusCode)
            {
                Orders = await getOrdersResponse.Content.ReadFromJsonAsync<List<Order>>();
            }
            else
            {
                Orders = new List<Order>();
            }

            if (!string.IsNullOrEmpty(orderId))
            {
                if (orderId.ToLower() == "all")
                {
                    SelectedOrderId = "All";
                    SelectedOrder = null;
                }
                else
                {
                    var getOrderResponse = await _httpClient.GetAsync($"https://ordermicroservice-mvug6bkbra-uc.a.run.app/Order/{orderId}");
                    if (getOrderResponse.IsSuccessStatusCode)
                    {
                        SelectedOrderId = orderId;
                        SelectedOrder = await getOrderResponse.Content.ReadFromJsonAsync<Order>();
                    }
                    else
                    {
                        SelectedOrderId = null;
                        SelectedOrder = null;
                    }
                }
            }
            else
            {
                SelectedOrderId = null;
                SelectedOrder = null;
            }
        }

        public bool PaymentMade(string orderId)
        {
            // Make a GET request to check if payment exists for the order
            var getPaymentResponse = _httpClient.GetAsync($"https://paymentmicroservice-mvug6bkbra-uc.a.run.app/Payment/{orderId}").Result;
            return getPaymentResponse.IsSuccessStatusCode;
        }

        public async Task<IActionResult> OnGetViewShippingDetailsAsync(string orderId)
        {
            var getDocIdResponse = await _httpClient.GetAsync($"https://shippingmicroservice-mvug6bkbra-uc.a.run.app/Shipping/GetDocId/{orderId}");
            if (getDocIdResponse.IsSuccessStatusCode)
            {
                ShippingDetailsId = await getDocIdResponse.Content.ReadAsStringAsync();
                return RedirectToPage("/ShippingDetails", new { shippingId = ShippingDetailsId });
            }
            else
            {
                // Failed to get the document reference ID
                return Page();
            }
        }
        public string GetShippingId(string orderId)
        {
            var getDocIdResponse = _httpClient.GetAsync($"https://shippingmicroservice-mvug6bkbra-uc.a.run.app/Shipping/GetDocId/{orderId}").Result;
            if (getDocIdResponse.IsSuccessStatusCode)
            {
                return getDocIdResponse.Content.ReadAsStringAsync().Result;
            }
            return null;
        }

    }
}