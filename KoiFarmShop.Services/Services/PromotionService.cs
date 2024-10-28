using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;
using KoiFarmShop.Services.Interfaces;

namespace KoiFarmShop.Services.Services
{
    public class PromotionService : IPromotionService
    {
        private readonly IPromotionRepository _promotionRepository;

        public PromotionService(IPromotionRepository promotionRepository)
        {
            _promotionRepository = promotionRepository;
        }

        public Task<List<TbPromotion>> GetPromotionsAsync()
        {
            return _promotionRepository.GetPromotionsAsync();
        }

        public Task<int> AddPromotionAsync(TbPromotion promotion)
        {
            return _promotionRepository.AddPromotionAsync(promotion);
        }

        public Task<int> RemovePromotionAsync(int promotionId)
        {
            return _promotionRepository.RemovePromotionAsync(promotionId);
        }

        public Task<bool> DeletePromotionAsync(int promotionId)
        {
            return _promotionRepository.DeletePromotionAsync(promotionId);
        }

        public Task<int> UpdatePromotionAsync(TbPromotion promotion)
        {
            return _promotionRepository.UpdatePromotionAsync(promotion);
        }
    }
}