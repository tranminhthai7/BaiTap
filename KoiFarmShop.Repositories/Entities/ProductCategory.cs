using System;
using System.Collections.Generic;

namespace KoiFarmShop.Repositories.Entities;

public partial class ProductCategory
{
    public int CateId { get; set; }

    public string? Name { get; set; }

    public string? SeoTitle { get; set; }

    public bool? Status { get; set; }

    public int? Sort { get; set; }

    public int? ParentId { get; set; }

    public string? MateKeywords { get; set; }

    public string? MetaDescriptioins { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdateBy { get; set; }

    public DateTime? UpdateDate { get; set; }
}
