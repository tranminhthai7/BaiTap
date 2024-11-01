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
    public class SlideService : ISlideService
    {
        private readonly ISlideRepository _slideRepository;

        public SlideService(ISlideRepository slideRepository) {
            _slideRepository = slideRepository;
        }

        public Task<bool> AddSlide(Slide slide)
        {
            return _slideRepository.AddSlide(slide);
        }

        public Task<bool> DeleteSlideAsync(int slideId)
        {
            return _slideRepository.DeleteSlideAsync(slideId);
        }

        public async Task<List<Slide>> GetSlides()
        {
            return await _slideRepository.GetSlides();
        }

        public Task<bool> UpdateSlide(Slide slide)
        {
            return _slideRepository.UpdateSlide(slide);
        }

        public Task<bool> RemoveSlideAsync(Slide slide)
        {
            throw new NotImplementedException();
        }
    }
}
