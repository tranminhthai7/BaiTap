using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiFarmShop.Services.Interfaces;
using KoiFarmShop.Repositories.Entities;
using System.Threading.Tasks;

namespace KoiFarmShop.WebApplication.Pages.Accounts
{
    public class RegisterModel : PageModel
    {
        private readonly IUserService _userService;

        public RegisterModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public User Input { get; set; }

        public void OnGet()
        {
            // Khởi tạo đối tượng người dùng rỗng
            Input = new User();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Kiểm tra dữ liệu hợp lệ
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Thêm người dùng vào hệ thống
            var registeredUser = await _userService.RegisterAsync(
                Input.UserName,
                Input.Password,
                Input.FullName,
                Input.Email,
                Input.Phone,
                Input.Address
            );

            if (registeredUser != null)
            {
                // Nếu đăng ký thành công, chuyển hướng về trang chủ
                return RedirectToPage("/Index");
            }
            else
            {
                // Nếu đăng ký thất bại, hiển thị thông báo lỗi
                ModelState.AddModelError(string.Empty, "Email đã tồn tại hoặc có lỗi khi đăng ký.");
                return Page();
            }
        }
    }
}
