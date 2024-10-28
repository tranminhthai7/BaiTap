using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Repositories.Interfaces
{
    public interface IReportRepository
    {
        Task<List<TbReport>> GetReportsAsync();
        Task<int> AddReportAsync(TbReport report);
        Task<int> RemoveReportAsync(int reportId);
        Task<bool> DeleteReportAsync(int reportId);
        Task<int> UpdateReportAsync(TbReport report);
    }
}