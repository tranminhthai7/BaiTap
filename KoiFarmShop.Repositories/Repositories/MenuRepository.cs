using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;

namespace KoiFarmShop.Repositories.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly KoiFarmShopDbContext _dbContext;

        public MenuRepository(KoiFarmShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TbMenu>> GetMenusAsync()
        {
            try
            {
                return await _dbContext.TbMenus.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return new List<TbMenu>();
            }
        }

        public async Task<int> AddMenuAsync(TbMenu menu)
        {
            try
            {
                await _dbContext.TbMenus.AddAsync(menu);
                await _dbContext.SaveChangesAsync();
                return menu.Id; // Assuming Id is the primary key and is auto-generated
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return 0; // Return 0 to indicate failure
            }
        }

        public async Task<int> RemoveMenuAsync(int menuId)
        {
            var menu = await _dbContext.TbMenus.FindAsync(menuId);
            if (menu == null)
            {
                return 0; // Return 0 to indicate that the record was not found
            }

            try
            {
                _dbContext.TbMenus.Remove(menu);
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return 0; // Return 0 to indicate failure
            }
        }

        public async Task<bool> DeleteMenuAsync(int menuId)
        {
            var menu = await _dbContext.TbMenus.FindAsync(menuId);
            if (menu == null)
            {
                return false; // Return false to indicate that the record was not found
            }

            try
            {
                _dbContext.TbMenus.Remove(menu);
                await _dbContext.SaveChangesAsync();
                return true; // Return true to indicate success
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return false; // Return false to indicate failure
            }
        }

        public async Task<int> UpdateMenuAsync(TbMenu menu)
        {
            try
            {
                _dbContext.TbMenus.Update(menu);
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return 0; // Return 0 to indicate failure
            }
        }
    }
}