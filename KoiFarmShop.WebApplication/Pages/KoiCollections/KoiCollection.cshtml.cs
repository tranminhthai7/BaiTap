using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiFarmShop.WebApplication.Pages.KoiCollections
{
    public class KoiCollectionModel : PageModel
    {
        private readonly IKoiService _koiService;

        // Inject IKoiService vào constructor
        public KoiCollectionModel(IKoiService koiService)
        {
            _koiService = koiService;
        }

        // Property để chứa danh sách các Koi
        public List<Koi> KoiCollection { get; set; }

        // Phương thức OnGetAsync sẽ được gọi khi tải trang
        public async Task OnGetAsync()
        {
            KoiCollection = await _koiService.GetKois(); // Lấy danh sách Koi từ Service
        }
    }
}
