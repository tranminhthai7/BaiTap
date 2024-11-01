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
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly KoiFarmShop2024DbContext _dbContext;

        public InvoiceRepository(KoiFarmShop2024DbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public Task<bool> AddInvoice(Invoice invoice)
        {
            try
            {
                _dbContext.Invoices.AddAsync(invoice);
                _dbContext.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex) 
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<bool> DeleteInvoiceAsync(int invoiceId)
        {
            var objDel = await _dbContext.Invoices.Where(p => p.InvoiceId.Equals(invoiceId)).FirstOrDefaultAsync();
            try
            {
                if (objDel != null)
                {
                    _dbContext.Invoices.Remove(objDel);
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

        public async Task<List<Invoice>> GetInvoices()
        {
            List<Invoice> invoices = null;
            try
            {
                invoices = await _dbContext.Invoices.ToListAsync();
            }
            catch (Exception ex) 
            {
                invoices?.Add(new Invoice());
            }
            return invoices;
        }

        public Task<bool> RemoveInvoiceAsync(Invoice invoice)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateInvoice(Invoice invoice)
        {
            try
            {
                _dbContext.Invoices.Update(invoice);
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
