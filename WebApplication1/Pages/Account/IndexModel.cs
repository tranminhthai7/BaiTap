using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiFarmShop.Repositories.Entities;
namespace WebApplication1.Pages.Account
{
    public class IndexModel : PageModel
    {
        // Danh sách tài khoản
        public List<User> Users { get; set; } = new List<User>();

        // Tài khoản hiện tại (thêm/sửa)
        [BindProperty]
        public User CurrentUser { get; set; } = new User();

        // Loại thao tác (Add/Edit)
        public string ActionType { get; set; } = "Add";

        public void OnGet()
        {
            // Tải danh sách tài khoản (giả lập)
            Users = GetMockUsers();
        }

        public IActionResult OnGetEdit(int id)
        {
            // Tìm tài khoản theo ID
            CurrentUser = Users.FirstOrDefault(u => u.Id == id);
            if (CurrentUser == null)
            {
                TempData["ErrorMessage"] = "Không tìm thấy tài khoản!";
                return RedirectToPage();
            }

            // Đặt ActionType là "Edit"
            ActionType = "Edit";
            return Page();
        }

        public IActionResult OnPostSave()
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Vui lòng kiểm tra lại thông tin!";
                return Page();
            }

            if (CurrentUser.Id == 0)
            {
                // Thêm tài khoản mới
                CurrentUser.Id = new Random().Next(100, 999); // Giả lập ID
                Users.Add(CurrentUser);
                TempData["SuccessMessage"] = "Thêm tài khoản thành công!";
            }
            else
            {
                // Sửa tài khoản
                var existingUser = Users.FirstOrDefault(u => u.Id == CurrentUser.Id);
                if (existingUser != null)
                {
                    existingUser.UserName = CurrentUser.UserName;
                    existingUser.Email = CurrentUser.Email;
                    existingUser.Role = CurrentUser.Role;
                    TempData["SuccessMessage"] = "Cập nhật tài khoản thành công!";
                }
                else
                {
                    TempData["ErrorMessage"] = "Không tìm thấy tài khoản để sửa!";
                }
            }

            return RedirectToPage();
        }

        public IActionResult OnPostDelete(int id)
        {
            var user = Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                Users.Remove(user);
                TempData["SuccessMessage"] = "Xóa tài khoản thành công!";
            }
            else
            {
                TempData["ErrorMessage"] = "Không tìm thấy tài khoản để xóa!";
            }

            return RedirectToPage();
        }

        private List<User> GetMockUsers()
        {
            // Giả lập danh sách tài khoản
            return new List<User>
            {
                new User { Id = 1, UserName = "admin", Email = "admin@example.com", Role = "Admin" },
                new User { Id = 2, UserName = "employee", Email = "employee@example.com", Role = "Employee" },
                new User { Id = 3, UserName = "user", Email = "user@example.com", Role = "User" }
            };
        }
    }

    // Lớp mô phỏng thông tin tài khoản
    public class User
    {
        internal object Role;

        public int Id { get; set; }

        public string? UserName { get; set; }

        public string? Password { get; set; }

        public string? FullName { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

        public string? Image { get; set; }

        public bool? Status { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? UpdateBy { get; set; }

        public DateTime? UpdateDate { get; set; }
    }
}
