using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;

namespace KoiFarmShop.Repositories.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly KoiFarmShopDbContext _dbContext;

        public ProductCategoryRepository(KoiFarmShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TbProductCategory>> GetProductCategoriesAsync()
        {
            try
            {
                return await _dbContext.TbProductCategories.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return new List<TbProductCategory>();
            }
        }

        public async Task<int> AddProductCategoryAsync(TbProductCategory productCategory)
        {
            try
            {
                await _dbContext.TbProductCategories.AddAsync(productCategory);
                await _dbContext.SaveChangesAsync();
                return productCategory.Id; // Assuming Id is the primary key and is auto-generated
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return 0; // Return 0 to indicate failure
            }
        }

        public async Task<int> RemoveProductCategoryAsync(int productCategoryId)
        {
            var productCategory = await _dbContext.TbProductCategories.FindAsync(productCategoryId);
            if (productCategory == null)
            {
                return 0; // Return 0 to indicate that the record was not found
            }

            try
            {
                _dbContext.TbProductCategories.Remove(productCategory);
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return 0; // Return 0 to indicate failure
            }
        }

        public async Task<bool> DeleteProductCategoryAsync(int productCategoryId)
        {
            var productCategory = await _dbContext.TbProductCategories.FindAsync(productCategoryId);
            if (productCategory == null)
            {
                return false; // Return false to indicate that the record was not found
            }

            try
            {
                _dbContext.TbProductCategories.Remove(productCategory);
                await _dbContext.SaveChangesAsync();
                return true; // Return true to indicate success
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return false; // Return false to indicate failure
            }
        }

        public async Task<int> UpdateProductCategoryAsync(TbProductCategory productCategory)
        {
            try
            {
                _dbContext.TbProductCategories.Update(productCategory);
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return 0; // Return 0 to indicate failure
            }
        }
    }
}