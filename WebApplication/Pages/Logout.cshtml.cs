using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication.Pages
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnPostSignOut(bool clearUserEmail)
        {
            // Perform sign out logic if needed

            if (clearUserEmail)
            {
                HttpContext.Session.SetString("UserEmail", "");
            }

            // Redirect to the Login page
            return RedirectToPage("/Login");
        }
    }
}
