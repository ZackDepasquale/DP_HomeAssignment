using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WebApplication.Models;

namespace WebApplication.Pages
{
    public class ShippingsModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public ShippingsModel(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public List<Shipping> ShippingList { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var getShippingResponse = await _httpClient.GetAsync("https://localhost:44330/Shipping");
            if (getShippingResponse.IsSuccessStatusCode)
            {
                ShippingList = await getShippingResponse.Content.ReadFromJsonAsync<List<Shipping>>();
            }
            else
            {
                ShippingList = new List<Shipping>();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostUpdateStatusAsync(string orderId)
        {
            var getDocumentIdUrl = $"https://localhost:44330/Shipping/GetDocId/{orderId}";
            var getDocumentIdResponse = await _httpClient.GetAsync(getDocumentIdUrl);
            if (getDocumentIdResponse.IsSuccessStatusCode)
            {
                var documentId = await getDocumentIdResponse.Content.ReadAsStringAsync();

                var updateStatusUrl = $"https://localhost:44330/Shipping/UpdateStatus";
                var updateStatusRequest = new UpdateStatusRequest
                {
                    OrderId = documentId
                };

                var content = new StringContent(JsonConvert.SerializeObject(updateStatusRequest), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(updateStatusUrl, content);
                if (response.IsSuccessStatusCode)
                {
                    // Update the shipping status successfully
                    return RedirectToPage();
                }
            } 

            // Failed to update the shipping status
            return BadRequest("Failed to update the shipping status.");
        }



        public class UpdateStatusRequest
        {
            public string OrderId { get; set; }
            public string ShippingStatus { get; set; }
        }
    }
}
