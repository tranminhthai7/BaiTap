using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Services.Interfaces
{
    public interface IProductCategoryService
    {
        Task<List<ProductCategory>> GetProductCategories();
        Task<bool> AddProductCategory(ProductCategory productCategory);
        Task<bool> RemoveProductCategoryAsync(ProductCategory productCategory);
        Task<bool> DeleteProductCategoryAsync(int categoryId);
        Task<bool> UpdateProductCategory(ProductCategory productCategory);
    }
}
