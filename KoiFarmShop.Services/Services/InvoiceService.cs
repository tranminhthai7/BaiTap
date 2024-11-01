using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;
using KoiFarmShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarmShop.Services.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceService(IInvoiceRepository invoiceRepository) {
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

        public async Task<List<Invoice>> GetInvoices()
        {
            return await _invoiceRepository.GetInvoices();
        }

        public Task<bool> UpdateInvoice(Invoice invoice)
        {
            return _invoiceRepository.UpdateInvoice(invoice);
        }

        public Task<bool> RemoveInvoiceAsync(Invoice invoice)
        {
            throw new NotImplementedException();
        }
    }
}
