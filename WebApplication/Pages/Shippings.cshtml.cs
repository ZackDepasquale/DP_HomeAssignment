using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WebApplication.Models;

namespace WebApplication.Pages
{
    public class ShippingsModel : PageModel
    {

        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ShippingsModel(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpContextAccessor = httpContextAccessor;
        }

        public List<Shipping> ShippingList { get; set; }
        public bool IsAdmin { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var getShippingResponse = await _httpClient.GetAsync("https://shippingmicroservice-mvug6bkbra-uc.a.run.app/Shipping");
            if (getShippingResponse.IsSuccessStatusCode)
            {
                ShippingList = await getShippingResponse.Content.ReadFromJsonAsync<List<Shipping>>();
            }
            else
            {
                ShippingList = new List<Shipping>();
            }

            // Check if the user is an admin
            var loggedInUser = _httpContextAccessor.HttpContext.Session.GetString("UserEmail");
            var isAdmin = _httpContextAccessor.HttpContext.Session.GetString("IsAdmin");
            IsAdmin = !string.IsNullOrEmpty(loggedInUser) && bool.Parse(isAdmin);

            return Page();
        }

        public async Task<IActionResult> OnPostUpdateStatusAsync(string orderId)
        {
            // Get the userId from the backend
            string userEmail = _httpContextAccessor.HttpContext.Session.GetString("UserEmail");
            var getUserIdResponse = await _httpClient.GetAsync($"https://customersmicroservice-mvug6bkbra-uc.a.run.app/User/getUserId?email={userEmail}");

            if (getUserIdResponse.IsSuccessStatusCode)
            {
                var getUserIdResult = await getUserIdResponse.Content.ReadFromJsonAsync<UserDetailsResponse>();
                var userId = getUserIdResult.UserId;

                var getDocumentIdUrl = $"https://shippingmicroservice-mvug6bkbra-uc.a.run.app/Shipping/GetDocId/{orderId}";
                var getDocumentIdResponse = await _httpClient.GetAsync(getDocumentIdUrl);
                if (getDocumentIdResponse.IsSuccessStatusCode)
                {
                    var documentId = await getDocumentIdResponse.Content.ReadAsStringAsync();

                    var updateStatusUrl = $"https://shippingmicroservice-mvug6bkbra-uc.a.run.app/Shipping/UpdateStatus";
                    var updateStatusRequest = new UpdateStatusRequest
                    {
                        OrderId = documentId
                    };

                    var content = new StringContent(JsonConvert.SerializeObject(updateStatusRequest), Encoding.UTF8, "application/json");
                    var response = await _httpClient.PostAsync(updateStatusUrl, content);
                    if (response.IsSuccessStatusCode)
                    {
                        // Update the shipping status successfully

                        // Add the order delivered and received notification
                        var notification = new Notification
                        {
                            UserId = userId,
                            Message = $"Order Delivered And Received: {orderId}",
                            Date = DateTime.UtcNow
                        };

                        var notificationResponse = await _httpClient.PostAsJsonAsync("https://customersmicroservice-mvug6bkbra-uc.a.run.app/User/notifications", notification);
                        if (notificationResponse.IsSuccessStatusCode)
                        {
                            return RedirectToPage();
                        }
                        else
                        {
                            // Handle the failure to create the notification
                            // You can choose to log the error or take appropriate action
                        }
                    }
                }
            }

            // Failed to update the shipping status or retrieve userId
            return BadRequest("Failed to update the shipping status or retrieve userId.");
        }




        public class UpdateStatusRequest
        {
            public string OrderId { get; set; }
            public string ShippingStatus { get; set; }
        }
    }
}
