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
    public class LoyaltyPointService : ILoyaltyPointService
    {
        private readonly ILoyaltyPointRepository _loyaltyPointRepository;

        public LoyaltyPointService(ILoyaltyPointRepository loyaltyPointRepository)
        {
            _loyaltyPointRepository = loyaltyPointRepository;
        }

        public Task<bool> AddLoyaltyPoint(LoyaltyPoint loyaltyPoint)
        {
            return _loyaltyPointRepository.AddLoyaltyPoint(loyaltyPoint);
        }

        public Task<bool> DeleteLoyaltyPointAsync(int loyaltyPointId)
        {
            return _loyaltyPointRepository.DeleteLoyaltyPointAsync(loyaltyPointId);
        }

        public async Task<List<LoyaltyPoint>> GetLoyaltyPointsAsync()
        {
            return await _loyaltyPointRepository.GetLoyaltyPoints();
        }

        public Task<bool> RemoveLoyaltyPointAsync(LoyaltyPoint loyaltyPoint)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateLoyaltyPoint(LoyaltyPoint loyaltyPoint)
        {
            return _loyaltyPointRepository.UpdateLoyaltyPoint(loyaltyPoint);
        }
    }
}
