using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Services.Interfaces
{
    public interface IFooterService
    {
        Task<List<TbFooter>> GetFootersAsync();
        Task<int> AddFooterAsync(TbFooter footer);
        Task<int> RemoveFooterAsync(int footerId);
        Task<bool> DeleteFooterAsync(int footerId);
        Task<int> UpdateFooterAsync(TbFooter footer);
    }
}