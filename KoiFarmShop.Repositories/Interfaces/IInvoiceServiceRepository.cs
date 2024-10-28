using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Repositories.Interfaces
{
    public interface IInvoiceRepository
    {
        Task<List<TbInvoice>> GetInvoicesAsync();
        Task<int> AddInvoiceAsync(TbInvoice invoice);
        Task<int> RemoveInvoiceAsync(int invoiceId);
        Task<bool> DeleteInvoiceAsync(int invoiceId);
        Task<int> UpdateInvoiceAsync(TbInvoice invoice);
    }
}