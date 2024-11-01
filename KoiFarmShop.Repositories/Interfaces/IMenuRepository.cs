using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Repositories.Interfaces
{
    public interface IMenuRepository
    {
        Task<List<Menu>> GetMenuItems();
        Task<bool> AddMenuItem(Menu menuItem);
        Task<bool> RemoveMenuItemAsync(Menu menuItem);
        Task<bool> DeleteMenuItemAsync(int menuItemId);
        Task<bool> UpdateMenuItem(Menu menuItem);
    }
}
