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
        Task<List<MenuItem>> GetMenuItems();
        Task<bool> AddMenuItem(MenuItem menuItem);
        Task<bool> RemoveMenuItemAsync(MenuItem menuItem);
        Task<bool> DeleteMenuItemAsync(int menuItemId);
        Task<bool> UpdateMenuItem(MenuItem menuItem);
    }
}
