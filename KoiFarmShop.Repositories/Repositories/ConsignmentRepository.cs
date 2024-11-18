using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace KoiFarmShop.Repositories.Repositories
{
    public class ConsignmentRepository : IConsignmentRepository
    {
        private readonly KoiFarmShop2024DbContext _dbContext;
        private readonly ILogger<ConsignmentRepository> _logger;

        public ConsignmentRepository(KoiFarmShop2024DbContext dbContext, ILogger<ConsignmentRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<bool> AddConsignment(Consignment consignment)
        {
            try
            {
                await _dbContext.Consignments.AddAsync(consignment);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding consignment.");
                return false;
            }
        }

        public async Task<bool> DeleteConsignmentAsync(int consignmentId)
        {
            var objDel = await _dbContext.Consignments.Where(p => p.ConsignmentId.Equals(consignmentId)).FirstOrDefaultAsync();
            try
            {
                if (objDel != null)
                {
                    _dbContext.Consignments.Remove(objDel);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting consignment.");
                return false;
            }
        }

        public async Task<List<Consignment>> GetConsignments()
        {
            try
            {
                return await _dbContext.Consignments.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching consignments.");
                return new List<Consignment>();
            }
        }

        public async Task<bool> RemoveConsignmentAsync(Consignment consignment)
        {
            try
            {
                _dbContext.Consignments.Remove(consignment);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error removing consignment.");
                return false;
            }
        }

        public async Task<bool> UpdateConsignment(Consignment consignment)
        {
            try
            {
                _dbContext.Consignments.Update(consignment);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating consignment.");
                return false;
            }
        }
    }
}
