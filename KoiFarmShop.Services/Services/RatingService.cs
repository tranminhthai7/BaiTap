using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;
using KoiFarmShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarmShop.Services.Services
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository _ratingRepository;

        public RatingService(IRatingRepository ratingRepository) {
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

        public async Task<List<Rating>> GetRatings()
        {
            return await _ratingRepository.GetRatings();
        }

        public Task<bool> UpdateRating(Rating rating)
        {
            return _ratingRepository.UpdateRating(rating);
        }

        public Task<bool> RemoveRatingAsync(Rating rating)
        {
            throw new NotImplementedException();
        }
    }
}
