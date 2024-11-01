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
    public class InvoiceDetailRepository : IInvoiceDetailRepository
    {
        private readonly KoiFarmShop2024DbContext _dbContext;

        public InvoiceDetailRepository(KoiFarmShop2024DbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public Task<bool> AddInvoiceDetail(InvoiceDetail invoiceDetail)
        {
            try
            {
                _dbContext.InvoiceDetails.AddAsync(invoiceDetail);
                _dbContext.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex) 
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<bool> DeleteInvoiceDetailAsync(int invoiceDetailId)
        {
            var objDel = await _dbContext.InvoiceDetails.Where(p => p.InvoiceId.Equals(invoiceDetailId)).FirstOrDefaultAsync();
            try
            {
                if (objDel != null)
                {
                    _dbContext.InvoiceDetails.Remove(objDel);
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

        public async Task<List<InvoiceDetail>> GetInvoiceDetails()
        {
            List<InvoiceDetail> invoiceDetails = null;
            try
            {
                invoiceDetails = await _dbContext.InvoiceDetails.ToListAsync();
            }
            catch (Exception ex) 
            {
                invoiceDetails?.Add(new InvoiceDetail());
            }
            return invoiceDetails;
        }

        public Task<bool> RemoveInvoiceDetailAsync(InvoiceDetail invoiceDetail)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateInvoiceDetail(InvoiceDetail invoiceDetail)
        {
            try
            {
                _dbContext.InvoiceDetails.Update(invoiceDetail);
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
