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
    public class SlideRepository : ISlideRepository
    {
        private readonly KoiFarmShop2024DbContext _dbContext;

        public SlideRepository(KoiFarmShop2024DbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public Task<bool> AddSlide(Slide slide)
        {
            try
            {
                _dbContext.Slides.AddAsync(slide);
                _dbContext.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex) 
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<bool> DeleteSlideAsync(int slideId)
        {
            var objDel = await _dbContext.Slides.Where(p => p.Id.Equals(slideId)).FirstOrDefaultAsync();
            try
            {
                if (objDel != null)
                {
                    _dbContext.Slides.Remove(objDel);
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

        public async Task<List<Slide>> GetSlides()
        {
            List<Slide> slides = null;
            try
            {
                slides = await _dbContext.Slides.ToListAsync();
            }
            catch (Exception ex) 
            {
                slides?.Add(new Slide());
            }
            return slides;
        }

        public Task<bool> RemoveSlideAsync(Slide slide)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateSlide(Slide slide)
        {
            try
            {
                _dbContext.Slides.Update(slide);
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
