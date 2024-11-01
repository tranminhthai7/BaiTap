using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Services.Interfaces
{
    public interface IInvoiceService
    {
        Task<List<Invoice>> GetInvoices();
        Task<bool> AddInvoice(Invoice invoice);
        Task<bool> RemoveInvoiceAsync(Invoice invoice);
        Task<bool> DeleteInvoiceAsync(int invoiceId);
        Task<bool> UpdateInvoice(Invoice invoice);
    }
}
