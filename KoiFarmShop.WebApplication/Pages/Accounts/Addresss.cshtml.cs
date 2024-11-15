//using KoiFarmShop.Repositories.Entities;
//using KoiFarmShop.Service.Interfaces;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using System.Threading.Tasks;

//namespace KoiFarmShop.WebApplication.Pages.Accounts
//{
//	public class AddresssModel : PageModel
//	{
//		private readonly IAddresssService _addresssService;

//		public AddresssModel(IAddresssService addresssService)
//		{
//			_addresssService = addresssService;
//		}

//		[BindProperty]
//		public Addresss Address { get; set; }

//		// Địa chỉ đầy đủ từ người dùng
//		[BindProperty]
//		public string FullAddress { get; set; }

//		public async Task<IActionResult> OnGetAsync(int? id)
//		{
//			if (id.HasValue)
//			{
//				Address = await _addresssService.GetAddressByIdAsync(id.Value);
//				if (Address == null)
//				{
//					return NotFound();
//				}
//			}
//			else
//			{
//				Address = new Addresss();
//			}
//			return Page();
//		}

//		public async Task<IActionResult> OnPostAsync()
//		{
//			if (!ModelState.IsValid)
//			{
//				return Page();
//			}

//			Address.Address = FullAddress;

//			if (Address.Id > 0)
//			{
//				await _addresssService.UpdateAddressAsync(Address);
//			}
//			else
//			{
//				await _addresssService.AddAddressAsync(Address);
//			}

//			return RedirectToPage("AddresssList");
//		}
//	}
//}