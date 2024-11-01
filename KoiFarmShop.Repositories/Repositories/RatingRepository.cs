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
    public class RatingRepository : IRatingRepository
    {
        private readonly KoiFarmShop2024DbContext _dbContext;

        public RatingRepository(KoiFarmShop2024DbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public Task<bool> AddRating(Rating rating)
        {
            try
            {
                _dbContext.Ratings.AddAsync(rating);
                _dbContext.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex) 
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<bool> DeleteRatingAsync(int ratingId)
        {
            var objDel = await _dbContext.Ratings.Where(p => p.RatingId.Equals(ratingId)).FirstOrDefaultAsync();
            try
            {
                if (objDel != null)
                {
                    _dbContext.Ratings.Remove(objDel);
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

        public async Task<List<Rating>> GetRatings()
        {
            List<Rating> ratings = null;
            try
            {
                ratings = await _dbContext.Ratings.ToListAsync();
            }
            catch (Exception ex) 
            {
                ratings?.Add(new Rating());
            }
            return ratings;
        }

        public Task<bool> RemoveRatingAsync(Rating rating)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateRating(Rating rating)
        {
            try
            {
                _dbContext.Ratings.Update(rating);
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
