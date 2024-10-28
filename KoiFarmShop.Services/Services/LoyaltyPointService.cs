using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;
using KoiFarmShop.Services.Interfaces;

namespace KoiFarmShop.Services.Services
{
    public class LoyaltyPointService : ILoyaltyPointService
    {
        private readonly ILoyaltyPointRepository _loyaltyPointRepository;

        public LoyaltyPointService(ILoyaltyPointRepository loyaltyPointRepository)
        {
            _loyaltyPointRepository = loyaltyPointRepository;
        }

        public Task<List<TbLoyaltyPoint>> GetLoyaltyPointsAsync()
        {
            return _loyaltyPointRepository.GetLoyaltyPointsAsync();
        }

        public Task<int> AddLoyaltyPointAsync(TbLoyaltyPoint loyaltyPoint)
        {
            return _loyaltyPointRepository.AddLoyaltyPointAsync(loyaltyPoint);
        }

        public Task<int> RemoveLoyaltyPointAsync(int loyaltyPointId)
        {
            return _loyaltyPointRepository.RemoveLoyaltyPointAsync(loyaltyPointId);
        }

        public Task<bool> DeleteLoyaltyPointAsync(int loyaltyPointId)
        {
            return _loyaltyPointRepository.DeleteLoyaltyPointAsync(loyaltyPointId);
        }

        public Task<int> UpdateLoyaltyPointAsync(TbLoyaltyPoint loyaltyPoint)
        {
            return _loyaltyPointRepository.UpdateLoyaltyPointAsync(loyaltyPoint);
        }
    }
}