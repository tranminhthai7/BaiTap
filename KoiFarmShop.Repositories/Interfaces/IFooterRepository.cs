using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Repositories.Interfaces
{
    public interface IFooterRepository
    {
        Task<List<Footer>> GetFooters();
        Task<bool> AddFooter(Footer footer);
        Task<bool> RemoveFooterAsync(Footer footer);
        Task<bool> DeleteFooterAsync(int footerId);
        Task<bool> UpdateFooter(Footer footer);
    }
}
