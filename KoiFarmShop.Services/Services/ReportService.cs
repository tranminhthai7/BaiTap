using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;
using KoiFarmShop.Services.Interfaces;

namespace KoiFarmShop.Services.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;

        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public Task<List<TbReport>> GetReportsAsync()
        {
            return _reportRepository.GetReportsAsync();
        }

        public Task<int> AddReportAsync(TbReport report)
        {
            return _reportRepository.AddReportAsync(report);
        }

        public Task<int> RemoveReportAsync(int reportId)
        {
            return _reportRepository.RemoveReportAsync(reportId);
        }

        public Task<bool> DeleteReportAsync(int reportId)
        {
            return _reportRepository.DeleteReportAsync(reportId);
        }

        public Task<int> UpdateReportAsync(TbReport report)
        {
            return _reportRepository.UpdateReportAsync(report);
        }
    }
}