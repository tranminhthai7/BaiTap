using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Repositories.Interfaces
{
    public interface IInvoiceDetailRepository
    {
        Task<List<InvoiceDetail>> GetInvoiceDetails();
        Task<bool> AddInvoiceDetail(InvoiceDetail invoiceDetail);
        Task<bool> RemoveInvoiceDetailAsync(InvoiceDetail invoiceDetail);
        Task<bool> DeleteInvoiceDetailAsync(int invoiceDetailId);
        Task<bool> UpdateInvoiceDetail(InvoiceDetail invoiceDetail);
    }
}
