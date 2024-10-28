using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;

namespace KoiFarmShop.Repositories.Repositories
{
    public class FooterRepository : IFooterRepository
    {
        private readonly KoiFarmShopDbContext _dbContext;

        public FooterRepository(KoiFarmShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TbFooter>> GetFootersAsync()
        {
            try
            {
                return await _dbContext.TbFooters.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return new List<TbFooter>();
            }
        }

        public async Task<int> AddFooterAsync(TbFooter footer)
        {
            try
            {
                await _dbContext.TbFooters.AddAsync(footer);
                await _dbContext.SaveChangesAsync();
                return footer.Id; // Assuming Id is the primary key and is auto-generated
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return 0; // Return 0 to indicate failure
            }
        }

        public async Task<int> RemoveFooterAsync(int footerId)
        {
            var footer = await _dbContext.TbFooters.FindAsync(footerId);
            if (footer == null)
            {
                return 0; // Return 0 to indicate that the record was not found
            }

            try
            {
                _dbContext.TbFooters.Remove(footer);
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return 0; // Return 0 to indicate failure
            }
        }

        public async Task<bool> DeleteFooterAsync(int footerId)
        {
            var footer = await _dbContext.TbFooters.FindAsync(footerId);
            if (footer == null)
            {
                return false; // Return false to indicate that the record was not found
            }

            try
            {
                _dbContext.TbFooters.Remove(footer);
                await _dbContext.SaveChangesAsync();
                return true; // Return true to indicate success
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return false; // Return false to indicate failure
            }
        }

        public async Task<int> UpdateFooterAsync(TbFooter footer)
        {
            try
            {
                _dbContext.TbFooters.Update(footer);
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