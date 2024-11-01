using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;

namespace KoiFarmShop.Repositories.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly KoiFarmShop2024DbContext _dbContext;

        public BlogRepository(KoiFarmShop2024DbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public Task<bool> AddBlog(Blog blog)
        {
            try
            {
                _dbContext.Blogs.AddAsync(blog);
                _dbContext.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex) 
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<bool> DeleteBlogAsync(int blogId)
        {
            var objDel = await _dbContext.Blogs.Where(p => p.BlogId.Equals(blogId)).FirstOrDefaultAsync();
            try
            {
                if (objDel != null)
                {
                    _dbContext.Blogs.Remove(objDel);
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

        public async Task<List<Blog>> GetBlogs()
        {
            List<Blog> blogs = null;
            try
            {
                blogs = await _dbContext.Blogs.ToListAsync();
            }
            catch (Exception ex) 
            {
                blogs?.Add(new Blog());
            }
            return blogs;
        }

        public Task<bool> RemoveBlogAsync(Blog blog)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateBlog(Blog blog)
        {
            try
            {
                _dbContext.Blogs.Update(blog);
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
