using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Pages
{
    public class DetailsModel : PageModel
{
    private readonly HttpClient httpClient;

    public DetailsModel(IHttpClientFactory httpClientFactory)
    {
        httpClient = httpClientFactory.CreateClient();
    }

    public UserRegistrationModel User { get; set; }

    public async Task<IActionResult> OnGetAsync(string email)
    {
        var response = await httpClient.GetAsync($"https://customersmicroservice-mvug6bkbra-uc.a.run.app/User/details?email={email}");

        if (response.IsSuccessStatusCode)
        {
            User = await response.Content.ReadFromJsonAsync<UserRegistrationModel>();
            return Page();
        }
        else
        {
            // Handle error
            return RedirectToPage("/Error");
        }
    }
}

}
