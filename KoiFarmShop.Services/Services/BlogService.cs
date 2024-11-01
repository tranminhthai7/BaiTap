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
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;

        public BlogService(IBlogRepository blogRepository) {
            _blogRepository = blogRepository;
        }

        public Task<bool> AddBlog(Blog blog)
        {
            return _blogRepository.AddBlog(blog);
        }

        public Task<bool> DeleteBlogAsync(int blogId)
        {
            return _blogRepository.DeleteBlogAsync(blogId);
        }

        public async Task<List<Blog>> GetBlogs()
        {
            return await _blogRepository.GetBlogs();
        }

        public Task<bool> UpdateBlog(Blog blog)
        {
            return _blogRepository.UpdateBlog(blog);
        }

        public Task<bool> RemoveBlogAsync(Blog blog)
        {
            throw new NotImplementedException();
        }
    }
}
