using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Repositories.Interfaces
{
	public interface IProductRepository
	{
		// Lấy danh sách các sản phẩm
		Task<List<Product>> GetProductsAsync();

		// Thêm sản phẩm mới
		Task<bool> AddProductAsync(Product product);

		// Xóa sản phẩm theo thực thể Product (bản ghi cụ thể)
		Task<bool> RemoveProductAsyncByEntity(Product product);

		// Xóa sản phẩm theo ProductId
		Task<bool> DeleteProductAsync(int productId);

		// Cập nhật thông tin sản phẩm
		Task<bool> UpdateProductAsync(Product product);
		Task<IEnumerable<object>> FilterProductsAsync(decimal? minPrice, decimal? maxPrice, string? category);

		// Thêm phương thức lọc sản phẩm
		public interface IProductRepository
		{
			Task<List<Product>> FilterProductsAsync(decimal? minPrice, decimal? maxPrice, string? category);
		}
	}
}
