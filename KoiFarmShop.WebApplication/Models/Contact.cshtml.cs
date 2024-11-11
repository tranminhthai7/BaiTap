using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;
using KoiFarmShop.Services.Interfaces;
namespace KoiFarmShop.WebApplication.Models
{
    public class ContactModel : PageModel
    {


        private readonly IContactService _contactService;

        public ContactModel(IContactService contactService)
        {
            _contactService = contactService;
        }

        [BindProperty]
        public Contact Contact { get; set; }

        public string SuccessMessage { get; set; } 

        public void OnGet()
        {
            Contact = new Contact();
            if (Request.Query["contact_posted"] == "true")
            {
                SuccessMessage = "Liên hệ đã được gửi thành công!";
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Contact == null)
            {
                Contact = new Contact();
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _contactService.AddContact(Contact);

            // Chuyển hướng với query string khi thành công
            return RedirectToPage("/Contact/lien-he", new { contact_posted = true });
        }
    }
}


