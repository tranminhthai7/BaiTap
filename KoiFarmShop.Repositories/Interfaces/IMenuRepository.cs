using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Repositories.Interfaces
{
    public interface IMenuRepository
    {
        Task<List<TbMenu>> GetMenusAsync();
        Task<int> AddMenuAsync(TbMenu menu);
        Task<int> RemoveMenuAsync(int menuId);
        Task<bool> DeleteMenuAsync(int menuId);
        Task<int> UpdateMenuAsync(TbMenu menu);
    }
}