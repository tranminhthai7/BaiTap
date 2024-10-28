using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;

namespace KoiFarmShop.Repositories.Repositories
{
    public class AboutRepository : IAboutRepository
    {
        private readonly KoiFarmShopDbContext _dbContext;

        public AboutRepository(KoiFarmShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TbAbout>> GetAboutsAsync()
        {
            try
            {
                return await _dbContext.TbAbouts.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return new List<TbAbout>();
            }
        }

        public async Task<int> AddAboutAsync(TbAbout about)
        {
            try
            {
                await _dbContext.TbAbouts.AddAsync(about);
                await _dbContext.SaveChangesAsync();
                return about.Id; // Assuming Id is the primary key and is auto-generated
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return 0; // Return 0 to indicate failure
            }
        }

        public async Task<int> RemoveAboutAsync(int aboutId)
        {
            var about = await _dbContext.TbAbouts.FindAsync(aboutId);
            if (about == null)
            {
                return 0; // Return 0 to indicate that the record was not found
            }

            try
            {
                _dbContext.TbAbouts.Remove(about);
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return 0; // Return 0 to indicate failure
            }
        }

        public async Task<bool> DeleteAboutAsync(int aboutId)
        {
            var about = await _dbContext.TbAbouts.FindAsync(aboutId);
            if (about == null)
            {
                return false; // Return false to indicate that the record was not found
            }

            try
            {
                _dbContext.TbAbouts.Remove(about);
                await _dbContext.SaveChangesAsync();
                return true; // Return true to indicate success
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return false; // Return false to indicate failure
            }
        }

        public async Task<int> UpdateAboutAsync(TbAbout about)
        {
            try
            {
                _dbContext.TbAbouts.Update(about);
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