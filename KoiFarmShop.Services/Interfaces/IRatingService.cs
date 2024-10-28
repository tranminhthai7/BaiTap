using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Services.Interfaces
{
    public interface IRatingService
    {
        Task<List<TbRating>> GetRatingsAsync();
        Task<int> AddRatingAsync(TbRating rating);
        Task<int> RemoveRatingAsync(int ratingId);
        Task<bool> DeleteRatingAsync(int ratingId);
        Task<int> UpdateRatingAsync(TbRating rating);
    }
}