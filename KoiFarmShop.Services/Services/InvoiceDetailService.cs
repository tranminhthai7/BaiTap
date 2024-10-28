using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;
using KoiFarmShop.Services.Interfaces;

namespace KoiFarmShop.Services.Services
{
    public class InvoiceDetailService : IInvoiceDetailService
    {
        private readonly IInvoiceDetailRepository _invoiceDetailRepository;

        public InvoiceDetailService(IInvoiceDetailRepository invoiceDetailRepository)
        {
            _invoiceDetailRepository = invoiceDetailRepository;
        }

        public Task<List<TbInvoiceDetail>> GetInvoiceDetailsAsync()
        {
            return _invoiceDetailRepository.GetInvoiceDetailsAsync();
        }

        public Task<int> AddInvoiceDetailAsync(TbInvoiceDetail invoiceDetail)
        {
            return _invoiceDetailRepository.AddInvoiceDetailAsync(invoiceDetail);
        }

        public Task<int> RemoveInvoiceDetailAsync(int invoiceDetailId)
        {
            return _invoiceDetailRepository.RemoveInvoiceDetailAsync(invoiceDetailId);
        }

        public Task<bool> DeleteInvoiceDetailAsync(int invoiceDetailId)
        {
            return _invoiceDetailRepository.DeleteInvoiceDetailAsync(invoiceDetailId);
        }

        public Task<int> UpdateInvoiceDetailAsync(TbInvoiceDetail invoiceDetail)
        {
            return _invoiceDetailRepository.UpdateInvoiceDetailAsync(invoiceDetail);
        }
    }
}