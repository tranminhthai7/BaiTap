using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Repositories.Interfaces
{
    public interface IFeedbackRepository
    {
        Task<List<Feedback>> GetFeedbacks();
        Task<bool> AddFeedback(Feedback feedback);
        Task<bool> RemoveFeedbackAsync(Feedback feedback);
        Task<bool> DeleteFeedbackAsync(int feedbackId);
        Task<bool> UpdateFeedback(Feedback feedback);
    }
}
