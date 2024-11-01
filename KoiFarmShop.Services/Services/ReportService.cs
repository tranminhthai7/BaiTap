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
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;

        public ReportService(IReportRepository reportRepository) {
            _reportRepository = reportRepository;
        }

        public Task<bool> AddReport(Report report)
        {
            return _reportRepository.AddReport(report);
        }

        public Task<bool> DeleteReportAsync(int reportId)
        {
            return _reportRepository.DeleteReportAsync(reportId);
        }

        public async Task<List<Report>> GetReports()
        {
            return await _reportRepository.GetReports();
        }

        public Task<bool> UpdateReport(Report report)
        {
            return _reportRepository.UpdateReport(report);
        }

        public Task<bool> RemoveReportAsync(Report report)
        {
            throw new NotImplementedException();
        }
    }
}
