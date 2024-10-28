using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Repositories.Interfaces
{
    public interface IProductCommentRepository
    {
        Task<List<TbProductComment>> GetProductCommentsAsync();
        Task<int> AddProductCommentAsync(TbProductComment productComment);
        Task<int> RemoveProductCommentAsync(int productCommentId);
        Task<bool> DeleteProductCommentAsync(int productCommentId);
        Task<int> UpdateProductCommentAsync(TbProductComment productComment);
    }
}