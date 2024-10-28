using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;

namespace KoiFarmShop.Repositories.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private readonly KoiFarmShopDbContext _dbContext;

        public RatingRepository(KoiFarmShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TbRating>> GetRatingsAsync()
        {
            try
            {
                return await _dbContext.TbRatings.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return new List<TbRating>();
            }
        }

        public async Task<int> AddRatingAsync(TbRating rating)
        {
            try
            {
                await _dbContext.TbRatings.AddAsync(rating);
                await _dbContext.SaveChangesAsync();
                return rating.Id; // Assuming Id is the primary key and is auto-generated
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return 0; // Return 0 to indicate failure
            }
        }

        public async Task<int> RemoveRatingAsync(int ratingId)
        {
            var rating = await _dbContext.TbRatings.FindAsync(ratingId);
            if (rating == null)
            {
                return 0; // Return 0 to indicate that the record was not found
            }

            try
            {
                _dbContext.TbRatings.Remove(rating);
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return 0; // Return 0 to indicate failure
            }
        }

        public async Task<bool> DeleteRatingAsync(int ratingId)
        {
            var rating = await _dbContext.TbRatings.FindAsync(ratingId);
            if (rating == null)
            {
                return false; // Return false to indicate that the record was not found
            }

            try
            {
                _dbContext.TbRatings.Remove(rating);
                await _dbContext.SaveChangesAsync();
                return true; // Return true to indicate success
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return false; // Return false to indicate failure
            }
        }

        public async Task<int> UpdateRatingAsync(TbRating rating)
        {
            try
            {
                _dbContext.TbRatings.Update(rating);
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