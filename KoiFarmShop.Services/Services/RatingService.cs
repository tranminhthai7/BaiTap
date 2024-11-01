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
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository _ratingRepository;

        public RatingService(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        public Task<bool> AddRating(Rating rating)
        {
            return _ratingRepository.AddRating(rating);
        }

        public Task<bool> DeleteRatingAsync(int ratingId)
        {
            return _ratingRepository.DeleteRatingAsync(ratingId);
        }

        public async Task<List<Rating>> GetRatingsAsync()
        {
            return await _ratingRepository.GetRatings();
        }

        public Task<bool> RemoveRatingAsync(Rating rating)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateRating(Rating rating)
        {
            return _ratingRepository.UpdateRating(rating);
        }
    }
}
