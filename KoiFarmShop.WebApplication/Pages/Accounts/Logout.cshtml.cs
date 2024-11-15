using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace KoiFarmShop.WebApplication.Pages.Accounts
{
    public class LogoutModel : PageModel
    {
        public async Task<IActionResult> OnGetAsync()
        {
            // Clear the authentication cookies to log the user out
            Response.Cookies.Delete("UserEmail");
            Response.Cookies.Delete("UserName");
            Response.Cookies.Delete("UserFullName");

            // Optionally, you could add more logic here, like logging or audit trails for the logout

            // Redirect to the Login page or another page after logout
            return RedirectToPage("/Accounts/Login");
        }
    }
}
