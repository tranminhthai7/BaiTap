using KoiFarmShop.Service.Interfaces;
using KoiFarmShop.Repositories.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

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
            var phoneNumber = Request.Cookies["UserPhone"];
            if (string.IsNullOrEmpty(phoneNumber))
            {
                return RedirectToPage("/Login");
            }

            UserAddresses = await _addresssService.GetAddressesByUserNameAsync(phoneNumber);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var newAddress = new Addresss
                {
                    UserPhone = UserPhone,
                    Company = Company,
                    FullAddress = FullAddress,
                    IsDefault = IsDefault,
                    CreatedDate = DateTime.Now
                };

                await _addresssService.AddAddressAsync(newAddress);
                return RedirectToPage();
            }
            else
            {
                return Page();
            }
        }

        public async Task<IActionResult> OnPostDeleteAddressAsync(string addressToDelete)
        {
            var phoneNumber = Request.Cookies["UserPhone"];
            if (string.IsNullOrEmpty(phoneNumber))
            {
                return RedirectToPage("/Login");
            }

            var userAddresses = await _addresssService.GetAddressesByUserNameAsync(phoneNumber);
            var address = userAddresses.FirstOrDefault(a => a.FullAddress == addressToDelete);

            if (address != null)
            {
                await _addresssService.DeleteAddressAsync(address.AddressId);
                return RedirectToPage();
            }

            return RedirectToPage("/Error");
        }

        public async Task<IActionResult> OnPostEditAddressAsync(int addressId, string userPhone, string company, string fullAddress)
        {
            try
            {
                var address = await _addresssService.GetAddressByIdAsync(addressId);
                if (address != null)
                {
                    address.UserPhone = userPhone;
                    address.Company = company;
                    address.FullAddress = fullAddress;
                    await _addresssService.UpdateAddressAsync(address);
                }
                return new JsonResult(new { success = true });
            }
            catch
            {
                return new JsonResult(new { success = false });
            }
        }

        public async Task<JsonResult> OnGetGetAddressAsync(int id)
        {
            var address = await _addresssService.GetAddressByIdAsync(id);
            return new JsonResult(address);
        }
    }
}