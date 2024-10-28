using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;
using KoiFarmShop.Services.Interfaces;

namespace KoiFarmShop.Services.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;

        public BlogService(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public Task<List<TbBlog>> GetBlogsAsync()
        {
            return _blogRepository.GetBlogsAsync();
        }

        public Task<int> AddBlogAsync(TbBlog blog)
        {
            return _blogRepository.AddBlogAsync(blog);
        }

        public Task<int> RemoveBlogAsync(int blogId)
        {
            return _blogRepository.RemoveBlogAsync(blogId);
        }

        public Task<bool> DeleteBlogAsync(int blogId)
        {
            return _blogRepository.DeleteBlogAsync(blogId);
        }

        public Task<int> UpdateBlogAsync(TbBlog blog)
        {
            return _blogRepository.UpdateBlogAsync(blog);
        }
    }
}