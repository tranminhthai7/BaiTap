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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository) {
            _productRepository = productRepository;
        }

        public Task<bool> AddProduct(Product product)
        {
            return _productRepository.AddProduct(product);
        }

        public Task<bool> DeleteProductAsync(int productId)
        {
            return _productRepository.DeleteProductAsync(productId);
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _productRepository.GetProducts();
        }

        public Task<bool> UpdateProduct(Product product)
        {
            return _productRepository.UpdateProduct(product);
        }

        public Task<bool> RemoveProductAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
