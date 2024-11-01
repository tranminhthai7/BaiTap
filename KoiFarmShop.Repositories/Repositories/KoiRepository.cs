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
    public class KoiRepository : IKoiRepository
    {
        private readonly KoiFarmShop2024DbContext _dbContext;

        public KoiRepository(KoiFarmShop2024DbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public Task<bool> AddKoi(Koi koi)
        {
            try
            {
                _dbContext.Kois.AddAsync(koi);
                _dbContext.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex) 
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<bool> DeleteKoiAsync(int koiId)
        {
            var objDel = await _dbContext.Kois.Where(p => p.KoiId.Equals(koiId)).FirstOrDefaultAsync();
            try
            {
                if (objDel != null)
                {
                    _dbContext.Kois.Remove(objDel);
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

        public async Task<List<Koi>> GetKois()
        {
            List<Koi> kois = null;
            try
            {
                kois = await _dbContext.Kois.ToListAsync();
            }
            catch (Exception ex) 
            {
                kois?.Add(new Koi());
            }
            return kois;
        }

        public Task<bool> RemoveKoiAsync(Koi koi)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateKoi(Koi koi)
        {
            try
            {
                _dbContext.Kois.Update(koi);
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
