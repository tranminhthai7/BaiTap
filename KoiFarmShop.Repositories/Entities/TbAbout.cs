using System;
using System.Collections.Generic;

namespace KoiFarmShop.Repositories.Entities;

public partial class TbAbout
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Detail { get; set; }

    public bool? Status { get; set; }

    public string? MetaKeywords { get; set; }

    public string? MetaDescriptioins { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdateBy { get; set; }

    public DateTime? UpdateDate { get; set; }
}
