using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;

namespace KoiFarmShop.Repositories.Repositories
{
    public class LoyaltyPointRepository : ILoyaltyPointRepository
    {
        private readonly KoiFarmShop2024DbContext _dbContext;

        public LoyaltyPointRepository(KoiFarmShop2024DbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public Task<bool> AddLoyaltyPoint(LoyaltyPoint loyaltyPoint)
        {
            try
            {
                _dbContext.LoyaltyPoints.AddAsync(loyaltyPoint);
                _dbContext.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex) 
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<bool> DeleteLoyaltyPointAsync(int loyaltyPointId)
        {
            var objDel = await _dbContext.LoyaltyPoints.Where(p => p.LoyaltyPointId.Equals(loyaltyPointId)).FirstOrDefaultAsync();
            try
            {
                if (objDel != null)
                {
                    _dbContext.LoyaltyPoints.Remove(objDel);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                // Log the exception
                return false;
            }
        }

        public async Task<List<LoyaltyPoint>> GetLoyaltyPoints()
        {
            List<LoyaltyPoint> loyaltyPoints = null;
            try
            {
                loyaltyPoints = await _dbContext.LoyaltyPoints.ToListAsync();
            }
            catch (Exception ex) 
            {
                loyaltyPoints?.Add(new LoyaltyPoint());
            }
            return loyaltyPoints;
        }

        public Task<bool> RemoveLoyaltyPointAsync(LoyaltyPoint loyaltyPoint)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateLoyaltyPoint(LoyaltyPoint loyaltyPoint)
        {
            try
            {
                _dbContext.LoyaltyPoints.Update(loyaltyPoint);
                _dbContext.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                return Task.FromResult(false);
            }
        }
    }
}
