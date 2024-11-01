using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Services.Interfaces
{
    public interface IBlogService
    {
        Task<List<Blog>> GetBlogs();
        Task<bool> AddBlog(Blog blog);
        Task<bool> RemoveBlogAsync(Blog blog);
        Task<bool> DeleteBlogAsync(int blogId);
        Task<bool> UpdateBlog(Blog blog);
    }
}
