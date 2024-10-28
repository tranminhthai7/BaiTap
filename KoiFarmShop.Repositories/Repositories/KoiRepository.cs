using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;

namespace KoiFarmShop.Repositories.Repositories
{
    public class KoiRepository : IKoiRepository
    {
        private readonly KoiFarmShopDbContext _dbContext;

        public KoiRepository(KoiFarmShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TbKoi>> GetKoisAsync()
        {
            try
            {
                return await _dbContext.TbKois.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return new List<TbKoi>();
            }
        }

        public async Task<int> AddKoiAsync(TbKoi koi)
        {
            try
            {
                await _dbContext.TbKois.AddAsync(koi);
                await _dbContext.SaveChangesAsync();
                return koi.Id; // Assuming Id is the primary key and is auto-generated
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return 0; // Return 0 to indicate failure
            }
        }

        public async Task<int> RemoveKoiAsync(int koiId)
        {
            var koi = await _dbContext.TbKois.FindAsync(koiId);
            if (koi == null)
            {
                return 0; // Return 0 to indicate that the record was not found
            }

            try
            {
                _dbContext.TbKois.Remove(koi);
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return 0; // Return 0 to indicate failure
            }
        }

        public async Task<bool> DeleteKoiAsync(int koiId)
        {
            var koi = await _dbContext.TbKois.FindAsync(koiId);
            if (koi == null)
            {
                return false; // Return false to indicate that the record was not found
            }

            try
            {
                _dbContext.TbKois.Remove(koi);
                await _dbContext.SaveChangesAsync();
                return true; // Return true to indicate success
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return false; // Return false to indicate failure
            }
        }

        public async Task<int> UpdateKoiAsync(TbKoi koi)
        {
            try
            {
                _dbContext.TbKois.Update(koi);
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