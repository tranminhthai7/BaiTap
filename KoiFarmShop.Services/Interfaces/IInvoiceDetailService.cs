using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Services.Interfaces
{
    public interface IInvoiceDetailService
    {
        Task<List<InvoiceDetail>> GetInvoiceDetails();
        Task<bool> AddInvoiceDetail(InvoiceDetail invoiceDetail);
        Task<bool> RemoveInvoiceDetailAsync(InvoiceDetail invoiceDetail);
        Task<bool> DeleteInvoiceDetailAsync(int invoiceDetailId);
        Task<bool> UpdateInvoiceDetail(InvoiceDetail invoiceDetail);
    }
}
