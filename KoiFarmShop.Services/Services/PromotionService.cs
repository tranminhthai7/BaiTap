using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public Task<bool> AddPromotion(Promotion promotion)
        {
            return _promotionRepository.AddPromotion(promotion);
        }

        public Task<bool> DeletePromotionAsync(int promotionId)
        {
            return _promotionRepository.DeletePromotionAsync(promotionId);
        }

        public async Task<List<Promotion>> GetPromotionsAsync()
        {
            return await _promotionRepository.GetPromotions();
        }

        public Task<bool> RemovePromotionAsync(Promotion promotion)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatePromotion(Promotion promotion)
        {
            return _promotionRepository.UpdatePromotion(promotion);
        }
    }
}
