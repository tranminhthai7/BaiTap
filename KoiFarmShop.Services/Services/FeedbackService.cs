using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;
using KoiFarmShop.Services.Interfaces;

namespace KoiFarmShop.Services.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public FeedbackService(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        public Task<List<TbFeedback>> GetFeedbacksAsync()
        {
            return _feedbackRepository.GetFeedbacksAsync();
        }

        public Task<int> AddFeedbackAsync(TbFeedback feedback)
        {
            return _feedbackRepository.AddFeedbackAsync(feedback);
        }

        public Task<int> RemoveFeedbackAsync(int feedbackId)
        {
            return _feedbackRepository.RemoveFeedbackAsync(feedbackId);
        }

        public Task<bool> DeleteFeedbackAsync(int feedbackId)
        {
            return _feedbackRepository.DeleteFeedbackAsync(feedbackId);
        }

        public Task<int> UpdateFeedbackAsync(TbFeedback feedback)
        {
            return _feedbackRepository.UpdateFeedbackAsync(feedback);
        }
    }
}