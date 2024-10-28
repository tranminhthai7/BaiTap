using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;
using KoiFarmShop.Services.Interfaces;

namespace KoiFarmShop.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<List<TbProduct>> GetProductsAsync()
        {
            return _productRepository.GetProductsAsync();
        }

        public Task<int> AddProductAsync(TbProduct product)
        {
            return _productRepository.AddProductAsync(product);
        }

        public Task<int> RemoveProductAsync(int productId)
        {
            return _productRepository.RemoveProductAsync(productId);
        }

        public Task<bool> DeleteProductAsync(int productId)
        {
            return _productRepository.DeleteProductAsync(productId);
        }

        public Task<int> UpdateProductAsync(TbProduct product)
        {
            return _productRepository.UpdateProductAsync(product);
        }
    }
}