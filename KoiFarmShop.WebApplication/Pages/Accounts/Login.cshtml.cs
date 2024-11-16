using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using KoiFarmShop.Services.Interfaces;
using KoiFarmShop.Repositories.Entities;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Primitives;

namespace KoiFarmShop.WebApplication.Pages.Accounts
{
    public class LoginModel : PageModel
    {
        private readonly IUserService _context;

        public LoginModel(IUserService context)
        {
            _context = context;
        }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        // Xử lý đăng nhập khi người dùng gửi form
        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            {
                ErrorMessage = "Email hoặc mật khẩu không được để trống.";
                return Page();
            }

            var account = await _context.LoginAsync(Email, Password);

            if (account != null)
            {
                // Đăng nhập thành công, lưu thông tin người dùng vào Cookie
                var cookieOptions = new CookieOptions
                {
                    Expires = DateTime.Now.AddMinutes(30),
                    HttpOnly = true,  // Bảo vệ cookie khỏi các script của client
                    Secure = true,    // Chỉ gửi cookie qua HTTPS
                    SameSite = SameSiteMode.Strict  // Giới hạn cookie để tránh cross-site request
                };

                Response.Cookies.Append("UserEmail", account.Email, cookieOptions);
                Response.Cookies.Append("UserName", account.UserName, cookieOptions);
                Response.Cookies.Append("UserFullName", account.FullName, cookieOptions);
				Response.Cookies.Append("UserPhone", account.Phone, cookieOptions);


				// Chuyển hướng đến trang thông tin người dùng
				return RedirectToPage("/Accounts/Index");
            }
            else
            {
                // Đăng nhập thất bại, hiển thị thông báo lỗi
                ErrorMessage = "Email hoặc mật khẩu không chính xác.";
                return Page();
            }
        }
    }
}