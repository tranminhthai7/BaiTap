using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiFarmShop.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoiFarmShop.Pages.KoiFish
{
	public class IndexModel : PageModel
	{
		private readonly KoiFarmShop2024DbContext _context;

		public IndexModel(KoiFarmShop2024DbContext context)
		{
			_context = context;
		}

		public List<Koi> Kois { get; set; }

		[BindProperty]
		public Koi CurrentKoi { get; set; }

		public string ActionType { get; set; }

		public void OnGet(int? id)
		{
			if (id.HasValue)
			{
				CurrentKoi = _context.Kois.FirstOrDefault(k => k.KoiId == id);
				ActionType = CurrentKoi != null ? "Edit" : "Add";
			}
			else
			{
				CurrentKoi = new KoiFarmShop.Repositories.Entities.Koi();
				ActionType = "Add";
			}

			Kois = _context.Kois.ToList();
		}

		public async Task<IActionResult> OnPostSaveAsync()
		{
			if (!ModelState.IsValid)
			{
				Kois = _context.Kois.ToList();  // Tải lại danh sách koi để hiển thị trên trang
				return Page();
			}

			// Kiểm tra nếu CurrentKoi có KoiId (đối tượng mới)
			if (CurrentKoi.KoiId == null || CurrentKoi.KoiId == 0)
			{
				// Thêm mới koi nếu KoiId chưa được gán (auto-increment)
				if (CurrentKoi != null)
				{
					_context.Kois.Add(CurrentKoi);  // Thêm vào cơ sở dữ liệu
					await _context.SaveChangesAsync();  // Lưu vào cơ sở dữ liệu
					TempData["SuccessMessage"] = "Thêm koi thành công.";  // Thông báo thành công
				}
			}
			else
			{
				// Cập nhật thông tin koi đã có
				var koiToUpdate = _context.Kois.FirstOrDefault(k => k.KoiId == CurrentKoi.KoiId);
				if (koiToUpdate != null)
				{
					koiToUpdate.Name = CurrentKoi.Name;
					koiToUpdate.Breed = CurrentKoi.Breed;
					koiToUpdate.Gender = CurrentKoi.Gender;
					koiToUpdate.Age = CurrentKoi.Age;
					koiToUpdate.Size = CurrentKoi.Size;
					koiToUpdate.Origin = CurrentKoi.Origin;
					koiToUpdate.Character = CurrentKoi.Character;
					koiToUpdate.FeedlingAmount = CurrentKoi.FeedlingAmount;
					koiToUpdate.ScreenRate = CurrentKoi.ScreenRate;
					koiToUpdate.HealthStatus = CurrentKoi.HealthStatus;

					await _context.SaveChangesAsync();  // Lưu cập nhật vào cơ sở dữ liệu
					TempData["SuccessMessage"] = "Cập nhật koi thành công.";  // Thông báo cập nhật thành công
				}
				else
				{
					TempData["ErrorMessage"] = "Không tìm thấy koi.";  // Thông báo lỗi nếu không tìm thấy đối tượng để cập nhật
				}
			}

			return RedirectToPage();  // Điều hướng lại trang sau khi lưu hoặc cập nhật thành công
		}

	}
}
