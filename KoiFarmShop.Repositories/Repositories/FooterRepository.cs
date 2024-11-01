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
    public class FooterRepository : IFooterRepository
    {
        private readonly KoiFarmShop2024DbContext _dbContext;

        public FooterRepository(KoiFarmShop2024DbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public Task<bool> AddFooter(Footer footer)
        {
            try
            {
                _dbContext.Footers.AddAsync(footer);
                _dbContext.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex) 
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<bool> DeleteFooterAsync(int footerId)
        {
            var objDel = await _dbContext.Footers.Where(p => p.Id.Equals(footerId)).FirstOrDefaultAsync();
            try
            {
                if (objDel != null)
                {
                    _dbContext.Footers.Remove(objDel);
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

        public async Task<List<Footer>> GetFooters()
        {
            List<Footer> footers = null;
            try
            {
                footers = await _dbContext.Footers.ToListAsync();
            }
            catch (Exception ex) 
            {
                footers?.Add(new Footer());
            }
            return footers;
        }

        public Task<bool> RemoveFooterAsync(Footer footer)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateFooter(Footer footer)
        {
            try
            {
                _dbContext.Footers.Update(footer);
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
