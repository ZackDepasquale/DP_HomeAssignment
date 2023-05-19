using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly HttpClient _httpClient;
        public List<Notification> Notifications { get; set; }
        public string UserEmail { get; set; }
        public string UserId { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task OnGetAsync()
        {
            UserEmail = HttpContext.Session.GetString("UserEmail");

            if (!string.IsNullOrEmpty(UserEmail))
            {
                var getUserIdResponse = await _httpClient.GetAsync($"https://localhost:44382/User/getUserId?email={UserEmail}");

                if (getUserIdResponse.IsSuccessStatusCode)
                {
                    var getUserIdResult = await getUserIdResponse.Content.ReadFromJsonAsync<UserDetailsResponse>();
                    UserId = getUserIdResult.UserId;

                    var getNotificationsResponse = await _httpClient.GetAsync($"https://localhost:44382/User/notifications?userId={UserId}");
                    if (getNotificationsResponse.IsSuccessStatusCode)
                    {
                        Notifications = await getNotificationsResponse.Content.ReadFromJsonAsync<List<Notification>>();
                    }
                    else
                    {
                        // Handle error
                    }
                }
                else
                {
                    // Handle error
                }
            }
        }
    }
}