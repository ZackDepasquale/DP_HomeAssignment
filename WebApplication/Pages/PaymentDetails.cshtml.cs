using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication.Models;

namespace WebApplication.Pages
{
    public class PaymentDetailsModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PaymentDetailsModel(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpContextAccessor = httpContextAccessor;
        }

        [BindProperty(SupportsGet = true)]
        public string OrderId { get; set; }

        public Payment Payment { get; set; }
        public bool IsAdmin { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (string.IsNullOrEmpty(OrderId))
            {
                return NotFound();
            }

            var getPaymentResponse = await _httpClient.GetAsync($"https://paymentmicroservice-mvug6bkbra-uc.a.run.app/Payment/{OrderId}");
            if (getPaymentResponse.IsSuccessStatusCode)
            {
                Payment = await getPaymentResponse.Content.ReadFromJsonAsync<Payment>();

                // Check if the user is an admin
                var loggedInUser = _httpContextAccessor.HttpContext.Session.GetString("UserEmail");
                var isAdmin = _httpContextAccessor.HttpContext.Session.GetString("IsAdmin");
                IsAdmin = !string.IsNullOrEmpty(loggedInUser) && bool.Parse(isAdmin);

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostSendShippingRequestAsync(string orderId)
        {
            // Get the userId from the backend
            string userEmail = _httpContextAccessor.HttpContext.Session.GetString("UserEmail");
            var getUserIdResponse = await _httpClient.GetAsync($"https://customersmicroservice-mvug6bkbra-uc.a.run.app/User/getUserId?email={userEmail}");

            if (getUserIdResponse.IsSuccessStatusCode)
            {
                var getUserIdResult = await getUserIdResponse.Content.ReadFromJsonAsync<UserDetailsResponse>();
                var userId = getUserIdResult.UserId;

                // Send the request to the Shipping service
                var response = await _httpClient.PostAsync($"https://shippingmicroservice-mvug6bkbra-uc.a.run.app/Shipping/{orderId}", null);
                if (response.IsSuccessStatusCode)
                {
                    // Add the order dispatched notification
                    var notification = new Notification
                    {
                        UserId = userId,
                        Message = $"Order Dispatched: {orderId}",
                        Date = DateTime.UtcNow
                    };

                    // Send the post request to add the notification
                    var createNotificationResponse = await _httpClient.PostAsJsonAsync("https://customersmicroservice-mvug6bkbra-uc.a.run.app/User/notifications", notification);

                    if (createNotificationResponse.IsSuccessStatusCode)
                    {
                        TempData["Message"] = "Shipping request sent successfully. Order dispatched notification added.";
                    }
                    else
                    {
                        TempData["Message"] = "Shipping request sent successfully. Failed to add the order dispatched notification.";
                    }

                    return RedirectToPage("/Index");
                }
                else
                {
                    TempData["Message"] = "Failed to send the shipping request.";
                    return RedirectToPage("/Index");
                }
            }
            else
            {
                TempData["Message"] = "Failed to retrieve the user ID.";
                return RedirectToPage("/Index");
            }
        }
    }
}
