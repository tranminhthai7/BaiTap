using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Repositories.Interfaces
{
    public interface IFooterRepository
    {
        Task<List<TbFooter>> GetFootersAsync();
        Task<int> AddFooterAsync(TbFooter footer);
        Task<int> RemoveFooterAsync(int footerId);
        Task<bool> DeleteFooterAsync(int footerId);
        Task<int> UpdateFooterAsync(TbFooter footer);
    }
}