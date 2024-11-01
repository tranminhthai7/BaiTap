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
    public class ProductCommentRepository : IProductCommentRepository
    {
        private readonly KoiFarmShop2024DbContext _dbContext;

        public ProductCommentRepository(KoiFarmShop2024DbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public Task<bool> AddProductComment(ProductComment productComment)
        {
            try
            {
                _dbContext.ProductComments.AddAsync(productComment);
                _dbContext.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex) 
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<bool> DeleteProductCommentAsync(int productCommentId)
        {
            var objDel = await _dbContext.ProductComments.Where(p => p.CommentId.Equals(productCommentId)).FirstOrDefaultAsync();
            try
            {
                if (objDel != null)
                {
                    _dbContext.ProductComments.Remove(objDel);
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

        public async Task<List<ProductComment>> GetProductComments()
        {
            List<ProductComment> productComments = null;
            try
            {
                productComments = await _dbContext.ProductComments.ToListAsync();
            }
            catch (Exception ex) 
            {
                productComments?.Add(new ProductComment());
            }
            return productComments;
        }

        public Task<bool> RemoveProductCommentAsync(ProductComment productComment)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateProductComment(ProductComment productComment)
        {
            try
            {
                _dbContext.ProductComments.Update(productComment);
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
