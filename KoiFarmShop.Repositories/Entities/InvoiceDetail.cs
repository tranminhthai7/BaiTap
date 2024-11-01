using System;
using System.Collections.Generic;

namespace KoiFarmShop.Repositories.Entities;

public partial class InvoiceDetail
{
    public int InvoiceId { get; set; }

    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public decimal? Price { get; set; }
}
