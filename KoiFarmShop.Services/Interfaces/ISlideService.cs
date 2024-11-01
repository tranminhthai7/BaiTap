using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Services.Interfaces
{
    public interface ISlidesService
    {
        Task<List<Slide>> GetSlides();
        Task<bool> AddSlide(Slide slide);
        Task<bool> RemoveSlideAsync(Slide slide);
        Task<bool> DeleteSlideAsync(int slideId);
        Task<bool> UpdateSlide(Slide slide);
    }
}