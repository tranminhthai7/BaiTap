using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiFarmShop.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoiFarmShop.Pages.Account
{
	public class IndexModel : PageModel
	{
		private readonly KoiFarmShop2024DbContext _context;

		public IndexModel(KoiFarmShop2024DbContext context)
		{
			_context = context;
		}

		public List<User> Users { get; set; }

		[BindProperty]
		public User CurrentUser { get; set; }

		public string ActionType { get; set; }

		// Phương thức GET để lấy danh sách người dùng
		public void OnGet(int? id)
		{
			if (id.HasValue)
			{
				// Nếu có id, lấy thông tin người dùng từ cơ sở dữ liệu
				CurrentUser = _context.Users.FirstOrDefault(u => u.Id == id.Value);
				if (CurrentUser != null)
				{
					ActionType = "Edit";  // Nếu đang chỉnh sửa
				}
				else
				{
					TempData["ErrorMessage"] = "Không tìm thấy người dùng.";
					RedirectToPage();
				}
			}
			else
			{
				ActionType = "Add";  // Nếu không có id
				CurrentUser = new User();  // Khởi tạo một đối tượng User mới
			}

			Users = _context.Users.ToList();  // Lấy danh sách người dùng
		}

		// Phương thức POST để thêm hoặc sửa tài khoản
		public async Task<IActionResult> OnPostSaveAsync()
		{
			if (!ModelState.IsValid)
			{
				Users = _context.Users.ToList();
				return Page();
			}

			if (CurrentUser.Id == 0)
			{
				CurrentUser.CreateDate = DateTime.Now;
				_context.Users.Add(CurrentUser);
				TempData["SuccessMessage"] = "Thêm người dùng thành công.";
			}
			else
			{
				var userToUpdate = _context.Users.FirstOrDefault(u => u.Id == CurrentUser.Id);
				if (userToUpdate != null)
				{
					userToUpdate.UserName = CurrentUser.UserName;
					userToUpdate.Email = CurrentUser.Email;
					userToUpdate.Password = CurrentUser.Password;
					userToUpdate.FullName = CurrentUser.FullName;
					userToUpdate.Phone = CurrentUser.Phone;
					userToUpdate.Address = CurrentUser.Address;
					userToUpdate.Role = CurrentUser.Role;
					userToUpdate.UpdateDate = DateTime.Now;

					_context.Users.Update(userToUpdate);
					TempData["SuccessMessage"] = "Cập nhật người dùng thành công.";
				}
				else
				{
					TempData["ErrorMessage"] = "Không tìm thấy người dùng.";
				}
			}

			await _context.SaveChangesAsync();
			return RedirectToPage();
		}

		// Phương thức POST để xóa người dùng
		public async Task<IActionResult> OnPostDeleteAsync(int id)
		{
			var user = await _context.Users.FindAsync(id);
			if (user != null)
			{
				_context.Users.Remove(user);
				await _context.SaveChangesAsync();
				TempData["SuccessMessage"] = "Xóa người dùng thành công.";
			}
			else
			{
				TempData["ErrorMessage"] = "Không tìm thấy người dùng.";
			}

			return RedirectToPage();
		}
	}
}
