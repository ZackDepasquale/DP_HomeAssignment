using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Pages
{
    public class ProductDetailsModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly HttpClient _httpClient;

        public ProductDetailsModel(IHttpClientFactory clientFactory, IHttpContextAccessor httpContextAccessor)
        {
            _clientFactory = clientFactory;
            _httpContextAccessor = httpContextAccessor;
            _httpClient = _clientFactory.CreateClient();
        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:44396/Product/{Id}");

            if (response.IsSuccessStatusCode)
            {
                Product = await response.Content.ReadFromJsonAsync<Product>();
                return Page();
            }
            else
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var client = _clientFactory.CreateClient();

            // Get the UserId from the backend
            string userEmail = _httpContextAccessor.HttpContext.Session.GetString("UserEmail");
            var getUserIdResponse = await _httpClient.GetAsync($"https://localhost:44382/User/getUserId?email={userEmail}");
            
            if (getUserIdResponse.IsSuccessStatusCode)
            {
                var userIdResult = await getUserIdResponse.Content.ReadFromJsonAsync<UserResponse>();
                if (userIdResult != null)
                {
                    var order = new Order
                    {
                        Id = Guid.NewGuid(),
                        UserId = userIdResult.UserId,
                        Products = new List<Product>
                        {
                            new Product
                            {
                                Id = Id
                            }
                        }
                    };

                    var response = await client.PostAsJsonAsync("https://localhost:44381/Order", order);

                    if (response.IsSuccessStatusCode)
                    {
                        // Add the order received notification
                        var notification = new Notification
                        {
                            UserId = userIdResult.UserId,
                            Message = $"Order Received, Not Yet Dispatched: {order.Id}",
                            Date = DateTime.UtcNow
                        };

                        var notificationResponse = await client.PostAsJsonAsync("https://localhost:44382/User/notifications", notification);
                        if (!notificationResponse.IsSuccessStatusCode)
                        {
                            // Handle the failure to create the notification
                            // You can choose to log the error or take appropriate action
                        }

                        TempData["Message"] = "Item added to order successfully.";
                        return RedirectToPage("/Index");
                    }
                }
            }
            
            TempData["Message"] = "Failed to add item to order.";
            return Page();
        }
    }
}