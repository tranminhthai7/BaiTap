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
    public class ConsignmentRepository : IConsignmentRepository
    {
        private readonly KoiFarmShop2024DbContext _dbContext;

        public ConsignmentRepository(KoiFarmShop2024DbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public Task<bool> AddConsignment(Consignment consignment)
        {
            try
            {
                _dbContext.Consignments.AddAsync(consignment);
                _dbContext.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex) 
            {
                throw new NotImplementedException(ex.ToString());
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
                // Log the exception
                return false;
            }
        }

        public Task<List<Consignment>> GetConsignments()
        {
            // Implementation of GetConsignments method
            // For example, fetching consignments from a database
            return Task.FromResult(new List<Consignment>());
        }

        public async Task<List<Consignment>> GetAllConsignments()
        {
            try
            {
                return await _dbContext.Consignments.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log the exception
                return new List<Consignment>();
            }
        }

        public Task<bool> RemoveConsignmentAsync(Consignment consignment)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateConsignment(Consignment consignment)
        {
            try
            {
                _dbContext.Consignments.Update(consignment);
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
