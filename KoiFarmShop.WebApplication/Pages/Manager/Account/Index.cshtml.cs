using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Pages.Account
{
    public class IndexModel : PageModel
    {
        private readonly KoiFarmShop2024DbContext _context;

        public IndexModel(KoiFarmShop2024DbContext context)
        {
            _context = context;
        }

        public List<User> Users { get; set; }
        [BindProperty]
        public User CurrentUser { get; set; }
        public string ActionType { get; set; }

        public void OnGet()
        {
            Users = _context.Users.ToList() ?? new List<User>(); // Populate Users with data from the database
            // Code to initialize Users and other properties
        }
    }
}

