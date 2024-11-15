using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;
using KoiFarmShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiFarmShop.Services.Services
{
	public class ProductService : IProductService
	{
		private readonly IProductRepository _productRepository;

		public object Products { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public ProductService(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

		public async Task<bool> AddProductAsync(Product product)
		{
			return await _productRepository.AddProductAsync(product);
		}

		public async Task<bool> DeleteProductAsync(int productId)
		{
			return await _productRepository.DeleteProductAsync(productId);
		}

		public async Task<List<Product>> GetAllProductsAsync()
		{
			return await _productRepository.GetProductsAsync();
		}

		public async Task<bool> UpdateProductAsync(Product product)
		{
			return await _productRepository.UpdateProductAsync(product);
		}

		public async Task<bool> RemoveProductAsync(Product product)
		{
			return await _productRepository.RemoveProductAsyncByEntity(product);
		}

		public object GetProducts()
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Product> GetAllProducts()
		{
			throw new NotImplementedException();
		}

		public Product GetProductById(int productId)
		{
			throw new NotImplementedException();
		}
	}
}
