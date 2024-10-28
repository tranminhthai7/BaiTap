using System;
using System.Collections.Generic;
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

        public Task<List<TbRating>> GetRatingsAsync()
        {
            return _ratingRepository.GetRatingsAsync();
        }

        public Task<int> AddRatingAsync(TbRating rating)
        {
            return _ratingRepository.AddRatingAsync(rating);
        }

        public Task<int> RemoveRatingAsync(int ratingId)
        {
            return _ratingRepository.RemoveRatingAsync(ratingId);
        }

        public Task<bool> DeleteRatingAsync(int ratingId)
        {
            return _ratingRepository.DeleteRatingAsync(ratingId);
        }

        public Task<int> UpdateRatingAsync(TbRating rating)
        {
            return _ratingRepository.UpdateRatingAsync(rating);
        }
    }
}