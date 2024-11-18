using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace KoiFarmShop.WebApplication.Pages.Koi_ki_gui
{ 
public class koi_ki_guiModel : PageModel
{
	private readonly IConsignmentService _consignmentService;
	private readonly ILogger<koi_ki_guiModel> _logger;

	public koi_ki_guiModel(IConsignmentService consignmentService, ILogger<koi_ki_guiModel> logger)
	{
		_consignmentService = consignmentService;
		_logger = logger;
	}

	[BindProperty]
	public Consignment Consignment { get; set; } = new Consignment();

	public List<Consignment> Consignments { get; set; }

	public async Task OnGetAsync()
	{
		Consignments = await _consignmentService.GetConsignments();
	}

	public async Task<IActionResult> OnPostAsync()
	{
		if (!ModelState.IsValid)
		{
			_logger.LogError("Model state is invalid.");
			return Page();
		}

		try
		{
			var result = await _consignmentService.AddConsignment(Consignment);
			if (result)
			{
				_logger.LogInformation("Consignment added successfully.");
				return RedirectToPage(); // Hoặc redirect tới trang khác
			}
			else
			{
				_logger.LogError("Failed to add consignment.");
				return Page();
			}
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, "Error adding consignment.");
			return Page();
		}
	}
}


}
