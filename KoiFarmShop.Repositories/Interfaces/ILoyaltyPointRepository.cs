using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Repositories.Interfaces
{
    public interface ILoyaltyPointRepository
    {
        Task<List<TbLoyaltyPoint>> GetLoyaltyPointsAsync();
        Task<int> AddLoyaltyPointAsync(TbLoyaltyPoint loyaltyPoint);
        Task<int> RemoveLoyaltyPointAsync(int loyaltyPointId);
        Task<bool> DeleteLoyaltyPointAsync(int loyaltyPointId);
        Task<int> UpdateLoyaltyPointAsync(TbLoyaltyPoint loyaltyPoint);
    }
}