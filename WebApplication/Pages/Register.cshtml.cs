using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Pages
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        public IActionResult OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToPage("/Welcome", new { email = User.Identity.Name });
            }

            return Page();
        }

        private readonly HttpClient httpClient;

        public RegisterModel(IHttpClientFactory httpClientFactory)
        {
            httpClient = httpClientFactory.CreateClient();
        }

        [BindProperty]
        public UserRegistrationModel UserRegistrationModel { get; set; }

        public bool RegistrationComplete { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                UserRegistrationModel.IsAdmin = HttpContext.Request.Form["isAdmin"] == "on";

                var response = await httpClient.PostAsJsonAsync("https://customersmicroservice-mvug6bkbra-uc.a.run.app/User/register", UserRegistrationModel);

                if (response.IsSuccessStatusCode)
                {
                    // Set the IsAdmin session value here
                    HttpContext.Session.SetString("IsAdmin", UserRegistrationModel.IsAdmin.ToString());

                    RegistrationComplete = true;
                }
                else
                {
                    // Handle the error response here
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    ModelState.AddModelError(string.Empty, $"Registration failed: {errorMessage}");
                }
            }
            catch (Exception ex)
            {
                // Handle the exception here
                ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
            }

            return Page();
        }
    }
}
