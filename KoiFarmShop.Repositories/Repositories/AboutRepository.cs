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
    public class AboutRepository : IAboutRepository
    {
        private readonly KoiFarmShop2024DbContext _dbContext;

        public AboutRepository(KoiFarmShop2024DbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public Task<bool> AddAbout(About about)
        {
            try
            {
                _dbContext.Abouts.AddAsync(about);
                _dbContext.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex) 
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<bool> DeleteAboutAsync(int aboutId)
        {
            var objDel = await _dbContext.Abouts.Where(p => p.Id.Equals(aboutId)).FirstOrDefaultAsync();
            try
            {
                if (objDel != null)
                {
                    _dbContext.Abouts.Remove(objDel);
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

        public async Task<List<About>> GetAbouts()
        {
            List<About> abouts = null;
            try
            {
                abouts = await _dbContext.Abouts.ToListAsync();
            }
            catch (Exception ex) 
            {
                abouts?.Add(new About());
            }
            return abouts;
        }

        public Task<bool> RemoveAboutAsync(About about)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAbout(About about)
        {
            try
            {
                _dbContext.Abouts.Update(about);
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
