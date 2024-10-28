using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;
using KoiFarmShop.Services.Interfaces;

namespace KoiFarmShop.Services.Services
{
    public class SlideService : ISlideService
    {
        private readonly ISlideRepository _slideRepository;

        public SlideService(ISlideRepository slideRepository)
        {
            _slideRepository = slideRepository;
        }

        public Task<List<TbSlide>> GetSlidesAsync()
        {
            return _slideRepository.GetSlidesAsync();
        }

        public Task<int> AddSlideAsync(TbSlide slide)
        {
            return _slideRepository.AddSlideAsync(slide);
        }

        public Task<int> RemoveSlideAsync(int slideId)
        {
            return _slideRepository.RemoveSlideAsync(slideId);
        }

        public Task<bool> DeleteSlideAsync(int slideId)
        {
            return _slideRepository.DeleteSlideAsync(slideId);
        }

        public Task<int> UpdateSlideAsync(TbSlide slide)
        {
            return _slideRepository.UpdateSlideAsync(slide);
        }
    }
}