using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;
using KoiFarmShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarmShop.Services.Services
{
	public class PromotionService : IPromotionService
	{
		private readonly IPromotionRepository _promotionRepository;

		public PromotionService(IPromotionRepository promotionRepository)
		{
			_promotionRepository = promotionRepository;
		}

		public async Task<bool> AddPromotionAsync(Promotion promotion)
		{
			return await _promotionRepository.AddPromotionAsync(promotion);
		}

		public async Task<bool> DeletePromotionByIdAsync(int promotionId)
		{
			return await _promotionRepository.DeletePromotionByIdAsync(promotionId);
		}

		public async Task<List<Promotion>> GetAllPromotionsAsync()
		{
			return await _promotionRepository.GetAllPromotionsAsync();
		}

		public async Task<Promotion> GetPromotionByIdAsync(int promotionId)
		{
			return await _promotionRepository.GetPromotionByIdAsync(promotionId);
		}

		public async Task<Promotion> GetPromotionByProductIdAsync(int productId)
		{
			return await _promotionRepository.GetPromotionByProductIdAsync(productId);
		}

		public async Task<bool> UpdatePromotionAsync(Promotion promotion)
		{
			return await _promotionRepository.UpdatePromotionAsync(promotion);
		}

		public async Task<bool> RemovePromotionAsync(Promotion promotion)
		{
			return await _promotionRepository.RemovePromotionAsync(promotion);
		}

		public async Task<List<Promotion>> GetActivePromotionsAsync()
		{
			var allPromotions = await _promotionRepository.GetAllPromotionsAsync();
			var activePromotions = allPromotions
				.Where(p => p.StartDate <= DateTime.Now && p.EndDate >= DateTime.Now)
				.ToList();

			return activePromotions;
		}
	}
}