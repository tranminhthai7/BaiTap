using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;
using KoiFarmShop.Services.Interfaces;

namespace KoiFarmShop.Services.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public Task<List<TbSupplier>> GetSuppliersAsync()
        {
            return _supplierRepository.GetSuppliersAsync();
        }

        public Task<int> AddSupplierAsync(TbSupplier supplier)
        {
            return _supplierRepository.AddSupplierAsync(supplier);
        }

        public Task<int> RemoveSupplierAsync(int supplierId)
        {
            return _supplierRepository.RemoveSupplierAsync(supplierId);
        }

        public Task<bool> DeleteSupplierAsync(int supplierId)
        {
            return _supplierRepository.DeleteSupplierAsync(supplierId);
        }

        public Task<int> UpdateSupplierAsync(TbSupplier supplier)
        {
            return _supplierRepository.UpdateSupplierAsync(supplier);
        }
    }
}