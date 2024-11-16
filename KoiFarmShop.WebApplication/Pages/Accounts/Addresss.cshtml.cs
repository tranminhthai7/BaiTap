using KoiFarmShop.Service.Interfaces;
using KoiFarmShop.Repositories.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiFarmShop.WebApplication.Pages.Accounts
{
	public class AddresssModel : PageModel
	{
		private readonly IAddresssService _addresssService;

		public AddresssModel(IAddresssService addresssService)
		{
			_addresssService = addresssService;
		}

		[BindProperty]
		public string UserPhone { get; set; }

		[BindProperty]
		public string Company { get; set; }

		[BindProperty]
		public string FullAddress { get; set; }

		[BindProperty]
		public bool IsDefault { get; set; }

		public List<Addresss> UserAddresses { get; set; }

		public async Task<IActionResult> OnGetAsync()
		{
			var userName = User.Identity.Name;
			UserAddresses = await _addresssService.GetAddressesByUserNameAsync(userName);
			UserPhone = Request.Cookies["UserPhone"];
			Company = Request.Cookies["UserCompany"];
			FullAddress = Request.Cookies["UserAddress"];
			return Page();
		}

		public async Task<IActionResult> OnPostAsync()
		{
			if (ModelState.IsValid)
			{
				var newAddress = await _addresssService.AddAddressFromDetailsAsync(UserPhone, Company, FullAddress);
				return RedirectToPage();
			}
			else
			{
				return Page();
			}
		}
	}
}


