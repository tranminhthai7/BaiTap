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
    public class ProductRepository : IProductRepository
    {
        private readonly KoiFarmShop2024DbContext _dbContext;

        public ProductRepository(KoiFarmShop2024DbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public Task<bool> AddProduct(Product product)
        {
            try
            {
                _dbContext.Products.AddAsync(product);
                _dbContext.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex) 
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<bool> DeleteProductAsync(int productId)
        {
            var objDel = await _dbContext.Products.Where(p => p.ProductId.Equals(productId)).FirstOrDefaultAsync();
            try
            {
                if (objDel != null)
                {
                    _dbContext.Products.Remove(objDel);
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

        public async Task<List<Product>> GetProducts()
        {
            List<Product> products = null;
            try
            {
                products = await _dbContext.Products.ToListAsync();
            }
            catch (Exception ex) 
            {
                products?.Add(new Product());
            }
            return products;
        }

        public Task<bool> RemoveProductAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateProduct(Product product)
        {
            try
            {
                _dbContext.Products.Update(product);
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
