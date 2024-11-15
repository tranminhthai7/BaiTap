using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiFarmShop.Repositories.Interfaces;
using KoiFarmShop.Services.Interfaces;
using KoiFarmShop.Repositories.Entities;

using System.Threading.Tasks;
namespace KoiFarmShop.WebApplication.Pages.Contact
{
    public class ContactModel : PageModel
    {


        private readonly IContactService _contactService;

        public ContactModel(IContactService contactService)
        {
            _contactService = contactService;
        }

        [BindProperty]
        public KoiFarmShop.Repositories.Entities.Contact Contact { get; set; }

        public string SuccessMessage { get; set; }

        public void OnGet()
        {
            Contact = new KoiFarmShop.Repositories.Entities.Contact();
            if (Request.Query["contact_posted"] == "true")
            {
                SuccessMessage = "Liên hệ đã được gửi thành công!";
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Contact == null)
            {
                Contact = new KoiFarmShop.Repositories.Entities.Contact();
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _contactService.AddContact(Contact);

            // Chuyển hướng với query string khi thành công
            return RedirectToPage("/Contact/Contact", new { contact_posted = true });
        }
    }
}


