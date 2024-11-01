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
    public class PromotionRepository : IPromotionRepository
    {
        private readonly KoiFarmShop2024DbContext _dbContext;

        public PromotionRepository(KoiFarmShop2024DbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public Task<bool> AddPromotion(Promotion promotion)
        {
            try
            {
                _dbContext.Promotions.AddAsync(promotion);
                _dbContext.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex) 
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<bool> DeletePromotionAsync(int promotionId)
        {
            var objDel = await _dbContext.Promotions.Where(p => p.PromotionId.Equals(promotionId)).FirstOrDefaultAsync();
            try
            {
                if (objDel != null)
                {
                    _dbContext.Promotions.Remove(objDel);
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

        public async Task<List<Promotion>> GetPromotions()
        {
            List<Promotion> promotions = null;
            try
            {
                promotions = await _dbContext.Promotions.ToListAsync();
            }
            catch (Exception ex) 
            {
                promotions?.Add(new Promotion());
            }
            return promotions;
        }

        public Task<bool> RemovePromotionAsync(Promotion promotion)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatePromotion(Promotion promotion)
        {
            try
            {
                _dbContext.Promotions.Update(promotion);
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
