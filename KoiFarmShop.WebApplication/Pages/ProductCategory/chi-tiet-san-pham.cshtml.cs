using KoiFarmShop.Repositories.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace KoiFarmShop.WebApplication.Pages.ProductCategory
{
	public class chi_tiet_san_phamModel : PageModel
	{
		private readonly KoiFarmShop2024DbContext _dbContext;

		public chi_tiet_san_phamModel(KoiFarmShop2024DbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public Product Product { get; set; }

		public async Task<IActionResult> OnGetAsync(int id)
		{
			Product = await _dbContext.Products.FirstOrDefaultAsync(p => p.ProductId == id);

			if (Product == null)
			{
				return NotFound();
			}

			return Page();
		}

		public async Task<IActionResult> OnPostToggleFavoriteAsync(int id)
		{
			var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.ProductId == id);

			if (product == null)
			{
				return new JsonResult(new { success = false, message = "Sản phẩm không tồn tại" });
			}

			product.YeuThich = !product.YeuThich;

			await _dbContext.SaveChangesAsync();

			return new JsonResult(new { success = true, isFavorited = product.YeuThich });
		}
	}
}
