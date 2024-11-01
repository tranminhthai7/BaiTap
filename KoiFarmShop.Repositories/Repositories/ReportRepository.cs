using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;

namespace KoiFarmShop.Repositories.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly KoiFarmShop2024DbContext _dbContext;

        public ReportRepository(KoiFarmShop2024DbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public Task<bool> AddReport(Report report)
        {
            try
            {
                _dbContext.Reports.AddAsync(report);
                _dbContext.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex) 
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<bool> DeleteReportAsync(int reportId)
        {
            var objDel = await _dbContext.Reports.Where(p => p.ReportId.Equals(reportId)).FirstOrDefaultAsync();
            try
            {
                if (objDel != null)
                {
                    _dbContext.Reports.Remove(objDel);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                // Log the exception
                return false;
            }
        }

        public async Task<List<Report>> GetReports()
        {
            List<Report> reports = null;
            try
            {
                reports = await _dbContext.Reports.ToListAsync();
            }
            catch (Exception ex) 
            {
                reports?.Add(new Report());
            }
            return reports;
        }

        public Task<bool> RemoveReportAsync(Report report)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateReport(Report report)
        {
            try
            {
                _dbContext.Reports.Update(report);
                _dbContext.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                return Task.FromResult(false);
            }
        }
    }
}
