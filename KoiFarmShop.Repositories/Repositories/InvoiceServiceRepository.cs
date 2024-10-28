using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;

namespace KoiFarmShop.Repositories.Repositories
{
    public class InvoiceServiceRepository : IInvoiceServiceRepository
    {
        private readonly KoiFarmShopDbContext _dbContext;

        public InvoiceServiceRepository(KoiFarmShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TbInvoiceService>> GetInvoiceServicesAsync()
        {
            try
            {
                return await _dbContext.TbInvoiceServices.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return new List<TbInvoiceService>();
            }
        }

        public async Task<int> AddInvoiceServiceAsync(TbInvoiceService invoiceService)
        {
            try
            {
                await _dbContext.TbInvoiceServices.AddAsync(invoiceService);
                await _dbContext.SaveChangesAsync();
                return invoiceService.Id; // Assuming Id is the primary key and is auto-generated
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return 0; // Return 0 to indicate failure
            }
        }

        public async Task<int> RemoveInvoiceServiceAsync(int invoiceServiceId)
        {
            var invoiceService = await _dbContext.TbInvoiceServices.FindAsync(invoiceServiceId);
            if (invoiceService == null)
            {
                return 0; // Return 0 to indicate that the record was not found
            }

            try
            {
                _dbContext.TbInvoiceServices.Remove(invoiceService);
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return 0; // Return 0 to indicate failure
            }
        }

        public async Task<bool> DeleteInvoiceServiceAsync(int invoiceServiceId)
        {
            var invoiceService = await _dbContext.TbInvoiceServices.FindAsync(invoiceServiceId);
            if (invoiceService == null)
            {
                return false; // Return false to indicate that the record was not found
            }

            try
            {
                _dbContext.TbInvoiceServices.Remove(invoiceService);
                await _dbContext.SaveChangesAsync();
                return true; // Return true to indicate success
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return false; // Return false to indicate failure
            }
        }

        public async Task<int> UpdateInvoiceServiceAsync(TbInvoiceService invoiceService)
        {
            try
            {
                _dbContext.TbInvoiceServices.Update(invoiceService);
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