using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;
using KoiFarmShop.Services.Interfaces;

namespace KoiFarmShop.Services.Services
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepository;

        public MenuService(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public Task<bool> AddMenu(Menu menu)
        {
            return _menuRepository.AddMenu(menu);
        }

        public Task<bool> DeleteMenuAsync(int menuId)
        {
            return _menuRepository.DeleteMenuAsync(menuId);
        }

        public async Task<List<Menu>> GetMenusAsync()
        {
            return await _menuRepository.GetMenus();
        }

        public Task<bool> RemoveMenuAsync(Menu menu)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateMenu(Menu menu)
        {
            return _menuRepository.UpdateMenu(menu);
        }
    }
}
