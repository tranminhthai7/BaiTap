using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Services.Interfaces
{
    public interface IFeedbackService
    {
        Task<List<TbFeedback>> GetFeedbacksAsync();
        Task<int> AddFeedbackAsync(TbFeedback feedback);
        Task<int> RemoveFeedbackAsync(int feedbackId);
        Task<bool> DeleteFeedbackAsync(int feedbackId);
        Task<int> UpdateFeedbackAsync(TbFeedback feedback);
    }
}