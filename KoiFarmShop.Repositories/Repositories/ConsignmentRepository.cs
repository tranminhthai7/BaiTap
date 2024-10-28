using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;

namespace KoiFarmShop.Repositories.Repositories
{
    public class ConsignmentRepository : IConsignmentRepository
    {
        private readonly KoiFarmShopDbContext _dbContext;

        public ConsignmentRepository(KoiFarmShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddConsignmentAsync(IConsignment consignment)
        {
            try
            {
                await _dbContext.Consignments.AddAsync(consignment);
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return 0; // Return 0 to indicate failure
            }
        }

        public async Task<int> UpdateConsignmentAsync(IConsignment consignment)
        {
            try
            {
                _dbContext.Consignments.Update(consignment);
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return 0; // Return 0 to indicate failure
            }
        }

        public async Task<int> DeleteConsignmentAsync(int consignmentId)
        {
            var consignment = await _dbContext.Consignments.FindAsync(consignmentId);
            if (consignment == null)
            {
                return 0; // Return 0 to indicate that the record was not found
            }

            try
            {
                _dbContext.Consignments.Remove(consignment);
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return 0; // Return 0 to indicate failure
            }
        }

        public async Task<IEnumerable<IConsignment>> GetAllConsignmentsAsync()
        {
            try
            {
                return await _dbContext.Consignments.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return new List<IConsignment>();
            }
        }
    }
}