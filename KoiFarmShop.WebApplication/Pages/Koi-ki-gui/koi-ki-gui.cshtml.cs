using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.WebApplication.Pages.Consignment
{
	public class koi_ki_guiModel : PageModel
	{
		private readonly KoiFarmShop2024DbContext _dbContext;

		public koi_ki_guiModel(KoiFarmShop2024DbContext dbContext)
		{
			_dbContext = dbContext;
		}

		// Danh sách koi ký gửi
		public List<Consignment> Consignments { get; set; }

		// Phương thức xử lý GET
		public async Task OnGetAsync()
		{
			// Truy vấn danh sách koi ký gửi từ cơ sở dữ liệu
			Consignments = await _dbContext.Consignments.ToListAsync();
		}

		// Phương thức xử lý POST (thêm mới ký gửi)
		public async Task<IActionResult> OnPostAsync(Consignment consignment)
		{
			if (ModelState.IsValid)
			{
				// Thêm mới ký gửi vào cơ sở dữ liệu
				_dbContext.Consignments.Add(consignment);
				await _dbContext.SaveChangesAsync();  // Lưu thay đổi vào cơ sở dữ liệu

				// Thêm thông báo thành công
				ViewData["SuccessMessage"] = "Ký gửi cá Koi thành công!";

				// Điều hướng lại trang hiện tại sau khi thành công
				return RedirectToPage();  // Điều hướng lại chính trang Razor Page này
			}

			// Nếu không hợp lệ, quay lại trang hiện tại
			return Page();  // Trả về lại trang Razor Page này với thông báo lỗi nếu có
		}
	}
}
