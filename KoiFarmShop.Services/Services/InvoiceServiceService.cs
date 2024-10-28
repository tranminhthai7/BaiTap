using System;
using System.Collections.Generic;
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

        public Task<List<TbInvoice>> GetInvoicesAsync()
        {
            return _invoiceRepository.GetInvoicesAsync();
        }

        public Task<int> AddInvoiceAsync(TbInvoice invoice)
        {
            return _invoiceRepository.AddInvoiceAsync(invoice);
        }

        public Task<int> RemoveInvoiceAsync(int invoiceId)
        {
            return _invoiceRepository.RemoveInvoiceAsync(invoiceId);
        }

        public Task<bool> DeleteInvoiceAsync(int invoiceId)
        {
            return _invoiceRepository.DeleteInvoiceAsync(invoiceId);
        }

        public Task<int> UpdateInvoiceAsync(TbInvoice invoice)
        {
            return _invoiceRepository.UpdateInvoiceAsync(invoice);
        }
    }
}