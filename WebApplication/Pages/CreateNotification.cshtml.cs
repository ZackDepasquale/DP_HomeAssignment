using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Pages
{
    public class CreateNotificationModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly HttpClient _httpClient;

        public CreateNotificationModel(IHttpClientFactory clientFactory, IHttpContextAccessor httpContextAccessor)
        {
            _clientFactory = clientFactory;
            _httpContextAccessor = httpContextAccessor;
            _httpClient = _clientFactory.CreateClient();
        }

        [BindProperty]
        public string Messagesent { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            string userEmail = _httpContextAccessor.HttpContext.Session.GetString("UserEmail");
            var getUserIdResponse = await _httpClient.GetAsync($"https://localhost:44382/User/getUserId?email={userEmail}");

            if (getUserIdResponse.IsSuccessStatusCode)
            {
                var getUserIdResult = await getUserIdResponse.Content.ReadFromJsonAsync<UserDetailsResponse>();
                var userId = getUserIdResult.UserId;

                var notification = new Notification
                {
                    UserId = userId,
                    Message = Messagesent,
                    Date = DateTime.UtcNow
                };

                var jsonOptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                };

                var jsonContent = new StringContent(JsonSerializer.Serialize(notification, jsonOptions), Encoding.UTF8, "application/json");

                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await _httpClient.PostAsync("https://localhost:44382/User/notifications", jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToPage("Index");
                }
                else
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    ModelState.AddModelError(string.Empty, $"Failed to create a new notification: {errorMessage}");
                    return Page();
                }
            }
            else
            {
                // Handle error
                ModelState.AddModelError(string.Empty, "Failed to get user ID.");
                return Page();
            }
        }

    }
}
