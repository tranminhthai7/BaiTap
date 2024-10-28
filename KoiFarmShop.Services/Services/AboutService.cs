using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;
using KoiFarmShop.Services.Interfaces;

namespace KoiFarmShop.Services.Services
{
    public class AboutService : IAboutService
    {
        private readonly IAboutRepository _aboutRepository;

        public AboutService(IAboutRepository aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }

        public Task<List<TbAbout>> GetAboutsAsync()
        {
            return _aboutRepository.GetAboutsAsync();
        }

        public Task<int> AddAboutAsync(TbAbout about)
        {
            return _aboutRepository.AddAboutAsync(about);
        }

        public Task<int> RemoveAboutAsync(int aboutId)
        {
            return _aboutRepository.RemoveAboutAsync(aboutId);
        }

        public Task<bool> DeleteAboutAsync(int aboutId)
        {
            return _aboutRepository.DeleteAboutAsync(aboutId);
        }

        public Task<int> UpdateAboutAsync(TbAbout about)
        {
            return _aboutRepository.UpdateAboutAsync(about);
        }
    }
}