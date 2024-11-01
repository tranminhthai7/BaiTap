using System;
using System.Collections.Generic;

namespace KoiFarmShop.Repositories.Entities;

public partial class Footer
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Detail { get; set; }

    public bool? Status { get; set; }

    public int? CreateBy { get; set; }

    public DateTime? CreateDate { get; set; }
}
