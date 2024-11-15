using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Services.Interfaces
{
	public interface IProductService
	{
		object Products { get; set; }

		// Lấy danh sách sản phẩm
		Task<List<Product>> GetAllProductsAsync();

		// Thêm sản phẩm mới
		Task<bool> AddProductAsync(Product product);

		// Xóa sản phẩm bằng thực thể Product
		Task<bool> RemoveProductAsync(Product product);

		// Xóa sản phẩm theo ProductId
		Task<bool> DeleteProductAsync(int productId);

		// Cập nhật thông tin sản phẩm
		Task<bool> UpdateProductAsync(Product product);
		object GetProducts();
		IEnumerable<Product> GetAllProducts();
		Product GetProductById(int productId);

	}
}
