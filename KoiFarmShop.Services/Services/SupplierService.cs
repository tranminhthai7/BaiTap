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
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository) {
            _supplierRepository = supplierRepository;
        }

        public Task<bool> AddSupplier(Supplier supplier)
        {
            return _supplierRepository.AddSupplier(supplier);
        }

        public Task<bool> DeleteSupplierAsync(int supplierId)
        {
            return _supplierRepository.DeleteSupplierAsync(supplierId);
        }

        public async Task<List<Supplier>> GetSuppliers()
        {
            return await _supplierRepository.GetSuppliers();
        }

        public Task<bool> UpdateSupplier(Supplier supplier)
        {
            return _supplierRepository.UpdateSupplier(supplier);
        }

        public Task<bool> RemoveSupplierAsync(Supplier supplier)
        {
            throw new NotImplementedException();
        }
    }
}
