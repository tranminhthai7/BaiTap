using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;

namespace KoiFarmShop.Repositories.Repositories
{
    public class ConfigRepository : IConfigRepository
    {
        private readonly KoiFarmShopDbContext _dbContext;

        public ConfigRepository(KoiFarmShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TbConfig>> GetConfigsAsync()
        {
            try
            {
                return await _dbContext.TbConfigs.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return new List<TbConfig>();
            }
        }

        public async Task<int> AddConfigAsync(TbConfig config)
        {
            try
            {
                await _dbContext.TbConfigs.AddAsync(config);
                await _dbContext.SaveChangesAsync();
                return config.Id; // Assuming Id is the primary key and is auto-generated
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return 0; //