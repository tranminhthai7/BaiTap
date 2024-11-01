using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;

namespace KoiFarmShop.Repositories.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly KoiFarmShop2024DbContext _dbContext;

        public ProductCategoryRepository(KoiFarmShop2024DbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public Task<bool> AddProductCategory(ProductCategory productCategory)
        {
            try
            {
                _dbContext.ProductCategories.AddAsync(productCategory);
                _dbContext.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex) 
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<bool> DeleteProductCategoryAsync(int productCategoryId)
        {
            var objDel = await _dbContext.ProductCategories.Where(p => p.CateId.Equals(productCategoryId)).FirstOrDefaultAsync();
            try
            {
                if (objDel != null)
                {
                    _dbContext.ProductCategories.Remove(objDel);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                // Log the exception
                return false;
            }
        }

        public async Task<List<ProductCategory>> GetProductCategories()
        {
            List<ProductCategory> productCategories = null;
            try
            {
                productCategories = await _dbContext.ProductCategories.ToListAsync();
            }
            catch (Exception ex) 
            {
                productCategories?.Add(new ProductCategory());
            }
            return productCategories;
        }

        public Task<bool> RemoveProductCategoryAsync(ProductCategory productCategory)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateProductCategory(ProductCategory productCategory)
        {
            try
            {
                _dbContext.ProductCategories.Update(productCategory);
                _dbContext.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                return Task.FromResult(false);
            }
        }
    }
}
