using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;

namespace KoiFarmShop.Repositories.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly KoiFarmShopDbContext _dbContext;

        public SupplierRepository(KoiFarmShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TbSupplier>> GetSuppliersAsync()
        {
            try
            {
                return await _dbContext.TbSuppliers.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return new List<TbSupplier>();
            }
        }

        public async Task<int> AddSupplierAsync(TbSupplier supplier)
        {
            try
            {
                await _dbContext.TbSuppliers.AddAsync(supplier);
                await _dbContext.SaveChangesAsync();
                return supplier.Id; // Assuming Id is the primary key and is auto-generated
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return 0; // Return 0 to indicate failure
            }
        }

        public async Task<int> RemoveSupplierAsync(int supplierId)
        {
            var supplier = await _dbContext.TbSuppliers.FindAsync(supplierId);
            if (supplier == null)
            {
                return 0; // Return 0 to indicate that the record was not found
            }

            try
            {
                _dbContext.TbSuppliers.Remove(supplier);
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return 0; // Return 0 to indicate failure
            }
        }

        public async Task<bool> DeleteSupplierAsync(int supplierId)
        {
            var supplier = await _dbContext.TbSuppliers.FindAsync(supplierId);
            if (supplier == null)
            {
                return false; // Return false to indicate that the record was not found
            }

            try
            {
                _dbContext.TbSuppliers.Remove(supplier);
                await _dbContext.SaveChangesAsync();
                return true; // Return true to indicate success
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return false; // Return false to indicate failure
            }
        }

        public async Task<int> UpdateSupplierAsync(TbSupplier supplier)
        {
            try
            {
                _dbContext.TbSuppliers.Update(supplier);
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