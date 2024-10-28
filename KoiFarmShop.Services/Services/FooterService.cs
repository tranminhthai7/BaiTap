using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;
using KoiFarmShop.Services.Interfaces;

namespace KoiFarmShop.Services.Services
{
    public class FooterService : IFooterService
    {
        private readonly IFooterRepository _footerRepository;

        public FooterService(IFooterRepository footerRepository)
        {
            _footerRepository = footerRepository;
        }

        public Task<List<TbFooter>> GetFootersAsync()
        {
            return _footerRepository.GetFootersAsync();
        }

        public Task<int> AddFooterAsync(TbFooter footer)
        {
            return _footerRepository.AddFooterAsync(footer);
        }

        public Task<int> RemoveFooterAsync(int footerId)
        {
            return _footerRepository.RemoveFooterAsync(footerId);
        }

        public Task<bool> DeleteFooterAsync(int footerId)
        {
            return _footerRepository.DeleteFooterAsync(footerId);
        }

        public Task<int> UpdateFooterAsync(TbFooter footer)
        {
            return _footerRepository.UpdateFooterAsync(footer);
        }
    }
}