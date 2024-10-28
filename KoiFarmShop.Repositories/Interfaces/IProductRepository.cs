using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<List<TbProduct>> GetProductsAsync();
        Task<int> AddProductAsync(TbProduct product);
        Task<int> RemoveProductAsync(int productId);
        Task<bool> DeleteProductAsync(int productId);
        Task<int> UpdateProductAsync(TbProduct product);
    }
}