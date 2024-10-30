using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;

namespace KoiFarmShop.Repositories.Repositories
{
    public class ProductCommentRepository : IProductCommentRepository
    {
        private readonly KoiFarmShopDbContext _dbContext;

        public ProductCommentRepository(KoiFarmShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TbProductComment>> GetProductCommentsAsync()
        {
            try
            {
                return await _dbContext.TbProductComments.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return new List<TbProductComment>();
            }
        }

        public async Task<int> AddProductCommentAsync(TbProductComment productComment)
        {
            try
            {
                await _dbContext.TbProductComments.AddAsync(productComment);
                await _dbContext.SaveChangesAsync();
                return productComment.Id; // Assuming Id is the primary key and is auto-generated
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return 0; // Return 0 to indicate failure
            }
        }

        public async Task<int> RemoveProductCommentAsync(int productCommentId)
        {
            var productComment = await _dbContext.TbProductComments.FindAsync(productCommentId);
            if (productComment == null)
            {
                return 0; // Return 0 to indicate that the record was not found
            }

            try
            {
                _dbContext.TbProductComments.Remove(productComment);
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return 0; // Return 0 to indicate failure
            }
        }

        public async Task<bool> DeleteProductCommentAsync(int productCommentId)
        {
            var productComment = await _dbContext.TbProductComments.FindAsync(productCommentId);
            if (productComment == null)
            {
                return false; // Return false to indicate that the record was not found
            }

            try
            {
                _dbContext.TbProductComments.Remove(productComment);
                await _dbContext.SaveChangesAsync();
                return true; // Return true to indicate success
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return false; // Return false to indicate failure
            }
        }

        public async Task<int> UpdateProductCommentAsync(TbProductComment productComment)
        {
            try
            {
                _dbContext.TbProductComments.Update(productComment);
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