using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;

namespace KoiFarmShop.Repositories.Repositories
{
    public class InvoiceDetailRepository : IInvoiceDetailRepository
    {
        private readonly KoiFarmShopDbContext _dbContext;

        public InvoiceDetailRepository(KoiFarmShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TbInvoiceDetail>> GetInvoiceDetailsAsync()
        {
            try
            {
                return await _dbContext.TbInvoiceDetails.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return new List<TbInvoiceDetail>();
            }
        }

        public async Task<int> AddInvoiceDetailAsync(TbInvoiceDetail invoiceDetail)
        {
            try
            {
                await _dbContext.TbInvoiceDetails.AddAsync(invoiceDetail);
                await _dbContext.SaveChangesAsync();
                return invoiceDetail.Id; // Assuming Id is the primary key and is auto-generated
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return 0; // Return 0 to indicate failure
            }
        }

        public async Task<int> RemoveInvoiceDetailAsync(int invoiceDetailId)
        {
            var invoiceDetail = await _dbContext.TbInvoiceDetails.FindAsync(invoiceDetailId);
            if (invoiceDetail == null)
            {
                return 0; // Return 0 to indicate that the record was not found
            }

            try
            {
                _dbContext.TbInvoiceDetails.Remove(invoiceDetail);
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return 0; // Return 0 to indicate failure
            }
        }

        public async Task<bool> DeleteInvoiceDetailAsync(int invoiceDetailId)
        {
            var invoiceDetail = await _dbContext.TbInvoiceDetails.FindAsync(invoiceDetailId);
            if (invoiceDetail == null)
            {
                return false; // Return false to indicate that the record was not found
            }

            try
            {
                _dbContext.TbInvoiceDetails.Remove(invoiceDetail);
                await _dbContext.SaveChangesAsync();
                return true; // Return true to indicate success
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return false; // Return false to indicate failure
            }
        }

        public async Task<int> UpdateInvoiceDetailAsync(TbInvoiceDetail invoiceDetail)
        {
            try
            {
                _dbContext.TbInvoiceDetails.Update(invoiceDetail);
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