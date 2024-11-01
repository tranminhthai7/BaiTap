using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetProducts();
        Task<bool> AddProduct(Product product);
        Task<bool> RemoveProductAsync(Product product);
        Task<bool> DeleteProductAsync(int productId);
        Task<bool> UpdateProduct(Product product);
    }
}