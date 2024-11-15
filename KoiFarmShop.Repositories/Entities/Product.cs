using System;
using System.Collections.Generic;

namespace KoiFarmShop.Repositories.Entities;

public partial class Product
{
	public int ProductId { get; set; }

	public int? Sort { get; set; }

	public string? Name { get; set; }

	public string? Loai { get; set; }
	public string? SeoTitle { get; set; }

	public bool? Status { get; set; }

	public string? Image { get; set; }

	public string? ListsImage { get; set; }

	public decimal? Price { get; set; }

	public decimal? PromotionPrice { get; set; }

	public DateTime? Hot { get; set; }

	public string? Desiption { get; set; }

	public string? Detail { get; set; }

	public int? ViewCount { get; set; }

	public int? CateId { get; set; }

	public int? SupplierId { get; set; }

	public string? MateKeywords { get; set; }

	public string? MetaDescriptioins { get; set; }

	public int? CreatedBy { get; set; }

	public DateTime? CreatedDate { get; set; }

	public int? UpdateBy { get; set; }

	public DateTime? UpdateDate { get; set; }
}
