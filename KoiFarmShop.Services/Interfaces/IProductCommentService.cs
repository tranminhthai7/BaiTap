using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Services.Interfaces
{
    public interface IProductCommentService
    {
        Task<List<TbProductComment>> GetProductCommentsAsync();
        Task<int> AddProductCommentAsync(TbProductComment productComment);
        Task<int> RemoveProductCommentAsync(int productCommentId);
        Task<bool> DeleteProductCommentAsync(int productCommentId);
        Task<int> UpdateProductCommentAsync(TbProductComment productComment);
    }
}