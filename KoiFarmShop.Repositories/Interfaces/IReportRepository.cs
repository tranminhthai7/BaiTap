using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Repositories.Interfaces
{
    public interface IReportRepository
    {
        Task<List<Report>> GetReports();
        Task<bool> AddReport(Report report);
        Task<bool> RemoveReportAsync(Report report);
        Task<bool> DeleteReportAsync(int reportId);
        Task<bool> UpdateReport(Report report);
    }
}