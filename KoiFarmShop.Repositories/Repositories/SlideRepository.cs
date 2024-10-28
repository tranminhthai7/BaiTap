using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;

namespace KoiFarmShop.Repositories.Repositories
{
    public class SlideRepository : ISlideRepository
    {
        private readonly KoiFarmShopDbContext _dbContext;

        public SlideRepository(KoiFarmShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TbSlide>> GetSlidesAsync()
        {
            try
            {
                return await _dbContext.TbSlides.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return new List<TbSlide>();
            }
        }

        public async Task<int> AddSlideAsync(TbSlide slide)
        {
            try
            {
                await _dbContext.TbSlides.AddAsync(slide);
                await _dbContext.SaveChangesAsync();
                return slide.Id; // Assuming Id is the primary key and is auto-generated
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return 0; // Return 0 to indicate failure
            }
        }

        public async Task<int> RemoveSlideAsync(int slideId)
        {
            var slide = await _dbContext.TbSlides.FindAsync(slideId);
            if (slide == null)
            {
                return 0; // Return 0 to indicate that the record was not found
            }

            try
            {
                _dbContext.TbSlides.Remove(slide);
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return 0; // Return 0 to indicate failure
            }
        }

        public async Task<bool> DeleteSlideAsync(int slideId)
        {
            var slide = await _dbContext.TbSlides.FindAsync(slideId);
            if (slide == null)
            {
                return false; // Return false to indicate that the record was not found
            }

            try
            {
                _dbContext.TbSlides.Remove(slide);
                await _dbContext.SaveChangesAsync();
                return true; // Return true to indicate success
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return false; // Return false to indicate failure
            }
        }

        public async Task<int> UpdateSlideAsync(TbSlide slide)
        {
            try
            {
                _dbContext.TbSlides.Update(slide);
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