using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Repositories.Interfaces
{
    public interface IPromotionRepository
    {
        Task<List<Promotion>> GetPromotions();
        Task<bool> AddPromotion(Promotion promotion);
        Task<bool> RemovePromotionAsync(Promotion promotion);
        Task<bool> DeletePromotionAsync(int promotionId);
        Task<bool> UpdatePromotion(Promotion promotion);
    }
}