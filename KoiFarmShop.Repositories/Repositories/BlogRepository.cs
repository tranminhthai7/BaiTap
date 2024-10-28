using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;

namespace KoiFarmShop.Repositories.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly KoiFarmShopDbContext _dbContext;

        public BlogRepository(KoiFarmShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TbBlog>> GetBlogsAsync()
        {
            try
            {
                return await _dbContext.TbBlogs.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return new List<TbBlog>();
            }
        }

        public async Task<int> AddBlogAsync(TbBlog blog)
        {
            try
            {
                await _dbContext.TbBlogs.AddAsync(blog);
                await _dbContext.SaveChangesAsync();
                return blog.Id; // Assuming Id is the primary key and is auto-generated
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return 0; // Return 0 to indicate failure
            }
        }

        public async Task<int> RemoveBlogAsync(int blogId)
        {
            var blog = await _dbContext.TbBlogs.FindAsync(blogId);
            if (blog == null)
            {
                return 0; // Return 0 to indicate that the record was not found
            }

            try
            {
                _dbContext.TbBlogs.Remove(blog);
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return 0; // Return 0 to indicate failure
            }
        }

        public async Task<bool> DeleteBlogAsync(int blogId)
        {
            var blog = await _dbContext.TbBlogs.FindAsync(blogId);
            if (blog == null)
            {
                return false; // Return false to indicate that the record was not found
            }

            try
            {
                _dbContext.TbBlogs.Remove(blog);
                await _dbContext.SaveChangesAsync();
                return true; // Return true to indicate success
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return false; // Return false to indicate failure
            }
        }

        public async Task<int> UpdateBlogAsync(TbBlog blog)
        {
            try
            {
                _dbContext.TbBlogs.Update(blog);
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