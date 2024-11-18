using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFarmShop.Services.Services;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Services.Interfaces;

namespace KoiFarmShop.WebApplication.Pages.ProductCategory
{
	public class chi_tiet_san_phamModel : PageModel
	{

		private readonly IProductService _productService;
		private readonly IPromotionService _promotionService;

		public chi_tiet_san_phamModel(IProductService productService, IPromotionService promotionService)
		{
			_productService = productService ?? throw new ArgumentNullException(nameof(productService));
			_promotionService = promotionService ?? throw new ArgumentNullException(nameof(promotionService));
		}

		public IEnumerable<Product> Products { get; private set; }
		public IEnumerable<KoiFarmShop.Repositories.Entities.Promotion> Promotions { get; private set; }

		public async Task OnGetAsync()
		{
			Products = await _productService.GetAllProductsAsync();
			Promotions = await _promotionService.GetAllPromotionsAsync();
		}

	}
}