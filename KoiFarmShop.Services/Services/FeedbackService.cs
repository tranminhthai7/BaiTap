using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;
using KoiFarmShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarmShop.Services.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public FeedbackService(IFeedbackRepository feedbackRepository) {
            _feedbackRepository = feedbackRepository;
        }

        public Task<bool> AddFeedback(Feedback feedback)
        {
            return _feedbackRepository.AddFeedback(feedback);
        }

        public Task<bool> DeleteFeedbackAsync(int feedbackId)
        {
            return _feedbackRepository.DeleteFeedbackAsync(feedbackId);
        }

        public async Task<List<Feedback>> GetFeedbacks()
        {
            return await _feedbackRepository.GetFeedbacks();
        }

        public Task<bool> UpdateFeedback(Feedback feedback)
        {
            return _feedbackRepository.UpdateFeedback(feedback);
        }

        public Task<bool> RemoveFeedbackAsync(Feedback feedback)
        {
            throw new NotImplementedException();
        }
    }
}
