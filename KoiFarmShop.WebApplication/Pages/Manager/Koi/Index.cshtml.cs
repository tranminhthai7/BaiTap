using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.WebApplication.Pages.Manager.Koi
{
    public class KoiIndexModel : PageModel
    {
        private readonly KoiFarmShop2024DbContext _context;

        public KoiIndexModel(KoiFarmShop2024DbContext context)
        {
            _context = context;
        }

        public List<KoiFarmShop.Repositories.Entities.Koi> KoiCollection { get; set; }

        [BindProperty]
        public KoiFarmShop.Repositories.Entities.Koi CurrentKoi { get; set; }

        public string ActionType { get; set; }

        public async Task OnGetAsync()
        {
            // Lấy danh sách cá Koi
            KoiCollection = await _context.Kois.ToListAsync();
            ActionType = "Add";
        }

        public async Task<IActionResult> OnPostSaveAsync()
        {
            if (!ModelState.IsValid)
            {
                KoiCollection = await _context.Kois.ToListAsync();
                TempData["ErrorMessage"] = "Vui lòng kiểm tra lại thông tin!";
                return Page();
            }

            if (CurrentKoi.KoiId == 0) // Thêm cá Koi mới
            {
                _context.Kois.Add(CurrentKoi);
                TempData["SuccessMessage"] = "Thêm cá Koi thành công!";
            }
            else // Sửa thông tin cá Koi
            {
                _context.Attach(CurrentKoi).State = EntityState.Modified;
                TempData["SuccessMessage"] = "Cập nhật thông tin cá Koi thành công!";
            }

            await _context.SaveChangesAsync();
            return RedirectToPage();
        }

        public async Task<IActionResult> OnGetEditAsync(int id)
        {
            CurrentKoi = await _context.Kois.FindAsync(id);
            if (CurrentKoi == null)
            {
                TempData["ErrorMessage"] = "Không tìm thấy cá Koi!";
                return RedirectToPage();
            }

            KoiCollection = await _context.Kois.ToListAsync();
            ActionType = "Edit";
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var koi = await _context.Kois.FindAsync(id);
            if (koi != null)
            {
                _context.Kois.Remove(koi);
                TempData["SuccessMessage"] = "Xóa cá Koi thành công!";
                await _context.SaveChangesAsync();
            }
            else
            {
                TempData["ErrorMessage"] = "Không tìm thấy cá Koi để xóa!";
            }

            return RedirectToPage();
        }

        public IActionResult OnPostComplete()
        {
            TempData["SuccessMessage"] = "Hoàn thành tất cả các thao tác!";
            return RedirectToPage();
        }
    }
}
