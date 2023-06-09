using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebApplication.Pages
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        public IActionResult OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToPage("/Welcome", new { email = User.Identity.Name });
            }

            return Page();
        }

        private readonly IHttpClientFactory _clientFactory;

        public LoginModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [BindProperty]
        public LoginInputModel Input { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var client = _clientFactory.CreateClient();

            var jsonContent = new StringContent(JsonSerializer.Serialize(Input), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://customersmicroservice-mvug6bkbra-uc.a.run.app/User/login", jsonContent);

            if (response.IsSuccessStatusCode)
            {
                // Set the IsAdmin session value here based on the user's role
                var userRoleResponse = await client.GetAsync($"https://customersmicroservice-mvug6bkbra-uc.a.run.app/User/getUserRole?email={Input.Email}");
                if (userRoleResponse.IsSuccessStatusCode)
                {
                    var userRole = await userRoleResponse.Content.ReadAsStringAsync();
                    HttpContext.Session.SetString("IsAdmin", userRole);
                }
                
                HttpContext.Session.SetString("UserEmail", Input.Email);

                return RedirectToPage("Welcome", new { email = Input.Email });
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return Page();
            }
        }
    }

    public class LoginInputModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
