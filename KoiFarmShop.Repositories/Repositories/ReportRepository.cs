using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;

namespace KoiFarmShop.Repositories.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly KoiFarmShopDbContext _dbContext;

        public ReportRepository(KoiFarmShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TbReport>> GetReportsAsync()
        {
            try
            {
                return await _dbContext.TbReports.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return new List<TbReport>();
            }
        }

        public async Task<int> AddReportAsync(TbReport report)
        {
            try
            {
                await _dbContext.TbReports.AddAsync(report);
                await _dbContext.SaveChangesAsync();
                return report.Id; // Assuming Id is the primary key and is auto-generated
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return 0; // Return 0 to indicate failure
            }
        }

        public async Task<int> RemoveReportAsync(int reportId)
        {
            var report = await _dbContext.TbReports.FindAsync(reportId);
            if (report == null)
            {
                return 0; // Return 0 to indicate that the record was not found
            }

            try
            {
                _dbContext.TbReports.Remove(report);
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return 0; // Return 0 to indicate failure
            }
        }

        public async Task<bool> DeleteReportAsync(int reportId)
        {
            var report = await _dbContext.TbReports.FindAsync(reportId);
            if (report == null)
            {
                return false; // Return false to indicate that the record was not found
            }

            try
            {
                _dbContext.TbReports.Remove(report);
                await _dbContext.SaveChangesAsync();
                return true; // Return true to indicate success
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return false; // Return false to indicate failure
            }
        }

        public async Task<int> UpdateReportAsync(TbReport report)
        {
            try
            {
                _dbContext.TbReports.Update(report);
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return 0; // Return 0 to indicate failure
            }
        }
    }
}