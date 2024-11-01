using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;

namespace KoiFarmShop.Repositories.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly KoiFarmShop2024DbContext _dbContext;

        public MenuRepository(KoiFarmShop2024DbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public Task<bool> AddMenu(Menu menu)
        {
            try
            {
                _dbContext.Menus.AddAsync(menu);
                _dbContext.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex) 
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public Task<bool> AddMenuItem(Menu menuItem)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteMenuAsync(int menuId)
        {
            var objDel = await _dbContext.Menus.Where(p => p.Id.Equals(menuId)).FirstOrDefaultAsync();
            try
            {
                if (objDel != null)
                {
                    _dbContext.Menus.Remove(objDel);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                // Log the exception
                return false;
            }
        }

        public Task<bool> DeleteMenuItemAsync(int menuItemId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Menu>> GetMenuItems()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Menu>> GetMenus()
        {
            List<Menu> menus = null;
            try
            {
                menus = await _dbContext.Menus.ToListAsync();
            }
            catch (Exception ex) 
            {
                menus?.Add(new Menu());
            }
            return menus;
        }

        public Task<bool> RemoveMenuAsync(Menu menu)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveMenuItemAsync(Menu menuItem)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateMenu(Menu menu)
        {
            try
            {
                _dbContext.Menus.Update(menu);
                _dbContext.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                return Task.FromResult(false);
            }
        }

        public Task<bool> UpdateMenuItem(Menu menuItem)
        {
            throw new NotImplementedException();
        }
    }
}
