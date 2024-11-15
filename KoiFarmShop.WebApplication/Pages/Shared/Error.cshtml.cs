using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace KoiFarmShop.WebApplication.Pages.Shared
{
	public class ErrorModel : PageModel
	{
		// Thông tin lỗi có thể được truyền từ phía server qua Query string hoặc thông qua ViewData
		[BindProperty(SupportsGet = true)]
		public int StatusCode { get; set; }

		public void OnGet()
		{
			// Xử lý nếu cần, ví dụ lấy mã lỗi HTTP từ StatusCode
			if (StatusCode == 404)
			{
				// Có thể thêm logic xử lý nếu trang không tồn tại
			}
		}
	}
}

