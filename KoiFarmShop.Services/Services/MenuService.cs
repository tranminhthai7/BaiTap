using System;
using System.Collections.Generic;
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

        public Task<List<TbMenu>> GetMenusAsync()
        {
            return _menuRepository.GetMenusAsync();
        }

        public Task<int> AddMenuAsync(TbMenu menu)
        {
            return _menuRepository.AddMenuAsync(menu);
        }

        public Task<int> RemoveMenuAsync(int menuId)
        {
            return _menuRepository.RemoveMenuAsync(menuId);
        }

        public Task<bool> DeleteMenuAsync(int menuId)
        {
            return _menuRepository.DeleteMenuAsync(menuId);
        }

        public Task<int> UpdateMenuAsync(TbMenu menu)
        {
            return _menuRepository.UpdateMenuAsync(menu);
        }
    }
}