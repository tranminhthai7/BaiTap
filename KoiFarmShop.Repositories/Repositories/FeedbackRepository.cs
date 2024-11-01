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
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly KoiFarmShop2024DbContext _dbContext;

        public FeedbackRepository(KoiFarmShop2024DbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public Task<bool> AddFeedback(Feedback feedback)
        {
            try
            {
                _dbContext.Feedbacks.AddAsync(feedback);
                _dbContext.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex) 
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<bool> DeleteFeedbackAsync(int feedbackId)
        {
            var objDel = await _dbContext.Feedbacks.Where(p => p.Id.Equals(feedbackId)).FirstOrDefaultAsync();
            try
            {
                if (objDel != null)
                {
                    _dbContext.Feedbacks.Remove(objDel);
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

        public async Task<List<Feedback>> GetFeedbacks()
        {
            List<Feedback> feedbacks = null;
            try
            {
                feedbacks = await _dbContext.Feedbacks.ToListAsync();
            }
            catch (Exception ex) 
            {
                feedbacks?.Add(new Feedback());
            }
            return feedbacks;
        }

        public Task<bool> RemoveFeedbackAsync(Feedback feedback)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateFeedback(Feedback feedback)
        {
            try
            {
                _dbContext.Feedbacks.Update(feedback);
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
