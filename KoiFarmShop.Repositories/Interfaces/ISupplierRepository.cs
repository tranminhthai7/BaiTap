using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Repositories.Interfaces
{
    public interface ISupplierRepository
    {
        Task<List<Supplier>> GetSuppliers();
        Task<bool> AddSupplier(Supplier supplier);
        Task<bool> RemoveSupplierAsync(Supplier supplier);
        Task<bool> DeleteSupplierAsync(int supplierId);
        Task<bool> UpdateSupplier(Supplier supplier);
    }
}