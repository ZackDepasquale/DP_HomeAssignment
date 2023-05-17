using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication.Pages
{
    public class WelcomeModel : PageModel
    {
        public string Email { get; set; }

        public void OnGet(string email)
        {
            Email = email;
        }
    }
}
