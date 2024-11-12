using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace KoiFarmShop.WebApplication.Pages.Accounts
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnPost()
        {
            // Xóa tất cả cookies liên quan đến người dùng
            Response.Cookies.Delete("UserEmail");
            Response.Cookies.Delete("UserName");
            Response.Cookies.Delete("UserFullName");

            // Sau khi logout, chuyển hướng người dùng về trang đăng nhập
            return RedirectToPage("/Index");
        }
    }
}
