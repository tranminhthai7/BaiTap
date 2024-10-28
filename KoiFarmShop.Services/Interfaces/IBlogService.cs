using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Services.Interfaces
{
    public interface IBlogService
    {
        Task<List<TbBlog>> GetBlogsAsync();
        Task<int> AddBlogAsync(TbBlog blog);
        Task<int> RemoveBlogAsync(int blogId);
        Task<bool> DeleteBlogAsync(int blogId);
        Task<int> UpdateBlogAsync(TbBlog blog);
    }
}
