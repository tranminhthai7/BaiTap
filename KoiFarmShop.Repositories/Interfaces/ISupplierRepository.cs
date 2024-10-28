using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Repositories.Interfaces
{
    public interface ISupplierRepository
    {
        Task<List<TbSupplier>> GetSuppliersAsync();
        Task<int> AddSupplierAsync(TbSupplier supplier);
        Task<int> RemoveSupplierAsync(int supplierId);
        Task<bool> DeleteSupplierAsync(int supplierId);
        Task<int> UpdateSupplierAsync(TbSupplier supplier);
    }
}