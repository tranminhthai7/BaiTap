using System;
using System.Collections.Generic;

namespace KoiFarmShop.Repositories.Entities;

public partial class Promotion
{
	public int PromotionId { get; set; }

	public string? PromotionName { get; set; }
	public string? Image { get; set; }

	public decimal? Price { get; set; }
	public decimal? PromotionPrice { get; set; }

	public string? Description { get; set; }

	public DateTime? StartDate { get; set; }

	public DateTime? EndDate { get; set; }

	public double? DiscountPercentage { get; set; }
	public int ProductId { get; internal set; }
}
