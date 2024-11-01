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
    public class SupplierRepository : ISupplierRepository
    {
        private readonly KoiFarmShop2024DbContext _dbContext;

        public SupplierRepository(KoiFarmShop2024DbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public Task<bool> AddSupplier(Supplier supplier)
        {
            try
            {
                _dbContext.Suppliers.AddAsync(supplier);
                _dbContext.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex) 
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<bool> DeleteSupplierAsync(int supplierId)
        {
            var objDel = await _dbContext.Suppliers.Where(p => p.Id.Equals(supplierId)).FirstOrDefaultAsync();
            try
            {
                if (objDel != null)
                {
                    _dbContext.Suppliers.Remove(objDel);
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

        public async Task<List<Supplier>> GetSuppliers()
        {
            List<Supplier> suppliers = null;
            try
            {
                suppliers = await _dbContext.Suppliers.ToListAsync();
            }
            catch (Exception ex) 
            {
                suppliers?.Add(new Supplier());
            }
            return suppliers;
        }

        public Task<bool> RemoveSupplierAsync(Supplier supplier)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateSupplier(Supplier supplier)
        {
            try
            {
                _dbContext.Suppliers.Update(supplier);
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
