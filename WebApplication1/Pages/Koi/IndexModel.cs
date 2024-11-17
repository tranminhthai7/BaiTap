using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Pages.Koi
{
    public class KoiIndexModel : PageModel
    {
        private readonly KoiFarmShop2024DbContext _context;

        public KoiIndexModel(KoiFarmShop2024DbContext context)
        {
            _context = context;
        }

        // Danh sách cá Koi
        public List<Koi> KoiCollection { get; set; }

        // Cá Koi hiện tại (Thêm/Sửa)
        [BindProperty]
        public Koi CurrentKoi { get; set; }

        // Loại thao tác (Thêm/Sửa)
        public string ActionType { get; set; } = "Add";

        // GET: Hiển thị danh sách cá Koi
        public async Task OnGetAsync()
        {
            KoiCollection = await _context.Kois.ToListAsync();
        }

        // GET: Sửa thông tin cá Koi
        public async Task<IActionResult> OnGetEditAsync(int id)
        {
            CurrentKoi = await _context.Kois.FindAsync(id);

            if (CurrentKoi == null)
            {
                TempData["ErrorMessage"] = "Không tìm thấy cá Koi!";
                return RedirectToPage();
            }

            ActionType = "Edit";
            return Page();
        }

        // POST: Thêm hoặc Sửa cá Koi
        public async Task<IActionResult> OnPostSaveAsync()
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Vui lòng kiểm tra lại thông tin!";
                KoiCollection = await _context.Kois.ToListAsync();
                return Page();
            }

            if (CurrentKoi.Id == 0)
            {
                // Thêm cá Koi mới
                _context.Kois.Add(CurrentKoi);
                TempData["SuccessMessage"] = "Thêm cá Koi thành công!";
            }
            else
            {
                // Sửa thông tin cá Koi
                var existingKoi = await _context.Kois.FindAsync(CurrentKoi.Id);

                if (existingKoi == null)
                {
                    TempData["ErrorMessage"] = "Không tìm thấy cá Koi để cập nhật!";
                    return RedirectToPage();
                }

                existingKoi.Name = CurrentKoi.Name;
                existingKoi.Breed = CurrentKoi.Breed;
                existingKoi.Gender = CurrentKoi.Gender;
                existingKoi.Size = CurrentKoi.Size;
                existingKoi.HealthStatus = CurrentKoi.HealthStatus;

                TempData["SuccessMessage"] = "Cập nhật cá Koi thành công!";
            }

            await _context.SaveChangesAsync();
            return RedirectToPage();
        }

        // POST: Xóa cá Koi
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var koi = await _context.Kois.FindAsync(id);

            if (koi == null)
            {
                TempData["ErrorMessage"] = "Không tìm thấy cá Koi để xóa!";
                return RedirectToPage();
            }

            _context.Kois.Remove(koi);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Xóa cá Koi thành công!";
            return RedirectToPage();
        }

        // POST: Xác nhận hoàn thành
        public IActionResult OnPostComplete()
        {
            TempData["SuccessMessage"] = "Hoàn thành tất cả các thao tác!";
            return RedirectToPage();
        }
    }
}
