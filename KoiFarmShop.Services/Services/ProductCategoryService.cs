using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;
using KoiFarmShop.Services.Interfaces;

namespace KoiFarmShop.Services.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public Task<List<TbProductCategory>> GetProductCategoriesAsync()
        {
            return _productCategoryRepository.GetProductCategoriesAsync();
        }

        public Task<int> AddProductCategoryAsync(TbProductCategory productCategory)
        {
            return _productCategoryRepository.AddProductCategoryAsync(productCategory);
        }

        public Task<int> RemoveProductCategoryAsync(int productCategoryId)
        {
            return _productCategoryRepository.RemoveProductCategoryAsync(productCategoryId);
        }

        public Task<bool> DeleteProductCategoryAsync(int productCategoryId)
        {
            return _productCategoryRepository.DeleteProductCategoryAsync(productCategoryId);
        }

        public Task<int> UpdateProductCategoryAsync(TbProductCategory productCategory)
        {
            return _productCategoryRepository.UpdateProductCategoryAsync(productCategory);
        }
    }
}