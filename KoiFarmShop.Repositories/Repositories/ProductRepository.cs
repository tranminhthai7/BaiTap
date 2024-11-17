using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;


namespace KoiFarmShop.Repositories.Repositories
{
	public class ProductRepository : IProductRepository
	{
		private readonly KoiFarmShop2024DbContext _dbContext;

		public ProductRepository(KoiFarmShop2024DbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<bool> AddProductAsync(Product product)
		{
			try
			{
				await _dbContext.Products.AddAsync(product);
				await _dbContext.SaveChangesAsync();
				return true;
			}
			catch (Exception ex)
			{
				// Log the exception (logging framework or custom logger can be used here)
				return false;
			}
		}

		public async Task<bool> DeleteProductAsync(int productId)
		{
			try
			{
				var objDel = await _dbContext.Products.FindAsync(productId);
				if (objDel != null)
				{
					_dbContext.Products.Remove(objDel);
					await _dbContext.SaveChangesAsync();
					return true;
				}
				return false;
			}
			catch (Exception ex)
			{
				// Log the exception
				return false;
			}
		}

		public async Task<List<Product>> GetProductsAsync()
		{
			try
			{
				return await _dbContext.Products.ToListAsync();
			}
			catch (Exception ex)
			{
				// Log the exception
				return new List<Product>(); // Trả về danh sách rỗng nếu có lỗi
			}
		}

		public async Task<bool> RemoveProductAsyncByEntity(Product product)
		{
			try
			{
				_dbContext.Products.Remove(product);
				await _dbContext.SaveChangesAsync();
				return true;
			}
			catch (Exception ex)
			{
				// Log the exception
				return false;
			}
		}

		public async Task<bool> UpdateProductAsync(Product product)
		{
			try
			{
				_dbContext.Products.Update(product);
				await _dbContext.SaveChangesAsync();
				return true;
			}
			catch (Exception ex)
			{
				// Log the exception
				return false;
			}
		}
		public async Task<List<Product>> FilterProductsAsync(decimal? minPrice, decimal? maxPrice, string? category)
		{
			var query = _dbContext.Products.AsQueryable();

			if (minPrice.HasValue)
			{
				query = query.Where(p => p.Price >= minPrice.Value);
			}

			if (maxPrice.HasValue)
			{
				query = query.Where(p => p.Price <= maxPrice.Value);
			}

			if (!string.IsNullOrEmpty(category))
			{
				query = query.Where(p => p.Loai == category);
			}

			return await query.ToListAsync();
		}

		Task<IEnumerable<object>> IProductRepository.FilterProductsAsync(decimal? minPrice, decimal? maxPrice, string? category)
		{
			throw new NotImplementedException();
		}
	}
}