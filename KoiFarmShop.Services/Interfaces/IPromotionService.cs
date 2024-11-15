using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Services.Interfaces
{
	public interface IPromotionService
	{
		// Lấy tất cả khuyến mãi
		Task<List<Promotion>> GetAllPromotionsAsync();

		// Lấy khuyến mãi theo ID
		Task<Promotion> GetPromotionByIdAsync(int promotionId);

		// Lấy khuyến mãi theo ProductId (nếu có khuyến mãi theo sản phẩm)
		Task<Promotion> GetPromotionByProductIdAsync(int productId);

		// Thêm khuyến mãi
		Task<bool> AddPromotionAsync(Promotion promotion);

		// Cập nhật khuyến mãi
		Task<bool> UpdatePromotionAsync(Promotion promotion);

		// Xóa khuyến mãi theo đối tượng Promotion
		Task<bool> RemovePromotionAsync(Promotion promotion);

		// Xóa khuyến mãi theo ID
		Task<bool> DeletePromotionByIdAsync(int promotionId);

		// Lấy danh sách khuyến mãi đang hoạt động
		Task<List<Promotion>> GetActivePromotionsAsync(); // New method
	}
}