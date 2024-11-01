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
    public class FooterService : IFooterService
    {
        private readonly IFooterRepository _footerRepository;

        public FooterService(IFooterRepository footerRepository) {
            _footerRepository = footerRepository;
        }

        public Task<bool> AddFooter(Footer footer)
        {
            return _footerRepository.AddFooter(footer);
        }

        public Task<bool> DeleteFooterAsync(int footerId)
        {
            return _footerRepository.DeleteFooterAsync(footerId);
        }

        public async Task<List<Footer>> GetFooters()
        {
            return await _footerRepository.GetFooters();
        }

        public Task<bool> UpdateFooter(Footer footer)
        {
            return _footerRepository.UpdateFooter(footer);
        }

        public Task<bool> RemoveFooterAsync(Footer footer)
        {
            throw new NotImplementedException();
        }
    }
}
