using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;
using KoiFarmShop.Services.Interfaces;

namespace KoiFarmShop.Services.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceService(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public Task<bool> AddInvoice(Invoice invoice)
        {
            return _invoiceRepository.AddInvoice(invoice);
        }

        public Task<bool> DeleteInvoiceAsync(int invoiceId)
        {
            return _invoiceRepository.DeleteInvoiceAsync(invoiceId);
        }

        public async Task<List<Invoice>> GetInvoicesAsync()
        {
            return await _invoiceRepository.GetInvoices();
        }

        public Task<bool> RemoveInvoiceAsync(Invoice invoice)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateInvoice(Invoice invoice)
        {
            return _invoiceRepository.UpdateInvoice(invoice);
        }
    }
}
