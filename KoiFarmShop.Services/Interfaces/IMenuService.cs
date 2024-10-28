using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Services.Interfaces
{
    public interface IMenuService
    {
        Task<List<TbMenu>> GetMenusAsync();
        Task<int> AddMenuAsync(TbMenu menu);
        Task<int> RemoveMenuAsync(int menuId);
        Task<bool> DeleteMenuAsync(int menuId);
        Task<int> UpdateMenuAsync(TbMenu menu);
    }
}