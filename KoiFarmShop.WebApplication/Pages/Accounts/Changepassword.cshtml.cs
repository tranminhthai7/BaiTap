using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiFarmShop.Services.Interfaces;
using System.Threading.Tasks;

namespace KoiFarmShop.WebApplication.Pages.Accounts
{
	public class ChangePasswordModel : PageModel
	{
		private readonly IUserService _userService;

		public ChangePasswordModel(IUserService userService)
		{
			_userService = userService;
		}

		[BindProperty]
		public string CurrentPassword { get; set; }

		[BindProperty]
		public string NewPassword { get; set; }

		[BindProperty]
		public string ConfirmNewPassword { get; set; }

		public string ErrorMessage { get; set; }
		public string SuccessMessage { get; set; }

		public async Task<IActionResult> OnPostAsync()
		{
			// Kiểm tra mật khẩu mới và xác nhận mật khẩu
			if (NewPassword != ConfirmNewPassword)
			{
				ErrorMessage = "Mật khẩu mới và xác nhận mật khẩu không khớp.";
				return Page(); // Giữ nguyên trang và hiển thị lỗi
			}

			var email = Request.Cookies["UserEmail"];  // Lấy email từ cookie
			if (email == null)
			{
				ErrorMessage = "Người dùng chưa đăng nhập.";
				return RedirectToPage("/Accounts/Login"); // Chuyển hướng nếu chưa đăng nhập
			}

			// Thực hiện thay đổi mật khẩu
			var isChanged = await _userService.ChangePasswordAsync(email, CurrentPassword, NewPassword);
			if (isChanged)
			{
				SuccessMessage = "Đổi mật khẩu thành công!"; // Đặt thông báo thành công
				ModelState.Clear(); // Xóa các trường nhập để trống sau khi thành công
			}
			else
			{
				ErrorMessage = "Mật khẩu hiện tại không đúng."; // Đặt thông báo lỗi
			}
			return Page(); // Giữ nguyên trang và hiển thị thông báo
		}
	}
}
