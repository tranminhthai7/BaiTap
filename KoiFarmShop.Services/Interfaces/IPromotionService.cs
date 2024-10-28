using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Services.Interfaces
{
    public interface IPromotionService
    {
        Task<List<TbPromotion>> GetPromotionsAsync();
        Task<int> AddPromotionAsync(TbPromotion promotion);
        Task<int> RemovePromotionAsync(int promotionId);
        Task<bool> DeletePromotionAsync(int promotionId);
        Task<int> UpdatePromotionAsync(TbPromotion promotion);
    }
}