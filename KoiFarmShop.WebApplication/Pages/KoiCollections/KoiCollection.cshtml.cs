using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;
using KoiFarmShop.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace KoiFarmShop.WebApplication.Pages.KoiCollections
{
	public class KoiCollectionModel : PageModel
	{
		private readonly IProductService _productService;
		private readonly IPromotionService _promotionService;
		private readonly IProductRepository _productRepository;

		// Constructor duy nhất nhận DI
		public KoiCollectionModel(IProductService productService, IPromotionService promotionService, IProductRepository productRepository)
		{
			_productService = productService ?? throw new ArgumentNullException(nameof(productService));
			_promotionService = promotionService ?? throw new ArgumentNullException(nameof(promotionService));
			_productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
		}

		public IEnumerable<Product> Products { get; private set; }
		public IEnumerable<KoiFarmShop.Repositories.Entities.Promotion> Promotions { get; private set; }

		// Phương thức GET để lấy dữ liệu sản phẩm và khuyến mãi
		public async Task OnGetAsync()
		{
			Products = await _productService.GetAllProductsAsync();
			Promotions = await _promotionService.GetAllPromotionsAsync();
		}

		}
	}
