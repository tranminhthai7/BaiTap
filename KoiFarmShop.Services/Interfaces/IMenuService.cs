using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Services.Interfaces
{
    public interface IMenuService
    {
        Task<List<Menu>> GetMenus();
        Task<bool> AddMenu(Menu menu);
        Task<bool> RemoveMenuAsync(Menu menu);
        Task<bool> DeleteMenuAsync(int menuId);
        Task<bool> UpdateMenu(Menu menu);
    }
}
