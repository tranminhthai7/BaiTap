//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using KoiFarmShop.Repositories.Entities;
//using KoiFarmShop.Services.Interfaces;
//using System.Threading.Tasks;

//namespace KoiFarmShop.WebApplication.Pages.Accounts
//{
//    public class RegisterModel : PageModel
//    {
//        private readonly IUserService _userService;

//        public RegisterModel(IUserService userService)
//        {
//            _userService = userService;
//        }

//        [BindProperty]
//        public RegisterViewModel RegisterInfo { get; set; }

//        public string SuccessMessage { get; set; }

//        public void OnGet()
//        {
//            RegisterInfo = new RegisterViewModel();
//        }

//        public async Task<IActionResult> OnPostAsync()
//        {
//            if (!ModelState.IsValid)
//            {
//                return Page();
//            }
//            var user = new User
//            {
//                Email = RegisterInfo.Email,
//                Password = RegisterInfo.Password
//                // Thêm các thuộc tính khác nếu cần
//            };
//            // Gọi dịch vụ để thêm người dùng mới
//            var result = await _userService.RegisterUserAsync(user);
//            if (result)
//            {
//                SuccessMessage = "Đăng ký thành công!";
//                return RedirectToPage("/Account/Login"); // Chuyển hướng đến trang đăng nhập
//            }
//            else
//            {
//                ModelState.AddModelError(string.Empty, "Đăng ký thất bại. Vui lòng thử lại.");
//                return Page();
//            }
//        }
//    }

//    public class RegisterViewModel
//    {
//        public string FirstName { get; set; }
//        public string LastName { get; set; }
//        public string Email { get; set; }
//        public string PhoneNumber { get; set; }
//        public string Password { get; set; }
//    }
//}
