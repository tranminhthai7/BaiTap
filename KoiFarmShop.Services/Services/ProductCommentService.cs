using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;
using KoiFarmShop.Services.Interfaces;

namespace KoiFarmShop.Services.Services
{
    public class ProductCommentService : IProductCommentService
    {
        private readonly IProductCommentRepository _productCommentRepository;

        public ProductCommentService(IProductCommentRepository productCommentRepository)
        {
            _productCommentRepository = productCommentRepository;
        }

        public Task<List<TbProductComment>> GetProductCommentsAsync()
        {
            return _productCommentRepository.GetProductCommentsAsync();
        }

        public Task<int> AddProductCommentAsync(TbProductComment productComment)
        {
            return _productCommentRepository.AddProductCommentAsync(productComment);
        }

        public Task<int> RemoveProductCommentAsync(int productCommentId)
        {
            return _productCommentRepository.RemoveProductCommentAsync(productCommentId);
        }

        public Task<bool> DeleteProductCommentAsync(int productCommentId)
        {
            return _productCommentRepository.DeleteProductCommentAsync(productCommentId);
        }

        public Task<int> UpdateProductCommentAsync(TbProductComment productComment)
        {
            return _productCommentRepository.UpdateProductCommentAsync(productComment);
        }
    }
}