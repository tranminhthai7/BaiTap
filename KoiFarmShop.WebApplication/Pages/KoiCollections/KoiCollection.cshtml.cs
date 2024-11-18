using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;
using KoiFarmShop.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace KoiFarmShop.WebApplication.Pages.KoiCollections
{
	public class KoiCollectionModel : PageModel
	{
		private readonly IProductService _productService;
		private readonly IPromotionService _promotionService;
		private readonly IProductRepository _productRepository;
		private readonly IConsignmentService _consignmentService;
		private readonly ILogger<KoiCollectionModel> _logger;

		// Constructor duy nhất nhận DI
		public KoiCollectionModel(IProductService productService, IPromotionService promotionService, IProductRepository productRepository, IConsignmentService consignmentService, ILogger<KoiCollectionModel> logger)
		{
			_productService = productService ?? throw new ArgumentNullException(nameof(productService));
			_promotionService = promotionService ?? throw new ArgumentNullException(nameof(promotionService));
			_productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
			_consignmentService = consignmentService;
			_logger = logger;
		}

		public IEnumerable<Product> Products { get; private set; }
		public IEnumerable<KoiFarmShop.Repositories.Entities.Promotion> Promotions { get; private set; }
		public List<Consignment> Consignments { get; set; }

		// Phương thức GET để lấy dữ liệu sản phẩm và khuyến mãi
		public async Task OnGetAsync()
		{
			Products = await _productService.GetAllProductsAsync();
			Promotions = await _promotionService.GetAllPromotionsAsync();
			Consignments = await _consignmentService.GetConsignments();
		}

		public async Task<IActionResult> OnPostAsync([FromBody] Consignment consignment)
		{
			if (!ModelState.IsValid)
			{
				_logger.LogError("Model state is invalid.");
				return new JsonResult(new { success = false });
			}

			try
			{
				var result = await _consignmentService.AddConsignment(consignment);
				if (result)
				{
					return new JsonResult(new { success = true });
				}
				else
				{
					_logger.LogError("Failed to add consignment.");
					return new JsonResult(new { success = false });
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error adding consignment.");
				return new JsonResult(new { success = false });
			}
		}
	}
}
