using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Services.Interfaces
{
    public interface IReportService
    {
        Task<List<TbReport>> GetReportsAsync();
        Task<int> AddReportAsync(TbReport report);
        Task<int> RemoveReportAsync(int reportId);
        Task<bool> DeleteReportAsync(int reportId);
        Task<int> UpdateReportAsync(TbReport report);
    }
}