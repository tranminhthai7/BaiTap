using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Repositories.Interfaces
{
    public interface IProductCategoryRepository
    {
        Task<List<TbProductCategory>> GetProductCategoriesAsync();
        Task<int> AddProductCategoryAsync(TbProductCategory productCategory);
        Task<int> RemoveProductCategoryAsync(int productCategoryId);
        Task<bool> DeleteProductCategoryAsync(int productCategoryId);
        Task<int> UpdateProductCategoryAsync(TbProductCategory productCategory);
    }
}