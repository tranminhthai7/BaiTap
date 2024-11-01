using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Services.Interfaces
{
    public interface IProductCommentService
    {
        Task<List<ProductComment>> GetProductComments();
        Task<bool> AddProductComment(ProductComment productComment);
        Task<bool> RemoveProductCommentAsync(ProductComment productComment);
        Task<bool> DeleteProductCommentAsync(int commentId);
        Task<bool> UpdateProductComment(ProductComment productComment);
    }
}
