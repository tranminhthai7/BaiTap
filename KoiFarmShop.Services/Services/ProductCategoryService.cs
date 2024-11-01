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
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository) {
            _productCategoryRepository = productCategoryRepository;
        }

        public Task<bool> AddProductCategory(ProductCategory productCategory)
        {
            return _productCategoryRepository.AddProductCategory(productCategory);
        }

        public Task<bool> DeleteProductCategoryAsync(int productCategoryId)
        {
            return _productCategoryRepository.DeleteProductCategoryAsync(productCategoryId);
        }

        public async Task<List<ProductCategory>> GetProductCategories()
        {
            return await _productCategoryRepository.GetProductCategories();
        }

        public Task<bool> UpdateProductCategory(ProductCategory productCategory)
        {
            return _productCategoryRepository.UpdateProductCategory(productCategory);
        }

        public Task<bool> RemoveProductCategoryAsync(ProductCategory productCategory)
        {
            throw new NotImplementedException();
        }
    }
}
