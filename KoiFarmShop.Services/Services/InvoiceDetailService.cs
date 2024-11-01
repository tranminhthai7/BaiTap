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
    public class InvoiceDetailService : IInvoiceDetailService
    {
        private readonly IInvoiceDetailRepository _invoiceDetailRepository;

        public InvoiceDetailService(IInvoiceDetailRepository invoiceDetailRepository) {
            _invoiceDetailRepository = invoiceDetailRepository;
        }

        public Task<bool> AddInvoiceDetail(InvoiceDetail invoiceDetail)
        {
            return _invoiceDetailRepository.AddInvoiceDetail(invoiceDetail);
        }

        public Task<bool> DeleteInvoiceDetailAsync(int invoiceDetailId)
        {
            return _invoiceDetailRepository.DeleteInvoiceDetailAsync(invoiceDetailId);
        }

        public async Task<List<InvoiceDetail>> GetInvoiceDetails()
        {
            return await _invoiceDetailRepository.GetInvoiceDetails();
        }

        public Task<bool> UpdateInvoiceDetail(InvoiceDetail invoiceDetail)
        {
            return _invoiceDetailRepository.UpdateInvoiceDetail(invoiceDetail);
        }

        public Task<bool> RemoveInvoiceDetailAsync(InvoiceDetail invoiceDetail)
        {
            throw new NotImplementedException();
        }
    }
}
