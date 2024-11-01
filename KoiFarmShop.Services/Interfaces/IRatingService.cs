using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Services.Interfaces
{
    public interface IRatingService
    {
        Task<List<Rating>> GetRatings();
        Task<bool> AddRating(Rating rating);
        Task<bool> RemoveRatingAsync(Rating rating);
        Task<bool> DeleteRatingAsync(int ratingId);
        Task<bool> UpdateRating(Rating rating);
    }
}