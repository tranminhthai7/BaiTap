using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;

namespace KoiFarmShop.Repositories.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly KoiFarmShopDbContext _dbContext;

        public FeedbackRepository(KoiFarmShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TbFeedback>> GetFeedbacksAsync()
        {
            try
            {
                return await _dbContext.TbFeedbacks.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return new List<TbFeedback>();
            }
        }

        public async Task<int> AddFeedbackAsync(TbFeedback feedback)
        {
            try
            {
                await _dbContext.TbFeedbacks.AddAsync(feedback);
                await _dbContext.SaveChangesAsync();
                return feedback.Id; // Assuming Id is the primary key and is auto-generated
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return 0; // Return 0 to indicate failure
            }
        }

        public async Task<int> RemoveFeedbackAsync(int feedbackId)
        {
            var feedback = await _dbContext.TbFeedbacks.FindAsync(feedbackId);
            if (feedback == null)
            {
                return 0; // Return 0 to indicate that the record was not found
            }

            try
            {
                _dbContext.TbFeedbacks.Remove(feedback);
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return 0; // Return 0 to indicate failure
            }
        }

        public async Task<bool> DeleteFeedbackAsync(int feedbackId)
        {
            var feedback = await _dbContext.TbFeedbacks.FindAsync(feedbackId);
            if (feedback == null)
            {
                return false; // Return false to indicate that the record was not found
            }

            try
            {
                _dbContext.TbFeedbacks.Remove(feedback);
                await _dbContext.SaveChangesAsync();
                return true; // Return true to indicate success
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return false; // Return false to indicate failure
            }
        }

        public async Task<int> UpdateFeedbackAsync(TbFeedback feedback)
        {
            try
            {
                _dbContext.TbFeedbacks.Update(feedback);
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