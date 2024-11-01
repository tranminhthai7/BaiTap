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
    public class ProductCommentService : IProductCommentService
    {
        private readonly IProductCommentRepository _productCommentRepository;

        public ProductCommentService(IProductCommentRepository productCommentRepository) {
            _productCommentRepository = productCommentRepository;
        }

        public Task<bool> AddProductComment(ProductComment productComment)
        {
            return _productCommentRepository.AddProductComment(productComment);
        }

        public Task<bool> DeleteProductCommentAsync(int productCommentId)
        {
            return _productCommentRepository.DeleteProductCommentAsync(productCommentId);
        }

        public async Task<List<ProductComment>> GetProductComments()
        {
            return await _productCommentRepository.GetProductComments();
        }

        public Task<bool> UpdateProductComment(ProductComment productComment)
        {
            return _productCommentRepository.UpdateProductComment(productComment);
        }

        public Task<bool> RemoveProductCommentAsync(ProductComment productComment)
        {
            throw new NotImplementedException();
        }
    }
}
