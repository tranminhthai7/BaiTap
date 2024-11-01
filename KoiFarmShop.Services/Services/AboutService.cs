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
    public class AboutService : IAboutService
    {
        private IAboutRepository _aboutRepository;

        public AboutService(IAboutRepository aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }

        public Task<bool> AddAbout(About about)
        {
            return _aboutRepository.AddAbout(about);
        }

        public Task<bool> DeleteAboutAsync(int aboutId)
        {
            return _aboutRepository.DeleteAboutAsync(aboutId);
        }

        public async Task<List<About>> GetAboutsAsync()
        {
            return await _aboutRepository.GetAbouts();
        }

        public Task<bool> RemoveAboutAsync(About about)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAbout(About about)
        {
            return _aboutRepository.UpdateAbout(about);
        }
    }
}
