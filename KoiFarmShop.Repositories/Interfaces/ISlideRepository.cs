using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Repositories.Interfaces
{
    public interface ISlideRepository
    {
        Task<List<TbSlide>> GetSlidesAsync();
        Task<int> AddSlideAsync(TbSlide slide);
        Task<int> RemoveSlideAsync(int slideId);
        Task<bool> DeleteSlideAsync(int slideId);
        Task<int> UpdateSlideAsync(TbSlide slide);
    }
}