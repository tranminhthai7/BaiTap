using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;

namespace KoiFarmShop.Repositories.Repositories
{
    public class ConfigRepository : IConfigRepository
    {
        private readonly KoiFarmShop2024DbContext _dbContext;

        public ConfigRepository(KoiFarmShop2024DbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public Task<bool> AddConfig(Config config)
        {
            try
            {
                _dbContext.Configs.AddAsync(config);
                _dbContext.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex) 
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<bool> DeleteConfigAsync(int configId)
        {
            var objDel = await _dbContext.Configs.Where(p => p.Id.Equals(configId)).FirstOrDefaultAsync();
            try
            {
                if (objDel != null)
                {
                    _dbContext.Configs.Remove(objDel);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                // Log lại lỗi
                return false;
            }
        }

        public async Task<List<Config>> GetConfigs()
        {
            List<Config> configs = null;
            try
            {
                configs = await _dbContext.Configs.ToListAsync();
            }
            catch (Exception ex) 
            {
                configs?.Add(new Config());
            }
            return configs;
        }

        public Task<bool> RemoveConfigAsync(Config config)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateConfig(Config config)
        {
            try
            {
                _dbContext.Configs.Update(config);
                _dbContext.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                return Task.FromResult(false);
            }
        }
    }
}
