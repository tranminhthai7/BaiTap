using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Services.Interfaces
{
    public interface IInvoiceDetailService
    {
        Task<List<TbInvoiceDetail>> GetInvoiceDetailsAsync();
        Task<int> AddInvoiceDetailAsync(TbInvoiceDetail invoiceDetail);
        Task<int> RemoveInvoiceDetailAsync(int invoiceDetailId);
        Task<bool> DeleteInvoiceDetailAsync(int invoiceDetailId);
        Task<int> UpdateInvoiceDetailAsync(TbInvoiceDetail invoiceDetail);
    }
}