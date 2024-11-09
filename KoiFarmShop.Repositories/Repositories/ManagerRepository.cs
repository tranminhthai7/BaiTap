using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;

namespace KoiFarmShop.Repositories.Repositories
{
    public class ManagerRepository : IManagerRepository
    {
        private readonly KoiFarmShop2024DbContext _dbContext;

        public ManagerRepository(KoiFarmShop2024DbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddManager(Manager manager)
        {
            try
            {
                await _dbContext.Managers.AddAsync(manager);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) 
            {
                // Log the exception
                return false;
            }
        }

        public async Task<bool> DeleteManagerAsync(int managerId)
        {
            var objDel = await _dbContext.Managers.Where(p => p.ManagerID.Equals(managerId)).FirstOrDefaultAsync();
            try
            {
                if (objDel != null)
                {
                    _dbContext.Managers.Remove(objDel);
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

        public async Task<List<Manager>> GetManagers()
        {
            List<Manager> managers = null;
            try
            {
                managers = await _dbContext.Managers.ToListAsync();
            }
            catch (Exception ex) 
            {
                // Log the exception
            }
            return managers;
        }

        public async Task<bool> RemoveManagerAsync(Manager manager)
        {
            try
            {
                _dbContext.Managers.Remove(manager);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception
                return false;
            }
        }

        public async Task<bool> UpdateManager(Manager manager)
        {
            try
            {
                _dbContext.Managers.Update(manager);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception
                return false;
            }
        }
    }
}