using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Repositories.Interfaces
{
    public interface ILoyaltyPointRepository
    {
        Task<List<TbLoyaltyPoint>> GetLoyaltyPoints();
        Task<bool> AddLoyaltyPoint(LoyaltyPoint loyaltyPoint);
        Task<bool> RemoveLoyaltyPointAsync(LoyaltyPoint loyaltyPoint);
        Task<bool> DeleteLoyaltyPointAsync(int loyaltyPointId);
        Task<bool> UpdateLoyaltyPoint(LoyaltyPoint loyaltyPoint);
    }
}
