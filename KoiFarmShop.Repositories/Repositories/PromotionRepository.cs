using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;

namespace KoiFarmShop.Repositories.Repositories
{
    public class PromotionRepository : IPromotionRepository
    {
        private readonly KoiFarmShopDbContext _dbContext;

        public PromotionRepository(KoiFarmShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TbPromotion>> GetPromotionsAsync()
        {
            try
            {
                return await _dbContext.TbPromotions.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return new List<TbPromotion>();
            }
        }

        public async Task<int> AddPromotionAsync(TbPromotion promotion)
        {
            try
            {
                await _dbContext.TbPromotions.AddAsync(promotion);
                await _dbContext.SaveChangesAsync();
                return promotion.Id; // Assuming Id is the primary key and is auto-generated
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return 0; // Return 0 to indicate failure
            }
        }

        public async Task<int> RemovePromotionAsync(int promotionId)
        {
            var promotion = await _dbContext.TbPromotions.FindAsync(promotionId);
            if (promotion == null)
            {
                return 0; // Return 0 to indicate that the record was not found
            }

            try
            {
                _dbContext.TbPromotions.Remove(promotion);
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return 0; // Return 0 to indicate failure
            }
        }

        public async Task<bool> DeletePromotionAsync(int promotionId)
        {
            var promotion = await _dbContext.TbPromotions.FindAsync(promotionId);
            if (promotion == null)
            {
                return false; // Return false to indicate that the record was not found
            }

            try
            {
                _dbContext.TbPromotions.Remove(promotion);
                await _dbContext.SaveChangesAsync();
                return true; // Return true to indicate success
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return false; // Return false to indicate failure
            }
        }

        public async Task<int> UpdatePromotionAsync(TbPromotion promotion)
        {
            try
            {
                _dbContext.TbPromotions.Update(promotion);
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return 0; // Return 0 to indicate failure
            }
        }
    }
}